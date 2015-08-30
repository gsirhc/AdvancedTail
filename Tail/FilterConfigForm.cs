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
            SetFilter();
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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFilter.Text = "";
            textBoxTrimTo.Text = "";
            textBoxTrimFrom.Text = "";
            SetFilter();
        }

        private void SetFilter()
        {
            Filter = new FileLineRegexFilter(textBoxFilter.Text)
            {
                DownstreamMember = TrimProcessorFactory.CreateProcessor(textBoxTrimTo.Text, textBoxTrimFrom.Text)
            };
        }
    }
}
