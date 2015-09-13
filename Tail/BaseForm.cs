namespace Tail
{
    using System.Windows.Forms;

    /// <summary>
    /// Base form for all project forms
    /// </summary>
    public class BaseForm : Form
    {
        protected void ShowError(string title, string message, params object[] args)
        {
            MessageBox.Show(string.Format(message, args), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected bool Confirmation(string title, string message, params object[] args)
        {
            return MessageBox.Show(string.Format(message, args), title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }
}
