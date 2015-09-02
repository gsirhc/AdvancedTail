namespace Tail.UserControls
{
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System;
    using System.Windows.Forms;

    using Manager;

    /// <summary>
    /// The Main menu and toolbars control
    /// </summary>
    public partial class MainMenuToolbar : UserControl
    {
        private SettingsManager settingsManager;

        public MainMenuToolbar()
        {
            InitializeComponent();
        }

        public event Action StartTail;
        public event Action StopTail;

        public event Action<string> SelectedFile;
        public event Action RefreshFile;
        public event Action ClearLog;

        public event Action SettingsUpdated;

        public event Action EditFilter;
        public event Action<bool> EnableFilter;
        public event Action<bool> EnableTrim;

        public event Action<string> SearchNext;

        public event Func<string> StartDemo;

        public event Action Exit;

        public int LoadLastNLines
        {
            get { return checkBoxLoadAll.Checked ? -1 : (int)numericUpDownLoadLast.Value; }
        }

        public string FilePath
        {
            get { return textBoxFile.Text; }
            set { textBoxFile.Text = value; }
        }

        public bool FilterEnabled
        {
            get { return toolStripButtonEnableFilter.Checked; }
        }

        public bool TrimEnabled
        {
            get { return toolStripButtonEnableTrim.Checked; }
        }

        public void Initialize(SettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;

            runAtStartupToolStripMenuItem.Checked = settingsManager.RunAtStartup;
            wordWrapToolStripMenuItem.Checked = settingsManager.WordWrap;
        }

        public void SetState(bool running, bool allowSave)
        {
            var textFile = textBoxFile.Text;
            if (string.IsNullOrEmpty(textFile))
            {
                toolStripButtonStart.Enabled = startToolStripMenuItem.Enabled = false;
                toolStripButtonRefresh.Enabled = refreshToolStripMenuItem.Enabled = false;
                toolStripButtonClear.Enabled = clearDisplayToolStripMenuItem.Enabled = false;
                toolStripButtonStop.Enabled = stopToolStripMenuItem.Enabled = false;

                toolStripButtonFilter.Enabled = filterToolStripMenuItem.Enabled = false;
                toolStripButtonEnableFilter.Enabled = enableFilterToolStripMenuItem.Enabled = false;
                toolStripButtonEnableTrim.Enabled = enableTrimToolStripMenuItem.Enabled = false;
                toolStripButtonSearch.Enabled = toolStripTextBoxSearch.Enabled = false;
                return;
            }

            toolStripButtonFilter.Enabled = filterToolStripMenuItem.Enabled = true;
            toolStripButtonEnableFilter.Enabled = enableFilterToolStripMenuItem.Enabled = true;
            toolStripButtonEnableTrim.Enabled = enableTrimToolStripMenuItem.Enabled = true;
            toolStripButtonSearch.Enabled = toolStripTextBoxSearch.Enabled = true;

            if (running && !allowSave && !string.IsNullOrEmpty(textFile))
            {
                settingsManager.LastFile = textFile;
                settingsManager.GetFileSettings(textFile).LastUsed = DateTime.Now;
                settingsManager.LoadLastLines = LoadLastNLines;
                settingsManager.Save();
            }

            toolStripButtonStart.Enabled = startToolStripMenuItem.Enabled = !running;

            toolStripButtonRefresh.Enabled = refreshToolStripMenuItem.Enabled = running;
            toolStripButtonClear.Enabled = clearDisplayToolStripMenuItem.Enabled = running;
            toolStripButtonStop.Enabled = stopToolStripMenuItem.Enabled = running;

            this.Text = "AdvancedTail";

            if (!string.IsNullOrWhiteSpace(textFile))
            {
                this.Text = Path.GetFileName(textFile) + " - " + this.Text;
            }

            if (running)
            {
                this.Text += " [Running]";
            }
            else
            {
                this.Text += " [Stopped]";
            }
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var file = OpenFile();

            if (file != null)
            {
                textBoxFile.Text = file;
                SelectedFile?.Invoke(file);
            }
        }

        private void openFileInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = OpenFile();

            if (file != null)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = Assembly.GetExecutingAssembly().Location;
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(process.StartInfo.FileName);
                process.StartInfo.Arguments = file;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
        }

        private string OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|(*.log)|*.log|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (!string.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(textBoxFile.Text);
            }

            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : (string)null;
        }

        private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsManager.AutoScroll = autoScrollToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void showLineNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsManager.ShowLineNumbers = showLineNumbersToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void numericUpDownLoadLast_ValueChanged(object sender, EventArgs e)
        {
            if (!checkBoxLoadAll.Checked)
            {
                settingsManager.LoadLastLines = (int)numericUpDownLoadLast.Value;
                SettingsUpdated?.Invoke();
            }
        }

        private void checkBoxLoadAll_CheckedChanged(object sender, EventArgs e)
        {
            settingsManager.LoadLastLines = -1;
            SettingsUpdated?.Invoke();
            numericUpDownLoadLast.Enabled = !checkBoxLoadAll.Checked;
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            SearchNext?.Invoke(toolStripTextBoxSearch.TextBox.Text);
        }

        private void toolStripButtonFilter_Click(object sender, EventArgs e)
        {
            EditFilter?.Invoke();
            EnableFilter?.Invoke(enableFilterToolStripMenuItem.Checked);
            EnableTrim?.Invoke(enableTrimToolStripMenuItem.Checked);
        }

        private void toolStripButtonEnableFilter_Click(object sender, EventArgs e)
        {
            toolStripButtonEnableFilter.Checked = !toolStripButtonEnableFilter.Checked;
            enableFilterToolStripMenuItem.Checked = toolStripButtonEnableFilter.Checked;
            EnableFilter?.Invoke(enableFilterToolStripMenuItem.Checked);
        }

        private void toolStripButtonEnableTrim_Click(object sender, EventArgs e)
        {
            toolStripButtonEnableTrim.Checked = !toolStripButtonEnableTrim.Checked;
            enableTrimToolStripMenuItem.Checked = toolStripButtonEnableTrim.Checked;
            EnableTrim?.Invoke(enableTrimToolStripMenuItem.Checked);
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            StartTail?.Invoke();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            StopTail?.Invoke();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshFile?.Invoke();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsManager.WordWrap = wordWrapToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            ClearLog?.Invoke();
        }

        private void recentFilesToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            recentFilesToolStripMenuItem.DropDownItems.Clear();
            foreach (var last in settingsManager.GetLastUsedList(20))
            {
                if (!string.IsNullOrWhiteSpace(last))
                {
                    recentFilesToolStripMenuItem.DropDownItems.Add(last, null, RecentFilesToolStripMenuItem_ChildClick);
                }
            }
        }

        private void RecentFilesToolStripMenuItem_ChildClick(object sender, EventArgs e)
        {
            var file = sender?.ToString();
            if (!string.IsNullOrWhiteSpace(file))
            {
                SelectedFile?.Invoke(file);
            }
        }

        private void runAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsManager.RunAtStartup = runAtStartupToolStripMenuItem.Checked;
            settingsManager.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit?.Invoke();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = string.Format("Advanced Tail \n GitHub: {0} \n (see GitHub url above for licensing) ",
                "https://github.com/gsirhc/AdvancedTail");
            MessageBox.Show(message, "About Tail");
        }

        private void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = StartDemo?.Invoke();
            if (file != null)
            {
                textBoxFile.Text = file;
            }
        }
    }
}
