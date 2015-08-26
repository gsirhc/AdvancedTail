namespace Tail
{
    using System.Runtime.InteropServices;
    using Process;
    using Filter;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Main for displayed to the user.
    /// </summary>
    public partial class TailForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private TailThread tailThread;

        public TailForm()
        {
            InitializeComponent();
            tailThread = new TailThread(InitStartCallback, UpdateDisplayCallback, InitFinishCallback);
        }

        protected override void OnShown(EventArgs e)
        {
            textBoxFile.Text = Properties.Settings.Default.FilePath;
            textBoxFilter.Text = Properties.Settings.Default.Filter;
            textBoxTrimTo.Text = Properties.Settings.Default.TrimTo;
            textBoxTrimFrom.Text = Properties.Settings.Default.TrimFrom;
            checkBoxRunAtStartup.Checked = Properties.Settings.Default.RunAtStartup;

            base.OnShown(e);

            if (Properties.Settings.Default.RunAtStartup)
            {
                StartTail();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopTail();
            base.OnFormClosing(e);
        }

        private void buttonTailFile_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
            StartTail();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopTail();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
        }

        private void checkBoxWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxLog.WordWrap = checkBoxWordWrap.Checked;
        }

        private void checkBoxEnableFilter_CheckedChanged(object sender, EventArgs e)
        {
            tailThread.Filter?.SetEnabled(checkBoxEnableFilter.Checked, false);
        }

        private void checkBoxEnableTrim_CheckedChanged(object sender, EventArgs e)
        {
            tailThread.Filter?.DownstreamMember.SetEnabled(checkBoxEnableTrim.Checked);
        }

        private void checkBoxRunAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RunAtStartup = checkBoxRunAtStartup.Checked;
            Properties.Settings.Default.Save();
        }

        private void InitStartCallback()
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                richTextBoxLog.Enabled = false;
                richTextBoxLog.Refresh();
                SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, false, 0);
            }));
        }

        private void UpdateDisplayCallback(string data)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                richTextBoxLog.AppendText(data);
                if (checkBoxAutoScroll.Checked && richTextBoxLog.Enabled)
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
                richTextBoxLog.Enabled = true;
                SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, true, 0);
                richTextBoxLog.Refresh();
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.ScrollToCaret();
            }));
        }

        private void StartTail()
        {
            if (tailThread != null)
            {
                StopTail();
            }

            Properties.Settings.Default.FilePath = textBoxFile.Text;
            Properties.Settings.Default.Filter = textBoxFilter.Text;
            Properties.Settings.Default.TrimTo = textBoxTrimTo.Text;
            Properties.Settings.Default.TrimFrom = textBoxTrimFrom.Text;
            Properties.Settings.Default.Save();

            buttonTailFile.Enabled = false;
            buttonStop.Enabled = true;
            buttonRefresh.Enabled = true;

            try
            {
                tailThread.Filter = new FileLineRegexFilter(textBoxFilter.Text)
                {
                    EnableFilter = checkBoxEnableFilter.Checked,
                    DownstreamMember = TrimProcessorFactory.CreateProcessor(textBoxTrimTo.Text, textBoxTrimFrom.Text)
                };

                tailThread.Filter.DownstreamMember.SetEnabled(checkBoxEnableTrim.Checked);

                tailThread.Start(textBoxFile.Text, textBoxFilter.Text, textBoxTrimTo.Text, textBoxTrimFrom.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopTail()
        {
            buttonTailFile.Enabled = true;
            buttonStop.Enabled = false;
            buttonRefresh.Enabled = false;

            tailThread.Stop();
        }
    }
}
