
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    internal partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void form_Load(object sender, System.EventArgs e)
        {
            var version = Application.ProductVersion;
            versionLabel.Text = version;
        }

        private void githubLabel_Click(object sender, System.EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/ewrogers/SleepHunter3") { UseShellExecute = true });
        }

        
    }
}