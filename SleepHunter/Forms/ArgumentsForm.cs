using System;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ArgumentsForm : Form
    {
        public string CommandName
        {
            get => commandNameLabel.Text;
            set => commandNameLabel.Text = value;
        }

        public string HelpText
        {
            get => helpTextLabel.Text;
            set => helpTextLabel.Text = value;
        }

        public ArgumentsForm()
        {
            InitializeComponent();
        }
    }
}