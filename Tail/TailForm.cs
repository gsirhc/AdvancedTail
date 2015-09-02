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
            mainMenuToolbar.EnableFilter += EnableFilter;
            mainMenuToolbar.EnableTrim += EnableTrim;

            mainMenuToolbar.RefreshFile += RefreshFile;
            mainMenuToolbar.SelectedFile += InitializeNewFile;
            mainMenuToolbar.SettingsUpdated += SettingsUpdated;
            mainMenuToolbar.ClearLog += logDisplay.Clear;

            mainMenuToolbar.SearchNext += logDisplay.Search;
            mainMenuToolbar.StartDemo += StartDemo;
            mainMenuToolbar.Exit += this.Close;
        }

        protected override void OnShown(EventArgs e)
        {
            SetState(false);
            base.OnShown(e);

            mainMenuToolbar.Initialize(settingsManager);

            //numericUpDownLoadLast.Value = settingsManager.LoadLastLines >= 0 ? settingsManager.LoadLastLines : 10;
            //checkBoxLoadAll.Checked = settingsManager.LoadLastLines == -1;

            InitializeTailManager();

            bool hasArgFile = !string.IsNullOrEmpty(initialFile);
            this.initialFile = hasArgFile ? initialFile : settingsManager.LastFile;

            if (!string.IsNullOrEmpty(this.initialFile))
            {
                InitializeNewFile(this.initialFile);

                if (hasArgFile && settingsManager.RunAtStartup)
                {
                    this.tailManager.StartTail();
                }
            }
        }

        private void InitializeNewFile(string file)
        {
            logDisplay.Clear();
            mainMenuToolbar.FilePath = file;

            filterConfigForm.FilterText = settingsManager.GetFileSettings(file).FilterRegex;
            filterConfigForm.TrimToText = settingsManager.GetFileSettings(file).ToTrimRegex;
            filterConfigForm.TrimFromText = settingsManager.GetFileSettings(file).FromTrimRegex;
            filterConfigForm.Filter?.SetEnabled(mainMenuToolbar.FilterEnabled, false);
            filterConfigForm.Filter?.DownstreamMember?.SetEnabled(mainMenuToolbar.TrimEnabled);

            SetState(false);
        }

        private void InitializeTailManager()
        {
            var serialFileReader = new CallbackSerialFileReader()
            {
                StartCallback = logDisplay.StartWrite,
                UpdateCallback = (l, n, c) => logDisplay.Write(l, n, settingsManager.ShowLineNumbers, c),
                FinishCallback = (i, t) => logDisplay.EndWrite(i, settingsManager.AutoScroll, t),
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
                settingsManager.Save();
            }
        }

        private void EnableFilter(bool enable)
        {
            filterConfigForm.Filter?.SetEnabled(enable, false);
            logDisplay.SetFilterState(enable);
        }

        private void EnableTrim(bool enable)
        {
            filterConfigForm.Filter?.DownstreamMember?.SetEnabled(enable);
            logDisplay.SetTrimState(enable);
        }

        private void SettingsUpdated()
        {
            logDisplay.WordWrap = settingsManager.WordWrap;
            logDisplay.AutoScroll = settingsManager.AutoScroll;
            tailManager.SerialFileReader.LoadLastLines = settingsManager.LoadLastLines;
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
        }
    }
}
