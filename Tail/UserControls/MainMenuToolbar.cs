﻿namespace Tail.UserControls
{
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System;
    using System.Windows.Forms;

    using Manager;
    using Predefined;
    using Settings;
    using Reader;

    /// <summary>
    /// The Main menu and toolbars control
    /// </summary>
    public partial class MainMenuToolbar : UserControl
    {
        public MainMenuToolbar()
        {
            InitializeComponent();

            increaseFontSizeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl++";
            decreaseFontSizeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+-";
            resetFontSizeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift++";

            SetupPredefinedMenu();
        }
        
        public event Action StartTail;
        public event Action StopTail;

        public event Action<string> SelectedFile;
        public event Action RefreshFile;
        public event Action ClearLog;
        public event Action<string> EditFile;

        public event Action SettingsUpdated;

        public event Action<PredefinedItem> EditFilter;

        public event Action IncreaseFont;
        public event Action DecreaseFont;
        public event Action ResetDefaultFont;

        public event Action<string> SearchNext;

        public event Func<string> StartDemo;

        public event Action Exit;

        public int LoadLastNLines
        {
            get
            {
                var lastLines = FileSettings.Default.LoadLastLines;
                this.Invoke(new Action(() =>
                {
                    if (allToolStripMenuItem.Checked)
                    {
                        lastLines = - 1;
                    }
                    else if (tenToolStripMenuItem2.Checked)
                    {
                        lastLines = 10;
                    }
                    else if (hundredToolStripMenuItem3.Checked)
                    {
                        lastLines = 100;
                    }
                    else if (thousandToolStripMenuItem4.Checked)
                    {
                        lastLines = 1000;
                    }
                }));

                return lastLines;
            }
            set
            {
                setLoadLastLinesState(value);
            }
        }

        public string FilePath
        {
            get { return textBoxFile.Text; }
            set { textBoxFile.Text = value; }
        }

        public bool FilterEnabled
        {
            get { return enableFilterToolStripMenuItem.Checked; }
            set { enableFilterToolStripMenuItem.Checked = value; }
        }

        public bool TrimEnabled
        {
            get { return enableTrimToolStripMenuItem.Checked; }
            set { enableTrimToolStripMenuItem.Checked = value; }
        }

        public bool HighlightEnabled
        {
            get { return enableHighlightingToolStripMenuItem.Checked; }
            set { enableHighlightingToolStripMenuItem.Checked = value; }
        }

        public bool PreviewPredefinedFilter
        {
            get { return previewPredefinedFilterToolStripMenuItem.Checked; }
            set { previewPredefinedFilterToolStripMenuItem.Checked = value; }
        }

        public bool PromptRefreshOnFilterChange
        {
            get { return promptForRefreshToolStripMenuItem.Checked; }
            set { promptForRefreshToolStripMenuItem.Checked = value; }
        }

        private FileSettings CurrentFileSettings => !string.IsNullOrEmpty(FilePath) ? SettingsManager.Instance.GetFileSettings(FilePath) : FileSettings.Default;

        public void Initialize()
        {
            runAtStartupToolStripMenuItem.Checked = SettingsManager.Instance.RunAtStartup;
            wordWrapToolStripMenuItem.Checked = CurrentFileSettings.WordWrap;
        }

        public void InitialFileSettings(FileSettings fileSettings)
        {
            enableFilterToolStripMenuItem.Checked = fileSettings.EnableFilter;
            enableTrimToolStripMenuItem.Checked = fileSettings.EnableTrim;
            enableHighlightingToolStripMenuItem.Checked = fileSettings.EnableHighlight;
            LoadLastNLines = fileSettings.LoadLastLines;
            autoScrollToolStripMenuItem.Checked = fileSettings.AutoScroll;
            showLineNumbersToolStripMenuItem.Checked = fileSettings.ShowLineNumbers;
        }

        private void SetupPredefinedMenu()
        {
            foreach (var folder in FilterConfiguration.AllDefaultFolders)
            {
                var folderItem = new ToolStripMenuItem(folder.Name);

                foreach (var predefinedItem in folder.Items)
                {
                    var item = new ToolStripMenuItem(predefinedItem.Name);
                    item.ToolTipText = predefinedItem.Description;
                    item.Click += (o, e) => { PredefinedItemClick(predefinedItem); };
                    folderItem.DropDownItems.Add(item);
                }

                predefinedFiltersHighlightToolStripMenuItem.DropDownItems.Add(folderItem);
            }
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
                enableFilterToolStripMenuItem.Enabled = false;
                enableTrimToolStripMenuItem.Enabled = false;
                enableHighlightingToolStripMenuItem.Enabled = false;
                toolStripButtonSearch.Enabled = toolStripTextBoxSearch.Enabled = false;
                return;
            }

            toolStripButtonFilter.Enabled = filterToolStripMenuItem.Enabled = true;
            enableFilterToolStripMenuItem.Enabled = true;
            enableHighlightingToolStripMenuItem.Enabled = true;
            enableTrimToolStripMenuItem.Enabled = true;
            toolStripButtonSearch.Enabled = toolStripTextBoxSearch.Enabled = true;
            openFileInEditorToolStripMenuItem.Enabled = !string.IsNullOrEmpty(FilePath);
            
            if (running && !allowSave && !string.IsNullOrEmpty(textFile))
            {
                SettingsManager.Instance.LastFile = textFile;
                CurrentFileSettings.LastUsed = DateTime.Now;
                CurrentFileSettings.LoadLastLines = LoadLastNLines;
                SettingsManager.Instance.Save();
            }

            toolStripButtonStart.Enabled = startToolStripMenuItem.Enabled = !running;

            toolStripButtonRefresh.Enabled = refreshToolStripMenuItem.Enabled = running;
            toolStripButtonClear.Enabled = clearDisplayToolStripMenuItem.Enabled = running;
            toolStripButtonStop.Enabled = stopToolStripMenuItem.Enabled = running;
            loadLastLinesToolStripMenuItem.Enabled = !running;

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
            var file = OpenFile("Open");

            if (file != null)
            {
                textBoxFile.Text = file;
                SelectedFile?.Invoke(file);
            }
        }

        private void openFileInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = OpenFile("Open in New Window");

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

        private string OpenFile(string title)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|(*.log)|*.log|All files (*.*)|*.*";
            openFileDialog.Title = title;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (!string.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(textBoxFile.Text);
            }

            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : (string)null;
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedFile?.Invoke(ReaderFactory.EventLogToFilePath("Application"));
        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedFile?.Invoke(ReaderFactory.EventLogToFilePath("System"));
        }

        private void securityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedFile?.Invoke(ReaderFactory.EventLogToFilePath("Security"));
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedFile?.Invoke(ReaderFactory.EventLogToFilePath("Setup"));
        }

        private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileSettings.AutoScroll = autoScrollToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void showLineNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileSettings.ShowLineNumbers = showLineNumbersToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void comboBoxLoadLast_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentFileSettings.LoadLastLines = LoadLastNLines;
            SettingsUpdated?.Invoke();
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            SearchNext?.Invoke(toolStripTextBoxSearch.TextBox.Text);
        }

        private void toolStripTextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Return)
            {
                SearchNext?.Invoke(toolStripTextBoxSearch.TextBox.Text);
                e.Handled = true;
            }
        }

        private void toolStripButtonFilter_Click(object sender, EventArgs e)
        {
            EditFilter?.Invoke(null);
        }

        private void PredefinedItemClick(PredefinedItem predefinedItem)
        {
            EditFilter?.Invoke(predefinedItem);
        }

        private void enableFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileSettings.EnableFilter = enableFilterToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void enableTrimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileSettings.EnableTrim = enableTrimToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void enableHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileSettings.EnableHighlight = enableHighlightingToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
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

        private void toolStripButtonFontUp_Click(object sender, EventArgs e)
        {
            IncreaseFont?.Invoke();
        }

        private void toolStripButtonFontDown_Click(object sender, EventArgs e)
        {
            DecreaseFont?.Invoke();
        }

        private void resetFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetDefaultFont?.Invoke();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileSettings.WordWrap = wordWrapToolStripMenuItem.Checked;
            SettingsUpdated?.Invoke();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            ClearLog?.Invoke();
        }

        private void recentFilesToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            recentFilesToolStripMenuItem.DropDownItems.Clear();
            foreach (var last in SettingsManager.Instance.GetLastUsedList(20))
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
            SettingsManager.Instance.RunAtStartup = runAtStartupToolStripMenuItem.Checked;
            SettingsManager.Instance.Save();
        }

        private void openFileInEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditFile?.Invoke(FilePath);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit?.Invoke();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog();
        }

        private void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = StartDemo?.Invoke();
            if (file != null)
            {
                textBoxFile.Text = file;
            }
        }

        private void helpDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gsirhc/AdvancedTail");
        }

        private void allLastLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLoadLastLinesState(-1);
        }

        private void tenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setLoadLastLinesState(10);
        }

        private void hundredToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            setLoadLastLinesState(100);
        }

        private void thousandToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            setLoadLastLinesState(1000);
        }

        private void setLoadLastLinesState(int loadLastLines)
        {
            tenToolStripMenuItem2.Checked = false;
            hundredToolStripMenuItem3.Checked = false;
            thousandToolStripMenuItem4.Checked = false;
            allToolStripMenuItem.Checked = false;

            if (loadLastLines == 10)
            {
                tenToolStripMenuItem2.Checked = true;
            }
            else if (loadLastLines == 100)
            {
                hundredToolStripMenuItem3.Checked = true;
            } 
            else if (loadLastLines == 100)
            {
                thousandToolStripMenuItem4.Checked = true;
            }
            else
            {
                allToolStripMenuItem.Checked = true;
            }
        }
    }
}
