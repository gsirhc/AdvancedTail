namespace Tail.UserControls
{
    using System.Runtime.InteropServices;
    using Process;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using ScintillaNET;
    using System.Drawing;
    using Filter;

    /// <summary>
    /// Wrapper control for displaying the file contents.
    /// </summary>
    public partial class LogDisplay : UserControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        // Indicators 0-7 could be in use by a lexer
        // so we'll use indicator 8 to highlight words.
        const int INDICATOR_NUM = 8;

        public event Action FilterToggle;
        public event Action TrimToggle;
        public event Action HighlightToggle;

        private const int LineNumberMarginIndex = 1;

        public LogDisplay()
        {
            InitializeComponent();

            scintilla.Margins[LineNumberMarginIndex].Type = MarginType.Text;
            scintilla.Styles[Style.LineNumber].ForeColor = Color.Gray;

            scintilla.TextChanged += Scintilla_TextChanged;
            scintilla.ExtraAscent = 1;
            scintilla.ExtraDescent = 1;
            
            scintilla.Styles[Style.Default].Font = "Courier New";
            scintilla.Styles[Style.Default].Size = 10;

            SetHighlightColors();

            // Update indicator appearance
            scintilla.Indicators[INDICATOR_NUM].Style = IndicatorStyle.StraightBox;
            scintilla.Indicators[INDICATOR_NUM].Under = true;
            scintilla.Indicators[INDICATOR_NUM].ForeColor = Color.Black;
            scintilla.Indicators[INDICATOR_NUM].OutlineAlpha = 90;
            scintilla.Indicators[INDICATOR_NUM].Alpha = 70;
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

        public void IncreaseFont()
        {
            if (scintilla.Styles[Style.Default].Size <= 24)
            {
                scintilla.Styles[Style.Default].Size++;
            }
        }

        public void DecreaseFont()
        {
            if (scintilla.Styles[Style.Default].Size >= 6)
            {
                scintilla.Styles[Style.Default].Size--;
            }
        }

        public void ResetDefaultFont()
        {
            scintilla.Styles[Style.Default].Size = 10;
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

        public void SetHighlighState(bool enabled)
        {
            toolStripStatusLabelHighlight.Text = "Highlight: " + (enabled ? "Enabled" : "Disabled");
            SetHighlightColors(!enabled);
        }

        public void Search(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                // Remove all uses of our indicator
                scintilla.IndicatorCurrent = INDICATOR_NUM;
                scintilla.IndicatorClearRange(0, scintilla.TextLength);
                scintilla.TargetEnd = scintilla.TextLength;

                var location = scintilla.SearchInTarget(searchText);
                if (location != -1)
                {
                    scintilla.IndicatorFillRange(scintilla.TargetStart, scintilla.TargetEnd - scintilla.TargetStart);
                    scintilla.GotoPosition(scintilla.TargetEnd);
                    scintilla.ScrollCaret();

                    scintilla.TargetStart = scintilla.TargetEnd;
                }
                else
                {
                    MessageBox.Show("Not Found - searched passed end of document", "Search");
                    scintilla.TargetStart = 0;
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
                this.UseWaitCursor = true;
                SendMessage(scintilla.Handle, WM_SETREDRAW, false, 0);
            }));
        }

        public void Write(IList<TailLine> lines, bool clearAll)
        {
            if (clearAll)
            {
                this.Invoke(new Action(() =>
                {
                    scintilla.ClearAll();
                }));
            }

            if (lines.Count > 0)
            {
                foreach (var tailLine in lines)
                {
                    this.Invoke(new Action(() =>
                    {
                        scintilla.AppendText(tailLine.Line + Environment.NewLine);
                        var lastLineIndex = scintilla.Lines.Count - 2;

                        if (tailLine.ColorIndex != HighlightColor.ColorIndex.None)
                        {
                            scintilla.StartStyling(scintilla.Lines[lastLineIndex].Position);
                            scintilla.SetStyling(scintilla.Lines[lastLineIndex].EndPosition - scintilla.Lines[lastLineIndex].Position, (int)tailLine.ColorIndex);
                        }

                        scintilla.Lines[lastLineIndex].MarginStyle = Style.LineNumber;
                        scintilla.Lines[lastLineIndex].MarginText = tailLine.LineNumber.ToString();
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
                    if (AutoScroll && scintilla.Enabled)
                    {
                        scintilla.SelectionStart = scintilla.Text.Length;
                        scintilla.ScrollCaret();
                    }

                    scintilla.Refresh();

                    var now = DateTime.Now;
                    toolStripStatusLabelRead.Text = string.Format("Updated: {0} (Read {1})", now.ToString("G"), tailStatistics.LastRead);
                    toolStripStatusLabelTotalLines.Text = "Total: " + tailStatistics.Total;
                    toolStripStatusLabelLinesDisplayed.Text = "Displayed: " + tailStatistics.Displayed;
                    toolStripStatusLabelLinesIgnored.Text = "Ignored: " + tailStatistics.Ignored;
                }

                this.UseWaitCursor = false;
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

        private void toolStripStatusLabelHighlight_Click(object sender, EventArgs e)
        {
            HighlightToggle?.Invoke();
        }

        private int maxLineNumberCharLength;
        private void Scintilla_TextChanged(object sender, EventArgs e)
        {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            this.maxLineNumberCharLength = maxLineNumberCharLength;

            if (ShowLineNumbers)
            {
                UpdateLineNumberMarginSize();
            }            
        }

        private void UpdateLineNumberMarginSize()
        {
            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            scintilla.Margins[LineNumberMarginIndex].Width = scintilla.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 3)) + padding;
        }

        private void SetHighlightColors(bool removeColors = false)
        {
            scintilla.Styles[(int)HighlightColor.ColorIndex.Red].BackColor = removeColors ? HighlightColor.DefaultBackground : HighlightColor.RedBackground;
            scintilla.Styles[(int)HighlightColor.ColorIndex.Red].ForeColor = removeColors ? HighlightColor.DefaultForeGround : HighlightColor.RedForeground;

            scintilla.Styles[(int)HighlightColor.ColorIndex.Yellow].BackColor = removeColors ? HighlightColor.DefaultBackground : HighlightColor.YellowBackground;
            scintilla.Styles[(int)HighlightColor.ColorIndex.Yellow].ForeColor = removeColors ? HighlightColor.DefaultForeGround : HighlightColor.YellowForeground;

            scintilla.Styles[(int)HighlightColor.ColorIndex.Green].BackColor = removeColors ? HighlightColor.DefaultBackground : HighlightColor.GreenBackground;
            scintilla.Styles[(int)HighlightColor.ColorIndex.Green].ForeColor = removeColors ? HighlightColor.DefaultForeGround : HighlightColor.GreenForeground;

            scintilla.Styles[(int)HighlightColor.ColorIndex.Blue].BackColor = removeColors ? HighlightColor.DefaultBackground : HighlightColor.BlueBackground;
            scintilla.Styles[(int)HighlightColor.ColorIndex.Blue].ForeColor = removeColors ? HighlightColor.DefaultForeGround : HighlightColor.BlueForeground;

            scintilla.Styles[(int)HighlightColor.ColorIndex.Gray].BackColor = removeColors ? HighlightColor.DefaultBackground : HighlightColor.GrayBackground;
            scintilla.Styles[(int)HighlightColor.ColorIndex.Gray].ForeColor = removeColors ? HighlightColor.DefaultForeGround : HighlightColor.GrayForeground;

            scintilla.Styles[(int)HighlightColor.ColorIndex.Subtle].BackColor = removeColors ? HighlightColor.DefaultBackground : HighlightColor.SubtleBackground;
            scintilla.Styles[(int)HighlightColor.ColorIndex.Subtle].ForeColor = removeColors ? HighlightColor.DefaultForeGround : HighlightColor.SubtleForeground;
        }
    }
}
