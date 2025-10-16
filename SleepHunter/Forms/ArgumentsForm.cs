using System;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ArgumentsForm : Form
    {
        public string[] ArgInput;
        public bool CancelSelected;
        public int MinArgCount;

        public ArgumentsForm(string argsTitle, string argsCaption)
        {
            InitializeComponent();
            lblTitle.Text = argsTitle;
            lblCaption.Text = argsCaption;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            CancelSelected = true;
            ArgInput = null;
            Hide();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddCommand();
        }

        private void AddCommand()
        {
            string[] strArray = txtArgs.Text.Trim().Split(',');
            bool flag = false;
            foreach (string str in strArray)
            {
                if ((str == null || str.Trim() == "") && MinArgCount > 0)
                    flag = true;
            }
            if (strArray.Length != MinArgCount || flag)
            {
                lblInvalid.Visible = true;
            }
            else
            {
                CancelSelected = false;
                ArgInput = strArray;
                Hide();
            }
        }

        private void txtArgs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            e.Handled = true;
            e.SuppressKeyPress = true;
            AddCommand();
        }
    }
}