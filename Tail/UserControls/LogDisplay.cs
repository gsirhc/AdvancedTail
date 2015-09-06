﻿namespace Tail.UserControls
{
    using System.Runtime.InteropServices;
    using Process;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using ScintillaNET;
    using System.Drawing;

    /// <summary>
    /// Wrapper control for displaying the file contents.
    /// </summary>
    public partial class LogDisplay : UserControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public event Action FilterToggle;
        public event Action TrimToggle;

        private const int LineNumberMarginIndex = 1;

        public LogDisplay()
        {
            InitializeComponent();

            scintilla.Margins[LineNumberMarginIndex].Type = MarginType.Text;
            scintilla.TextChanged += Scintilla_TextChanged;
            scintilla.ExtraAscent = 1;
            scintilla.ExtraDescent = 1;

            scintilla.Styles[Style.Default].Font = "Courier";
            scintilla.Styles[Style.Default].Size = 9;
        }
        
        public bool WordWrap
        {
            get { return scintilla.WrapMode != ScintillaNET.WrapMode.None; }
            set { scintilla.WrapMode = value ? ScintillaNET.WrapMode.Word : ScintillaNET.WrapMode.None;  }
        }

        private bool showLineNumbers = false;
        public bool ShowLineNumbers
        {
            get { return showLineNumbers; }
            set
            {
                showLineNumbers = value;
                if (showLineNumbers)
                {
                    scintilla.Margins[LineNumberMarginIndex].Width = 16;
                    UpdateLineNumberMarginSize();
                }
                else
                {
                    scintilla.Margins[LineNumberMarginIndex].Width = 0;
                }
            }
        }

        public void Clear()
        {
            scintilla.ClearAll();
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
                var location = scintilla.SearchInTarget(searchText);
                if (location == -1)
                {
                    MessageBox.Show("Not Found - searched passed end of document", "Search");
                }
            }
        }

        public void StartWrite(bool initialLoad)
        {
            this.Invoke(new Action(() =>
            {
                if (initialLoad)
                {
                    scintilla.Enabled = false;
                    scintilla.Refresh();
                }
                SendMessage(scintilla.Handle, WM_SETREDRAW, false, 0);
            }));
        }

        public void Write(IList<TailLine> lines, bool clearAll)
        {
            if (clearAll)
            {
                scintilla.ClearAll();
            }

            if (lines.Count > 0)
            {
                foreach (var tailLine in lines)
                {
                    this.Invoke(new Action(() =>
                    {
                        scintilla.AppendText(tailLine.Line + Environment.NewLine);
                        
                        scintilla.Lines[scintilla.Lines.Count - 2].MarginStyle = Style.LineNumber;
                        scintilla.Lines[scintilla.Lines.Count - 2].MarginText = tailLine.LineNumber.ToString();
                    }));
                }
            }
        }
        
        public void EndWrite(bool initialLoad, TailStatistics tailStatistics)
        {
            this.Invoke(new Action(() =>
            {
                if (initialLoad)
                {
                    scintilla.Enabled = true;
                    toolStripStatusLabelStatus.Text = "Following";
                }

                SendMessage(scintilla.Handle, WM_SETREDRAW, true, 0);

                if (initialLoad || (tailStatistics.LastRead > 0))
                {
                    scintilla.Refresh();
                    
                    if (AutoScroll && scintilla.Enabled)
                    {
                        scintilla.SelectionStart = scintilla.Text.Length;
                        scintilla.ScrollCaret();
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

        private int maxLineNumberCharLength;
        private void Scintilla_TextChanged(object sender, EventArgs e)
        {
            if (!ShowLineNumbers)
            {
                return;
            }

            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            this.maxLineNumberCharLength = maxLineNumberCharLength;
            UpdateLineNumberMarginSize();
        }

        private void UpdateLineNumberMarginSize()
        {
            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            scintilla.Margins[LineNumberMarginIndex].Width = scintilla.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 2)) + padding;
        }
    }
}
