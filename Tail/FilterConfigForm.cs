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
    using Manager;
    using Predefined;

    public partial class FilterConfigForm : Form
    {       
        public FilterConfigForm()
        {
            InitializeComponent();
            AcceptButton = buttonOk;
            SetFilter();

            textBoxRedExample.BackColor = HighlightColor.RedBackground;
            textBoxRedExample.ForeColor = HighlightColor.RedForeground;

            textBoxYellowExample.BackColor = HighlightColor.YellowBackground;
            textBoxYellowExample.ForeColor = HighlightColor.YellowForeground;

            textBoxGreenExample.BackColor = HighlightColor.GreenBackground;
            textBoxGreenExample.ForeColor = HighlightColor.GreenForeground;

            textBoxBlueExample.BackColor = HighlightColor.BlueBackground;
            textBoxBlueExample.ForeColor = HighlightColor.BlueForeground;

            textBoxGrayExample.BackColor = HighlightColor.GrayBackground;
            textBoxGrayExample.ForeColor = HighlightColor.GrayForeground;

            textBoxSubtleExample.BackColor = HighlightColor.SubtleBackground;
            textBoxSubtleExample.ForeColor = HighlightColor.SubtleForeground;

            PopulatePredefinedControls();
        }

        private void PopulatePredefinedControls()
        {
            listBoxFilterFolders.Items.Clear();
            listBoxFilterItems.Items.Clear();
            labelFilterDescription.Text = "";

            foreach (var folder in FilterConfiguration.AllDefaultFolders)
            {
                listBoxFilterFolders.Items.Add(folder);
            }

            if (SettingsManager.Instance.UserFilterConfigs.Items.Count > 0)
            {
                listBoxFilterFolders.Items.Add(SettingsManager.Instance.UserFilterConfigs);
            }
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
                    { HighlightColor.ColorIndex.Gray, textBoxGrayRegex.Text },
                    { HighlightColor.ColorIndex.Subtle, textBoxSubtleRegex.Text }
                };
            }
            set
            {
                textBoxRedRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Red, "");
                textBoxYellowRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Yellow, "");
                textBoxGreenRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Green, "");
                textBoxBlueRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Blue, "");
                textBoxGrayRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Gray, "");
                textBoxSubtleRegex.Text = value.GetValueOrDefault(HighlightColor.ColorIndex.Subtle, "");
                SetFilter();
            }
        }

        private void listBoxFilterFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePredefinedFolder(listBoxFilterFolders, listBoxFilterItems, labelFilterDescription);
        }
        
        private void listBoxFilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePredefinedItems(listBoxFilterItems, listBoxFilterFolders, labelFilterDescription);
        }
        
        private void ChangePredefinedFolder(ListBox folderListBox, ListBox itemsListBox, Label descriptionLabel)
        {
            descriptionLabel.Text = "";
            itemsListBox.Items.Clear();
            var folder = (PredefinedFolder)folderListBox.SelectedItem;

            if (folder != null)
            {
                foreach (var predefinedItem in folder.Items)
                {
                    itemsListBox.Items.Add(predefinedItem);
                }
            }
        }

        private void ChangePredefinedItems(ListBox itemsListBox, ListBox folderListBox, Label descriptionLabel)
        {
            var item = (PredefinedItem)itemsListBox.SelectedItem;
            var folder = (PredefinedFolder)folderListBox.SelectedItem;
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.Description))
                {
                    descriptionLabel.Text = item.Description;
                }
                else if (folder.FolderType == PredefinedFolderType.User)
                {
                    descriptionLabel.Text = "User defined filter";
                }
                SetupPredefined(item, false);
            }
        }
        
        public void SetupPredefined(PredefinedItem predefinedItem, bool setFilter)
        {
            ClearForm(predefinedItem.ClearFilter, predefinedItem.ClearHighlight);

            foreach (var field in predefinedItem.Fields)
            {
                switch (field.Key)
                {
                    case FormField.Filter:
                        textBoxFilter.Text = field.Value;
                        break;
                    case FormField.TrimTo:
                        textBoxTrimTo.Text = field.Value;
                        break;
                    case FormField.TrimFrom:
                        textBoxTrimFrom.Text = field.Value;
                        break;
                    case FormField.Red:
                        textBoxRedRegex.Text = field.Value;
                        break;
                    case FormField.Yellow:
                        textBoxYellowRegex.Text = field.Value;
                        break;
                    case FormField.Green:
                        textBoxGreenRegex.Text = field.Value;
                        break;
                    case FormField.Blue:
                        textBoxBlueRegex.Text = field.Value;
                        break;
                    case FormField.Gray:
                        textBoxGrayRegex.Text = field.Value;
                        break;
                    case FormField.Subtle:
                        textBoxSubtleRegex.Text = field.Value;
                        break;
                }
            }

            if (setFilter)
            {
                SetFilter();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (SetFilter())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonSaveFilter_Click(object sender, EventArgs e)
        {
            var predefinedItem = new PredefinedItem
            {
                ClearFilter = true,
                ClearHighlight = true,
                Fields = new Dictionary<FormField, string>
                {
                    { FormField.Filter, textBoxFilter.Text },
                    { FormField.TrimTo, textBoxTrimTo.Text },
                    { FormField.TrimFrom, textBoxTrimFrom.Text },
                    { FormField.Red, textBoxRedRegex.Text },
                    { FormField.Yellow, textBoxRedRegex.Text },
                    { FormField.Green, textBoxGreenRegex.Text },
                    { FormField.Blue, textBoxBlueRegex.Text },
                    { FormField.Gray, textBoxGrayRegex.Text },
                    { FormField.Subtle, textBoxSubtleRegex.Text },
                }
            };

            var promptForm = new SaveFilterPromptForm(predefinedItem);
            if (promptForm.ShowDialog() == DialogResult.OK)
            {
                PopulatePredefinedControls();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        
        private bool SetFilter()
        {
            try
            {
                Filter = new FileLineRegexFilter(textBoxFilter.Text)
                {
                    DownstreamMember = new HighlightProcessor(HighlightColorMap)
                };

                Filter.DownstreamMember.DownstreamMember = TrimProcessorFactory.CreateProcessor(textBoxTrimTo.Text, textBoxTrimFrom.Text);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Error");
                return false;
            }
        }
        
        private void ClearForm(bool filter = true, bool highlight = true)
        {
            if (filter)
            {
                textBoxFilter.Text = "";
                textBoxTrimTo.Text = "";
                textBoxTrimFrom.Text = "";
            }

            if (highlight)
            {
                textBoxRedRegex.Text = "";
                textBoxYellowRegex.Text = "";
                textBoxGreenRegex.Text = "";
                textBoxBlueRegex.Text = "";
                textBoxGrayRegex.Text = "";
                textBoxSubtleRegex.Text = "";
            }

            SetFilter();
        }        
    }
}
