namespace Tail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Manager;
    using Predefined;

    public partial class SaveFilterPromptForm : BaseForm
    {
        private PredefinedItem filterItem;
        
        public SaveFilterPromptForm(PredefinedItem filterItem)
        {
            InitializeComponent();

            this.filterItem = filterItem;
            textBoxFilterName.Enabled = string.IsNullOrEmpty(filterItem.Name);

            textBoxFilterName.Text = filterItem.Name;
            textBoxDescription.Text = filterItem.Description;
                        
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFilterName.Text))
            {
                ShowError("Name Required", "Please enter a filter name.");
                return;
            }

            if (textBoxFilterName.Enabled)
            {
                var existing = SettingsManager.Instance.UserFilterConfigs.Items.Where(i => i.Name == textBoxFilterName.Text);
                if (existing.Any())
                {
                    ShowError("Name Already Exists", "An item by the name {0} already exists.  Continue?", textBoxFilterName.Text);
                    return;
                }

                filterItem.Name = textBoxFilterName.Text;
                filterItem.Description = textBoxDescription.Text;

                SettingsManager.Instance.UserFilterConfigs.Items.Add(filterItem);
            }
            else
            {
                var index = SettingsManager.Instance.UserFilterConfigs.Items.FindIndex(i => i.Name == textBoxFilterName.Text);
                if (index == -1)
                {
                    ShowError("Fatal Error", "Could not find the configuration to save.  Press Cancel to continue.");
                    return;
                }

                SettingsManager.Instance.UserFilterConfigs.Items[index] = this.filterItem;
            }
            
            SettingsManager.Instance.Save();

            DialogResult = DialogResult.OK; ;
            this.Close();
        }
    }
}
