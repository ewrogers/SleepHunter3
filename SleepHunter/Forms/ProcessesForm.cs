using ProcessMemory;
using SleepHunter.Interop.Windows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ProcessesForm : Form
    {
        private readonly IWindowEnumerator _windowEnumerator;

        public ProcessesForm() => InitializeComponent();

        private void GetProcesses()
        {
            Process[] processes = Process.GetProcesses();
            lvwProcess.Items.Clear();
            foreach (Process process in processes)
            {
                if (process.ProcessName.ToUpper() == "DARKAGES")
                {
                    string str = new MemoryReader((uint)process.Id).ReadString((IntPtr)7754528);
                    if (str.Trim() == "")
                        lvwProcess.Items.Add("DarkAges.exe", 0);
                    else
                        lvwProcess.Items.Add($"DarkAges.exe ({str})", 0);
                    lvwProcess.Items[lvwProcess.Items.Count - 1].Group = lvwProcess.Groups[2];
                    lvwProcess.Items[lvwProcess.Items.Count - 1].Tag = process.Id;
                }
            }
            if (lvwProcess.Items.Count >= 1)
                return;
            Graphics graphics = Graphics.FromHwnd(lvwProcess.Handle);
            StringFormat format = new StringFormat(StringFormat.GenericDefault);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            lvwProcess.Refresh();
            graphics.DrawString("No Dark Ages Processes Running.", new Font("Tahoma", 10f, FontStyle.Bold), new SolidBrush(SystemColors.ControlText), lvwProcess.ClientRectangle, format);
        }

        private void lvwProcess_ItemDrag(object sender, ItemDragEventArgs e)
        {
            int num = (int)DoDragDrop(((ListViewItem)e.Item).Tag.ToString(), DragDropEffects.Copy);
        }

        private void pnlProcess_Paint(object sender, PaintEventArgs e)
        {
            Rectangle clientRectangle = pnlProcess.ClientRectangle;
            clientRectangle.Inflate(-4, -4);
            e.Graphics.DrawRectangle(new Pen(SystemColors.ControlDark), clientRectangle);
            if (lvwProcess.Items.Count >= 1)
                return;
            Graphics graphics = Graphics.FromHwnd(lvwProcess.Handle);
            lvwProcess.Refresh();
            graphics.DrawString("No Dark Ages Processes Running.", new Font("Tahoma", 10f, FontStyle.Bold), new SolidBrush(SystemColors.ControlText), lvwProcess.ClientRectangle, new StringFormat(StringFormat.GenericDefault)
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
        }

        private void frmProcess_Shown(object sender, EventArgs e) => GetProcesses();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            GetProcesses();
            btnRefresh.Enabled = true;
        }
    }
}