namespace Tail.UserControls
{
    using System.Runtime.InteropServices;
    using Process;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Wrapper control for displaying the file contents.
    /// </summary>
    public partial class LogDisplay : UserControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        
        public LogDisplay()
        {
            InitializeComponent();
        }

        public bool WordWrap
        {
            get { return richTextBoxLog.WordWrap; }
            set { richTextBoxLog.WordWrap = value;  }
        }

        public void Clear()
        {
            richTextBoxLog.Clear();
        }

        public void SetState(bool running)
        {
            toolStripStatusLabelStatus.Text = running ? "Following" : "Paused";
        }

        public void SetFilterState(bool enabled)
        {
            toolStripStatusLabelFilter.Text = "Filter: " + (enabled ? "Enabled" : "Disabled");
        }

        public void SetTrimState(bool enabled)
        {
            toolStripStatusLabelTrim.Text = "Trim: " + (enabled ? "Enabled" : "Disabled");
        }

        public void Search(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var startPosition = 0;
                if (richTextBoxLog.SelectionLength > 0)
                {
                    startPosition = richTextBoxLog.SelectionStart + richTextBoxLog.SelectionLength;
                }

                var location = richTextBoxLog.Find(searchText, startPosition, RichTextBoxFinds.None);
                if (location == -1)
                {
                    MessageBox.Show("Not Found - searched passed end of document", "Search");
                }
            }
        }

        public void StartWrite(bool initialLoad)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                if (initialLoad)
                {
                    richTextBoxLog.Enabled = false;
                    richTextBoxLog.Refresh();
                }

                SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, false, 0);
            }));
        }

        public void Write(string line, long lineNumber, bool showLineNumbers, bool clearAll)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                if (clearAll)
                {
                    richTextBoxLog.Clear();
                }

                if (showLineNumbers)
                {
                    line = "[" + lineNumber.ToString().PadLeft(6) + "] " + line;
                }

                richTextBoxLog.AppendText(line);
            }));
        }

        public void EndWrite(bool initialLoad, bool autoScroll, TailStatistics tailStatistics)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                if (initialLoad)
                {
                    richTextBoxLog.Enabled = true;
                    toolStripStatusLabelStatus.Text = "Following";
                }
                
                if (initialLoad || (tailStatistics.LastRead > 0))
                {
                    SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, true, 0);
                    richTextBoxLog.Refresh();
                    if (autoScroll && richTextBoxLog.Enabled)
                    {
                        richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                        richTextBoxLog.ScrollToCaret();
                    }
                }

                var now = DateTime.Now;
                toolStripStatusLabelRead.Text = string.Format("Updated: {0} (Read {1})", now.ToString("g"), tailStatistics.LastRead);
                toolStripStatusLabelTotalLines.Text = "Total: " + tailStatistics.Total;
                toolStripStatusLabelLinesDisplayed.Text = "Displayed: " + tailStatistics.Displayed;
                toolStripStatusLabelLinesIgnored.Text = "Ignored: " + tailStatistics.Ignored;
            }));
        }
    }
}
