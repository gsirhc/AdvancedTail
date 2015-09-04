namespace Tail.UserControls
{
    using System.Runtime.InteropServices;
    using Process;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Wrapper control for displaying the file contents.
    /// </summary>
    public partial class LogDisplay : UserControl
    {
        //[DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        //private const int WM_SETREDRAW = 11;

        public event Action FilterToggle;
        public event Action TrimToggle;

        public LogDisplay()
        {
            InitializeComponent();
        }

        public bool WordWrap
        {
            get { return richTextBoxLog.WordWrap; }
            set { richTextBoxLog.WordWrap = value;  }
        }

        public bool ShowLineNumbers { get; set; }

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

                //SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, false, 0);
            }));
        }

        public void Write(IList<TailLine> lines, bool clearAll)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                if (clearAll)
                {
                    richTextBoxLog.Clear();
                }

                if (lines.Count > 0)
                {
                    var stringBuilder = new StringBuilder();
                    foreach (var tailLine in lines)
                    {
                        var formattedLine = tailLine.Line;
                        if (ShowLineNumbers)
                        {
                            formattedLine = "[" + tailLine.LineNumber.ToString().PadLeft(6) + "] " + formattedLine;
                        }

                        stringBuilder.Append(formattedLine);
                    }
                    
                    richTextBoxLog.AppendText(stringBuilder.ToString());
                }
            }));
        }

        public void EndWrite(bool initialLoad, TailStatistics tailStatistics)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                if (initialLoad)
                {
                    richTextBoxLog.Enabled = true;
                    toolStripStatusLabelStatus.Text = "Following";
                }

                //SendMessage(richTextBoxLog.Handle, WM_SETREDRAW, true, 0);

                if (initialLoad || (tailStatistics.LastRead > 0))
                {
                    //richTextBoxLog.Refresh();
                    if (AutoScroll && richTextBoxLog.Enabled && richTextBoxLog.SelectionStart < richTextBoxLog.Text.Length)
                    {
                        richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                        richTextBoxLog.ScrollToCaret();
                    }

                    var now = DateTime.Now;
                    toolStripStatusLabelRead.Text = string.Format("Updated: {0} (Read {1})", now.ToString("G"), tailStatistics.LastRead);
                    toolStripStatusLabelTotalLines.Text = "Total: " + tailStatistics.Total;
                    toolStripStatusLabelLinesDisplayed.Text = "Displayed: " + tailStatistics.Displayed;
                    toolStripStatusLabelLinesIgnored.Text = "Ignored: " + tailStatistics.Ignored;
                }                
            }));
        }

        private void toolStripStatusLabelFilter_Click(object sender, EventArgs e)
        {
            FilterToggle?.Invoke();
        }

        private void toolStripStatusLabelTrim_Click(object sender, EventArgs e)
        {
            TrimToggle?.Invoke();
        }
    }
}
