﻿namespace Tail
{
    using System.Runtime.InteropServices;
    using Process;
    using Filter;
    using System;
    using System.Diagnostics;
    using System.IO;
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
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private string initialFile = "";
        private FilterConfigForm filterConfigForm = new FilterConfigForm();
        private SettingsManager settingsManager = new SettingsManager();

        private ITailManager tailManager;

        public TailForm(string initialFile)
        {
            this.initialFile = string.IsNullOrEmpty(initialFile) ? settingsManager.LastFile : initialFile;
            InitializeComponent();
            InitializeTailManager();
        }

        private bool IsDemo
        {
            get { return tailManager is DemoTailManager; }
        }

        private void exceptionHandler(Exception ex)
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

        protected override void OnShown(EventArgs e)
        {
            runAtStartupToolStripMenuItem.Checked = Properties.Settings.Default.RunAtStartup;            
            InitializeNewFile(initialFile);

            base.OnShown(e);

            if (runAtStartupToolStripMenuItem.Checked)
            {
                this.tailManager.StartTail();
            }
        }

        private void InitializeNewFile(string file)
        {
            richTextBoxLog.Clear();
            textBoxFile.Text = file;

            filterConfigForm.FilterText = settingsManager.GetFileSettings(file).FilterRegex;
            filterConfigForm.TrimToText = settingsManager.GetFileSettings(file).ToTrimRegex;
            filterConfigForm.TrimFromText = settingsManager.GetFileSettings(file).FromTrimRegex;            

            SetState(false);
        }

        private void InitializeTailManager()
        {
            var serialFileReader = new CallbackSerialFileReader(StartReadCallback, UpdateDisplayCallback, FinishReadCallback);
            this.tailManager = new FileTailManager(serialFileReader)
            {
                ClearDisplayCallback = richTextBoxLog.Clear,
                ExceptionCallback = exceptionHandler,
                GetFileNameCallback = () => textBoxFile.Text,
                GetFilterCallback = () => filterConfigForm.Filter,
                SetStateCallback = SetState
            };
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.tailManager.StopTail();
            base.OnFormClosing(e);
        }

        private void openFileInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = OpenFile();

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "tail.exe";
            process.StartInfo.Arguments = file;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var file = OpenFile();

            textBoxFile.Text = file;
            InitializeNewFile(file);
            this.tailManager.StopTail();

            if (runAtStartupToolStripMenuItem.Checked)
            {
                this.tailManager.StartTail();
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

            return openFileDialog.ShowDialog() == DialogResult.OK ?
                openFileDialog.FileName : (string)null;
        }

        private void toolStripButtonFilter_Click(object sender, EventArgs e)
        {
            if (filterConfigForm.ShowDialog() == DialogResult.OK)
            {
                filterConfigForm.Filter?.SetEnabled(enableFilterToolStripMenuItem.Checked, false);
                filterConfigForm.Filter?.DownstreamMember?.SetEnabled(enableTrimToolStripMenuItem.Checked);

                if (!string.IsNullOrEmpty(textBoxFile.Text))
                {
                    settingsManager.GetFileSettings(textBoxFile.Text).FilterRegex = filterConfigForm.FilterText;
                    settingsManager.GetFileSettings(textBoxFile.Text).ToTrimRegex = filterConfigForm.TrimToText;
                    settingsManager.GetFileSettings(textBoxFile.Text).FromTrimRegex = filterConfigForm.TrimFromText;

                    settingsManager.Save();
                }
            }
        }
        
        private void toolStripButtonEnableFilter_Click(object sender, EventArgs e)
        {
            toolStripButtonEnableFilter.Checked = !toolStripButtonEnableFilter.Checked;
            enableFilterToolStripMenuItem.Checked = toolStripButtonEnableFilter.Checked;
            filterConfigForm.Filter?.SetEnabled(enableFilterToolStripMenuItem.Checked, false);
            toolStripButtonRefresh_Click(sender, e);
            toolStripStatusLabelFilter.Text = "Filter: " + (toolStripButtonEnableFilter.Checked ? "Enabled" : "Disabled");
        }

        private void toolStripButtonEnableTrim_Click(object sender, EventArgs e)
        {
            toolStripButtonEnableTrim.Checked = !toolStripButtonEnableTrim.Checked;
            enableTrimToolStripMenuItem.Checked = toolStripButtonEnableTrim.Checked;
            filterConfigForm.Filter?.DownstreamMember?.SetEnabled(enableTrimToolStripMenuItem.Checked);
            toolStripButtonRefresh_Click(sender, e);
            toolStripStatusLabelTrim.Text = "Trim: " + (toolStripButtonEnableTrim.Checked ? "Enabled" : "Disabled");
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            tailManager.StartTail();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            tailManager.StopTail();

            if (IsDemo)
            {
                InitializeTailManager();
                InitializeNewFile(settingsManager.LastFile);
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
            tailManager.StopTail();
            tailManager.StartTail();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxLog.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripTextBoxSearch.TextBox.Text))
            {
                var startPosition = 0;
                if (richTextBoxLog.SelectionLength > 0)
                {
                    startPosition = richTextBoxLog.SelectionStart + richTextBoxLog.SelectionLength;
                }

                var location = richTextBoxLog.Find(toolStripTextBoxSearch.TextBox.Text, startPosition, RichTextBoxFinds.None);
                if (location == -1)
                {
                    MessageBox.Show("Not Found - searched passed end of document", "Search");
                }
            }
        }

        private void runAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RunAtStartup = runAtStartupToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = string.Format("Advanced Tail \n Github: {0} \n License: WTFPL (Do What The F*** You Want To Public License) ",
                "https://github.com/gsirhc/AdvancedTail");
            MessageBox.Show(message, "About Tail");
        }

        private void StartReadCallback(bool initialLoad)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {   if (initialLoad)
                {
                    toolStripStatusLabelStatus.Text = "Reading...";
                    richTextBoxLog.Enabled = false;
                    richTextBoxLog.Refresh();
                }

                SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, false, 0);
            }));
        }

        private void UpdateDisplayCallback(string line, long lineNumber, bool clearAll)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                if (clearAll)
                {
                    richTextBoxLog.Clear();
                }

                if (showLineNumbersToolStripMenuItem.Checked)
                {
                    line = "[" + lineNumber.ToString().PadLeft(6) + "] " + line;
                }

                richTextBoxLog.AppendText(line);                
            }));
        }

        private void FinishReadCallback(bool initialLoad, long linesRead)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                if (initialLoad)
                {
                    toolStripStatusLabelStatus.Text = "Following";
                    richTextBoxLog.Enabled = true;
                }

                SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, true, 0);
                richTextBoxLog.Refresh();

                if (initialLoad || (linesRead > 0 && autoScrollToolStripMenuItem.Checked && richTextBoxLog.Enabled))
                {
                    richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                    richTextBoxLog.ScrollToCaret();
                }
            }));
        }
        
        private void SetState(bool running)
        {
            if (running && !IsDemo && !string.IsNullOrEmpty(textBoxFile.Text))
            {
                settingsManager.LastFile = textBoxFile.Text;
            }

            toolStripButtonStart.Enabled = startToolStripMenuItem.Enabled = !running;

            toolStripButtonRefresh.Enabled = refreshToolStripMenuItem.Enabled = running;
            toolStripButtonClear.Enabled = clearDisplayToolStripMenuItem.Enabled = running;
            toolStripButtonStop.Enabled = stopToolStripMenuItem.Enabled = running;

            this.Text = "Tail";

            if (!string.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                this.Text = Path.GetFileName(textBoxFile.Text) + " - " + this.Text;
            }

            if (running)
            {
                this.Text += " [Running]";
            }
            else
            {
                this.Text += " [Stopped]";
            }

            toolStripStatusLabelStatus.Text = running ? "Following" : "Paused";
        }

        private void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDemo)
            {
                return;
            }

            tailManager.StopTail();

            var message = "Demo mode will generate a log file automatically and tail it.  Do you want to continue?";
            if (MessageBox.Show(message, "Demo Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tailManager.StopTail();
                tailManager = new DemoTailManager(tailManager);

                textBoxFile.Text = tailManager.GetFileNameCallback();
                InitializeNewFile(tailManager.GetFileNameCallback());
                tailManager.StartTail(false, false);
            }
        }        
    }
}
