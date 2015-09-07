namespace Tail
{
    using System.Windows.Forms;
    using System.Reflection;
    using System.Diagnostics;

    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            
            labelVersion.Text = string.Format(labelVersion.Text, version);
        }

        private void linkClick(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }
    }
}
