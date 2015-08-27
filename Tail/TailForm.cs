namespace Tail
{
    using System.Runtime.InteropServices;
    using Process;
    using Filter;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Demo;

    /// <summary>
    /// Main for displayed to the user.
    /// </summary>
    public partial class TailForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private FilterConfigForm filterConfigForm = new FilterConfigForm();
        private TailThread tailThread;
        private ISerialFileReader serialFileReader;
        private DemoWriterThread demoThread;

        public TailForm()
        {
            InitializeComponent();
            serialFileReader = new CallbackSerialFileReader(InitStartCallback, UpdateDisplayCallback, InitFinishCallback);
            tailThread = new TailThread(serialFileReader);
        }

        protected override void OnShown(EventArgs e)
        {
            Init();

            base.OnShown(e);

            if (Properties.Settings.Default.RunAtStartup)
            {
                StartTail();
            }
        }

        private void Init()
        {
            richTextBoxLog.Clear();
            textBoxFile.Text = Properties.Settings.Default.FilePath;
            filterConfigForm.FilterText = Properties.Settings.Default.Filter;
            filterConfigForm.TrimToText = Properties.Settings.Default.TrimTo;
            filterConfigForm.TrimFromText = Properties.Settings.Default.TrimFrom;
            runAtStartupToolStripMenuItem.Checked = Properties.Settings.Default.RunAtStartup;

            SetState(false);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopTail(true);
            base.OnFormClosing(e);
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
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

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = openFileDialog.FileName;
                StopTail();

                if (runAtStartupToolStripMenuItem.Checked)
                {
                    StartTail();
                }
            }
        }

        private void toolStripButtonFilter_Click(object sender, EventArgs e)
        {
            if (filterConfigForm.ShowDialog() == DialogResult.OK)
            {
                serialFileReader.Filter = filterConfigForm.Filter;
            }
        }
        
        private void toolStripButtonEnableFilter_Click(object sender, EventArgs e)
        {
            toolStripButtonEnableFilter.Checked = !toolStripButtonEnableFilter.Checked;
            enableFilterToolStripMenuItem.Checked = toolStripButtonEnableFilter.Checked;
            serialFileReader.Filter?.SetEnabled(toolStripButtonEnableFilter.Checked, false);
            toolStripButtonRefresh_Click(sender, e);
            toolStripStatusLabelFilter.Text = "Filter: " + (toolStripButtonEnableFilter.Checked ? "Enabled" : "Disabled");
        }

        private void toolStripButtonEnableTrim_Click(object sender, EventArgs e)
        {
            toolStripButtonEnableTrim.Checked = !toolStripButtonEnableTrim.Checked;
            enableTrimToolStripMenuItem.Checked = toolStripButtonEnableTrim.Checked;
            serialFileReader.Filter?.DownstreamMember?.SetEnabled(toolStripButtonEnableTrim.Checked);
            toolStripButtonRefresh_Click(sender, e);
            toolStripStatusLabelTrim.Text = "Trim: " + (toolStripButtonEnableTrim.Checked ? "Enabled" : "Disabled");
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            StartTail();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            StopTail();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
            tailThread.Stop();
            tailThread.Start(textBoxFile.Text);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxLog.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
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

        private void InitStartCallback()
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                toolStripStatusLabelStatus.Text = "Reading...";
                richTextBoxLog.Enabled = false;
                richTextBoxLog.Refresh();
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
                if (autoScrollToolStripMenuItem.Checked && richTextBoxLog.Enabled)
                {
                    richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                    richTextBoxLog.ScrollToCaret();
                }
            }));
        }

        private void InitFinishCallback()
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                toolStripStatusLabelStatus.Text = "Following";
                richTextBoxLog.Enabled = true;
                SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, true, 0);
                richTextBoxLog.Refresh();
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.ScrollToCaret();
            }));
        }

        private void StartTail(bool save = true, bool stop = true)
        {
            richTextBoxLog.Clear();

            if (stop && tailThread != null)
            {
                StopTail();
            }
            try
            {
                serialFileReader.Filter = filterConfigForm.Filter;

                if (save)
                {
                    Properties.Settings.Default.FilePath = textBoxFile.Text;

                    if (serialFileReader.Filter != null)
                    {
                        Properties.Settings.Default.Filter = filterConfigForm.FilterText;
                        Properties.Settings.Default.TrimTo = filterConfigForm.TrimToText;
                        Properties.Settings.Default.TrimFrom = filterConfigForm.TrimFromText;
                    }

                    Properties.Settings.Default.Save();
                }

                tailThread.Start(textBoxFile.Text);

                SetState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopTail(bool formClosing = false)
        {
            if (demoThread != null)
            {
                if (!formClosing)
                {
                    if (MessageBox.Show("Do you want to stop the demo?", "Stop Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        demoThread.Stop();
                        Init();
                        demoThread = null;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    demoThread.Stop();
                }
            }

            tailThread.Stop();
            SetState(false);
        }

        private void SetState(bool running)
        {
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
            if (demoThread != null)
            {
                StopTail();
                return;
            }

            var message = "Demo mode will generate a log file automatically and tail it.  Do you want to continue?";
            if (MessageBox.Show(message, "Demo Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StopTail();

                demoThread = new DemoWriterThread();
                demoThread.Start();

                textBoxFile.Text = demoThread.DemoFile;
                StartTail(false, false);
            }
        }
    }
}
