namespace Tail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Manager;
    using Predefined;

    public partial class SaveFilterPromptForm : Form
    {
        private PredefinedItem filterItem;

        public SaveFilterPromptForm(PredefinedItem filterItem)
        {
            InitializeComponent();

            this.filterItem = filterItem;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFilterName.Text))
            {
                ShowError("Please enter a filter name.", "Name Required");
                return;
            }

            var existing = SettingsManager.Instance.UserFilterConfigs.Items.Where(i => i.Name == textBoxFilterName.Text);
            if (existing.Any())
            {
                if (!Confirmation(string.Format("An item by the name {0} already exists.  Continue?", textBoxFilterName.Text), "Name Already Exists"))
                {
                    return;
                }
            }

            filterItem.Name = textBoxFilterName.Text;
            filterItem.Description = textBoxDescription.Text;

            SettingsManager.Instance.UserFilterConfigs.Items.Add(filterItem);
            SettingsManager.Instance.Save();

            DialogResult = DialogResult.OK; ;
            this.Close();
        }

        private void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Confirmation(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }
}
