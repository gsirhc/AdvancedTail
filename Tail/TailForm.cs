namespace Tail
{
    using System.Runtime.InteropServices;
    using Process;
    using Filter;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using Demo;
    using Extensions;
    using Manager;
    using Predefined;
    using Settings;
    using Reader;

    /// <summary>
    /// Main for displayed to the user.
    /// </summary>
    public partial class TailForm : Form
    {
        private string initialFile = "";        
        private FilterConfigForm filterConfigForm = new FilterConfigForm();

        private ITailManager tailManager;
        
        public TailForm(string initialFile)
        {
            this.initialFile = initialFile;
            InitializeComponent();

            mainMenuToolbar.StartTail += StartTail;
            mainMenuToolbar.StopTail += StopTail;

            mainMenuToolbar.EditFilter += EditFilter;

            mainMenuToolbar.RefreshFile += RefreshFile;
            mainMenuToolbar.SelectedFile += InitializeNewFile;
            mainMenuToolbar.SettingsUpdated += SettingsUpdated;
            mainMenuToolbar.ClearLog += logDisplay.Clear;
            mainMenuToolbar.IncreaseFont += logDisplay.IncreaseFont;
            mainMenuToolbar.DecreaseFont += logDisplay.DecreaseFont;
            mainMenuToolbar.ResetDefaultFont += logDisplay.ResetDefaultFont;
            mainMenuToolbar.EditFile += EditFile;

            mainMenuToolbar.SearchNext += logDisplay.Search;
            mainMenuToolbar.StartDemo += StartDemo;
            mainMenuToolbar.Exit += this.Close;

            logDisplay.FilterToggle += FilterToggle;
            logDisplay.TrimToggle += TrimToggle;
            logDisplay.HighlightToggle += HighlightToggle;
        }
        
        private FileSettings CurrentFileSettings => !string.IsNullOrEmpty(mainMenuToolbar.FilePath) ?  SettingsManager.Instance.GetFileSettings(mainMenuToolbar.FilePath) : FileSettings.Default;

        protected override void OnLoad(EventArgs e)
        {
            //if (!SettingsManager.Instance.LastWindowLocation.IsEmpty)
            //{
            //    this.Location = SettingsManager.Instance.LastWindowLocation;
            //}

            //// Set window size
            //if (!SettingsManager.Instance.LastWindowSize.IsEmpty)
            //{
            //    this.Size = SettingsManager.Instance.LastWindowSize;
            //}

            base.OnLoad(e);
        }

        protected override void OnShown(EventArgs e)
        {
            SetState(false);
            base.OnShown(e);

            mainMenuToolbar.Initialize();
            
            InitializeTailManager((IReaderFactory)new ReaderFactory());

            bool hasArgFile = !string.IsNullOrEmpty(initialFile);
            this.initialFile = hasArgFile ? initialFile : SettingsManager.Instance.LastFile;

            if (!string.IsNullOrEmpty(this.initialFile))
            {
                InitializeNewFile(this.initialFile);

                if (SettingsManager.Instance.RunAtStartup)
                {
                    this.tailManager.StartTail();
                }
            }
        }

        private void InitializeNewFile(string file)
        {
            logDisplay.Clear();
            mainMenuToolbar.FilePath = file;

            var fileSettings = CurrentFileSettings;

            SetupFilterConfigForm();

            mainMenuToolbar.InitialFileSettings(fileSettings);

            logDisplay.AutoScroll = fileSettings.AutoScroll;
            logDisplay.ShowLineNumbers = fileSettings.ShowLineNumbers;

            SetState(false);

            if (SettingsManager.Instance.RunAtStartup)
            {
                StartTail();
            }
        }

        private void SetupFilterConfigForm()
        {
            var fileSettings = CurrentFileSettings;

            filterConfigForm.FilterText = fileSettings.FilterRegex;
            filterConfigForm.TrimToText = fileSettings.ToTrimRegex;
            filterConfigForm.TrimFromText = fileSettings.FromTrimRegex;
            filterConfigForm.TrimMiddleText = fileSettings.MiddleTrimRegex;

            filterConfigForm.HighlightColorMap =
                fileSettings.HighlightRegexMap.StringKeyToEnum<HighlightColor.ColorIndex, string>();

            EnableFilter(fileSettings.EnableFilter);
            EnableTrim(fileSettings.EnableTrim);
            EnableHighlight(fileSettings.EnableHighlight);
        }

        private void InitializeTailManager(IReaderFactory readerFactory)
        {
            this.tailManager = new FileTailManager()
            {
                FormInterface = new FormInterface
                {
                    StartCallback = logDisplay.StartWrite,
                    UpdateCallback = logDisplay.Write,
                    FinishCallback = logDisplay.EndWrite,
                    LoadLastLinesCallback = () => mainMenuToolbar.LoadLastNLines,
                    ClearDisplayCallback = logDisplay.Clear,
                    ExceptionCallback = ExceptionHandler,
                    GetFileNameCallback = () => mainMenuToolbar.FilePath,
                    GetFilterCallback = () => filterConfigForm.Filter,
                    SetStateCallback = SetState
                }
            };
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.tailManager?.StopTail();
            SettingsManager.Instance.LastWindowLocation = this.Location;

            if (this.WindowState == FormWindowState.Normal)
            {
                SettingsManager.Instance.LastWindowSize = this.Size;                
            }
            else
            {
                SettingsManager.Instance.LastWindowSize = new Size();
            }

            base.OnFormClosing(e);
        }

        private void StartTail()
        {
            tailManager.StartTail();
        }

        private void StopTail()
        {
            tailManager.StopTail();

            if (IsDemo)
            {
                InitializeTailManager((IReaderFactory)new ReaderFactory());
                InitializeNewFile(SettingsManager.Instance.LastFile);
            }
        }

        private void EditFilter(PredefinedItem predefinedItem)
        {
            var preview = true;

            if (predefinedItem != null)
            {
                filterConfigForm.SetupPredefined(predefinedItem, !mainMenuToolbar.PreviewPredefinedFilter);
                preview = mainMenuToolbar.PreviewPredefinedFilter;
            }

            if (!preview || (filterConfigForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(mainMenuToolbar.FilePath)))
            {
                var settingsManager = SettingsManager.Instance;
                var fileSettings = settingsManager.GetFileSettings(mainMenuToolbar.FilePath);

                fileSettings.FilterRegex = filterConfigForm.FilterText;
                fileSettings.ToTrimRegex = filterConfigForm.TrimToText;
                fileSettings.FromTrimRegex = filterConfigForm.TrimFromText;
                fileSettings.MiddleTrimRegex = filterConfigForm.TrimMiddleText;
                fileSettings.HighlightRegexMap = filterConfigForm.HighlightColorMap.EnumKeyToString();
                settingsManager.Save();

                EnableFilter(mainMenuToolbar.FilterEnabled);
                EnableTrim(mainMenuToolbar.TrimEnabled);
                EnableHighlight(mainMenuToolbar.HighlightEnabled);

                if (tailManager.IsRunning && mainMenuToolbar.PromptRefreshOnFilterChange)
                {
                    var message = "Refresh the file?\r\n\r\nAny filter or highlighting changes will not apply to existing lines, only new lines.";
                    if (MessageBox.Show(message, "Filter Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RefreshFile();
                    }
                }
            }
            else
            {
                SetupFilterConfigForm();
            }
        }
        
        private void FilterToggle()
        {
            mainMenuToolbar.FilterEnabled = !mainMenuToolbar.FilterEnabled;
            EnableFilter(mainMenuToolbar.FilterEnabled);
        }

        private void TrimToggle()
        {
            mainMenuToolbar.TrimEnabled = !mainMenuToolbar.TrimEnabled;
            EnableTrim(mainMenuToolbar.TrimEnabled);
        }

        private void HighlightToggle()
        {
            mainMenuToolbar.HighlightEnabled = !mainMenuToolbar.HighlightEnabled;
            EnableHighlight(mainMenuToolbar.HighlightEnabled);
        }

        private void EnableFilter(bool enable)
        {
            filterConfigForm.Filter?.SetEnabled(enable, false);
            logDisplay.SetFilterState(enable);
            CurrentFileSettings.EnableFilter = enable;
        }
        
        private void EnableTrim(bool enable)
        {
            filterConfigForm.Filter?.DownstreamMember?.DownstreamMember?.SetEnabled(enable);
            logDisplay.SetTrimState(enable);
            CurrentFileSettings.EnableTrim = enable;
        }

        private void EnableHighlight(bool enable)
        {
            filterConfigForm.Filter?.DownstreamMember?.SetEnabled(true, false); // always enabled so display can be toggled anytime
            logDisplay.SetHighlighState(enable);
            CurrentFileSettings.EnableHighlight = enable;
        }

        private void EditFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void SettingsUpdated()
        {
            var fileSettings = CurrentFileSettings;
            logDisplay.WordWrap = fileSettings.WordWrap;
            logDisplay.AutoScroll = fileSettings.AutoScroll;
            logDisplay.ShowLineNumbers = fileSettings.ShowLineNumbers;
            
            EnableFilter(fileSettings.EnableFilter);
            EnableTrim(fileSettings.EnableTrim);
            EnableHighlight(fileSettings.EnableHighlight);

            SettingsManager.Instance.Save();
        }

        private void RefreshFile()
        {
            logDisplay.Clear();
            tailManager.StopTail();
            tailManager.StartTail();
        }
        
        private bool IsDemo
        {
            get { return tailManager is DemoTailManager; }
        }

        private string StartDemo()
        {
            if (IsDemo)
            {
                return null;
            }

            var message = "Demo mode will generate a log file automatically and tail it.  Do you want to continue?";
            if (MessageBox.Show(message, "Demo Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return null;
            }

            tailManager.StopTail();
            tailManager.FormInterface.LoadLastLinesCallback = () => -1;
            tailManager = new DemoTailManager(tailManager);

            InitializeNewFile(tailManager.FormInterface.GetFileNameCallback());
            tailManager.StartTail(false, false);

            return tailManager.FormInterface.GetFileNameCallback();
        }

        private void ExceptionHandler(Exception ex)
        {
            if (ex is ThreadAbortException)
            {
                return;
            }

            var message = ex.Message;
            var title = "Unexpected Error";

            if (ex is FileNotFoundException)
            {
                message = string.Format("Could not find the file {0}", ((FileNotFoundException)ex).FileName);
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

            StopTail();
        }
        
        private void SetState(bool running)
        {
            mainMenuToolbar.SetState(running, IsDemo);
            logDisplay.SetState(running);

            this.Text = "AdvancedTail";

            if (!string.IsNullOrWhiteSpace(mainMenuToolbar.FilePath))
            {
                this.Text = Path.GetFileName(mainMenuToolbar.FilePath) + " - " + this.Text + 
                    (running ? " [Running]" : " [Stopped]");
            }
        }
    }
}
