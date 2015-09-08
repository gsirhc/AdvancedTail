namespace Tail
{
    using System.Runtime.InteropServices;
    using Process;
    using Filter;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using Demo;
    using Extensions;
    using Manager;
    using Settings;

    /// <summary>
    /// Main for displayed to the user.
    /// </summary>
    public partial class TailForm : Form
    {
        private string initialFile = "";        
        private SettingsManager settingsManager = new SettingsManager();
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
        
        private FileSettings CurrentFileSettings => !string.IsNullOrEmpty(mainMenuToolbar.FilePath) ?  settingsManager.GetFileSettings(mainMenuToolbar.FilePath) : FileSettings.Default;

        protected override void OnShown(EventArgs e)
        {
            SetState(false);
            base.OnShown(e);

            mainMenuToolbar.Initialize(settingsManager);
            
            InitializeTailManager();

            bool hasArgFile = !string.IsNullOrEmpty(initialFile);
            this.initialFile = hasArgFile ? initialFile : settingsManager.LastFile;

            if (!string.IsNullOrEmpty(this.initialFile))
            {
                InitializeNewFile(this.initialFile);

                if (settingsManager.RunAtStartup)
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
        }

        private void SetupFilterConfigForm()
        {
            var fileSettings = CurrentFileSettings;

            filterConfigForm.FilterText = fileSettings.FilterRegex;
            filterConfigForm.TrimToText = fileSettings.ToTrimRegex;
            filterConfigForm.TrimFromText = fileSettings.FromTrimRegex;
            filterConfigForm.HighlightColorMap =
                fileSettings.HighlightRegexMap.StringKeyToEnum<HighlightColor.ColorIndex, string>();

            EnableFilter(fileSettings.EnableFilter);
            EnableTrim(fileSettings.EnableTrim);
            EnableHighlight(fileSettings.EnableHighlight);
        }

        private void InitializeTailManager()
        {
            var serialFileReader = new CallbackFileReader()
            {
                StartCallback = logDisplay.StartWrite,
                UpdateCallback = logDisplay.Write,
                FinishCallback = logDisplay.EndWrite,
                ExceptionCallback = ExceptionHandler,
                LoadLastLines = mainMenuToolbar.LoadLastNLines,
                Filter = filterConfigForm.Filter
            };

            this.tailManager = new FileTailManager()
            {
                SerialFileReader = serialFileReader,
                ClearDisplayCallback = logDisplay.Clear,
                ExceptionCallback = ExceptionHandler,
                GetFileNameCallback = () => mainMenuToolbar.FilePath,
                GetFilterCallback = () => filterConfigForm.Filter,
                SetStateCallback = SetState
            };
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.tailManager?.StopTail();
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
                InitializeTailManager();
                InitializeNewFile(settingsManager.LastFile);
            }
        }

        private void EditFilter()
        {
            if (filterConfigForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(mainMenuToolbar.FilePath))
            {
                tailManager.SerialFileReader.Filter = filterConfigForm.Filter;

                settingsManager.GetFileSettings(mainMenuToolbar.FilePath).FilterRegex = filterConfigForm.FilterText;
                settingsManager.GetFileSettings(mainMenuToolbar.FilePath).ToTrimRegex = filterConfigForm.TrimToText;
                settingsManager.GetFileSettings(mainMenuToolbar.FilePath).FromTrimRegex = filterConfigForm.TrimFromText;
                settingsManager.GetFileSettings(mainMenuToolbar.FilePath).HighlightRegexMap = filterConfigForm.HighlightColorMap.EnumKeyToString();
                settingsManager.Save();

                tailManager.SerialFileReader.Filter = filterConfigForm.Filter;

                EnableFilter(mainMenuToolbar.FilterEnabled);
                EnableTrim(mainMenuToolbar.TrimEnabled);
                EnableHighlight(mainMenuToolbar.HighlightEnabled);
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

            tailManager.SerialFileReader.LoadLastLines = fileSettings.LoadLastLines;

            EnableFilter(fileSettings.EnableFilter);
            EnableTrim(fileSettings.EnableTrim);
            EnableHighlight(fileSettings.EnableHighlight);

            settingsManager.Save();
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
            tailManager.SerialFileReader.LoadLastLines = -1;
            tailManager = new DemoTailManager(tailManager);

            InitializeNewFile(tailManager.GetFileNameCallback());
            tailManager.StartTail(false, false);

            return tailManager.GetFileNameCallback();
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
