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
    using Filter;

    public partial class FilterConfigForm : Form
    {
        public FilterConfigForm()
        {
            InitializeComponent();
            AcceptButton = buttonOk;
        }

        public ILineFilter Filter => new FileLineRegexFilter(textBoxFilter.Text)
        {
            DownstreamMember = TrimProcessorFactory.CreateProcessor(textBoxTrimTo.Text, textBoxTrimFrom.Text)
        };

        public string FilterText
        {
            get { return textBoxFilter.Text; }
            set { textBoxFilter.Text = value; }
        }

        public string TrimToText
        {
            get { return textBoxTrimTo.Text; }
            set { textBoxTrimTo.Text = value; }
        }

        public string TrimFromText
        {
            get { return textBoxTrimFrom.Text; }
            set { textBoxTrimFrom.Text = value; }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFilter.Text = "";
            textBoxTrimTo.Text = "";
            textBoxTrimFrom.Text = "";
        }        
    }
}
