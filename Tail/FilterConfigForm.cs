using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tail
{
    using Extensions;
    using Filter;

    public partial class FilterConfigForm : Form
    {
        public FilterConfigForm()
        {
            InitializeComponent();
            AcceptButton = buttonOk;
            SetFilter();

            textBoxRedExample.BackColor = HighlightColor.Red;
            textBoxYellowExample.BackColor = HighlightColor.Yellow;
            textBoxGreenExample.BackColor = HighlightColor.Green;
            textBoxBlueExample.BackColor = HighlightColor.Blue;
            textBoxGrayExample.BackColor = HighlightColor.Gray;
        }
        
        public ILineFilter Filter { get; set; }

        public string FilterText
        {
            get { return textBoxFilter.Text; }
            set { textBoxFilter.Text = value; SetFilter(); }
        }

        public string TrimToText
        {
            get { return textBoxTrimTo.Text; }
            set { textBoxTrimTo.Text = value; SetFilter(); }
        }

        public string TrimFromText
        {
            get { return textBoxTrimFrom.Text; }
            set { textBoxTrimFrom.Text = value; SetFilter(); }
        }

        public IDictionary<HighlightColor.ColorIndex, string> HighlightColorMap
        {
            get 
            {
                return new Dictionary<HighlightColor.ColorIndex, string>
                {
                    { HighlightColor.ColorIndex.Red, textBoxRedRegex.Text },
                    { HighlightColor.ColorIndex.Yellow, textBoxYellowRegex.Text },
                    { HighlightColor.ColorIndex.Green, textBoxGreenRegex.Text },
                    { HighlightColor.ColorIndex.Blue, textBoxBlueRegex.Text },
                    { HighlightColor.ColorIndex.Gray, textBoxGrayRegex.Text }
                };
            }
            set
            {
                textBoxRedRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Red, "");
                textBoxYellowRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Yellow, "");
                textBoxGreenRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Green, "");
                textBoxBlueRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Blue, "");
                textBoxGrayRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Gray, "");
                SetFilter();
            }
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFilter.Text = "";
            textBoxTrimTo.Text = "";
            textBoxTrimFrom.Text = "";

            textBoxRedRegex.Text = "";
            textBoxYellowRegex.Text = "";
            textBoxGreenRegex.Text = "";
            textBoxBlueRegex.Text = "";
            textBoxGrayRegex.Text = "";

            SetFilter();
        }

        private void buttonLevelStarts_Click(object sender, EventArgs e)
        {
            textBoxRedRegex.Text = "^(ERROR)";
            textBoxYellowRegex.Text = "^(WARN|WARNING)";
            textBoxGreenRegex.Text = "^(INFO)";
            textBoxBlueRegex.Text = "^(DEBUG)";
            textBoxGrayRegex.Text = "^(TRACE)";
        }

        private void buttonLevelContains_Click(object sender, EventArgs e)
        {
            textBoxRedRegex.Text = "ERROR";
            textBoxYellowRegex.Text = "WARN|WARNING";
            textBoxGreenRegex.Text = "INFO";
            textBoxBlueRegex.Text = "DEBUG";
            textBoxGrayRegex.Text = "TRACE";
        }

        private void buttonNoHighlighting_Click(object sender, EventArgs e)
        {
            textBoxRedRegex.Text = 
            textBoxYellowRegex.Text = 
            textBoxGreenRegex.Text = 
            textBoxBlueRegex.Text = 
            textBoxGrayRegex.Text = "";
        }

        private void SetFilter()
        {
            Filter = new FileLineRegexFilter(textBoxFilter.Text)
            {
                DownstreamMember = new HighlightProcessor(HighlightColorMap)
            };

            Filter.DownstreamMember.DownstreamMember = TrimProcessorFactory.CreateProcessor(textBoxTrimTo.Text, textBoxTrimFrom.Text);
        }        
    }
}
