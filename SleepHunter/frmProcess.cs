using ProcessMemory;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter
{
    public class frmProcess : Form
    {
        private IContainer components;
        private Panel pnlProcess;
        private ImageList ilsIcons;
        private ToolStrip toolStrip1;
        private ToolStripButton btnRefresh;
        public ListView lvwProcess;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmProcess));
            ListViewGroup listViewGroup1 = new ListViewGroup("System Processes", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("User Processes", HorizontalAlignment.Left);
            ListViewGroup listViewGroup3 = new ListViewGroup("Dark Ages Processes", HorizontalAlignment.Left);
            this.ilsIcons = new ImageList(this.components);
            this.pnlProcess = new Panel();
            this.lvwProcess = new ListView();
            this.toolStrip1 = new ToolStrip();
            this.btnRefresh = new ToolStripButton();
            this.pnlProcess.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            this.ilsIcons.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("ilsIcons.ImageStream");
            this.ilsIcons.Images.SetKeyName(0, "da-Main.ico");
            this.pnlProcess.Controls.Add((Control)this.lvwProcess);
            this.pnlProcess.Controls.Add((Control)this.toolStrip1);
            this.pnlProcess.Dock = DockStyle.Fill;
            this.pnlProcess.Location = new Point(0, 0);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Padding = new Padding(5, 5, 4, 4);
            this.pnlProcess.Size = new Size(578, 121);
            this.pnlProcess.TabIndex = 2;
            this.pnlProcess.Paint += new PaintEventHandler(this.pnlProcess_Paint);
            this.lvwProcess.AllowDrop = true;
            this.lvwProcess.BorderStyle = BorderStyle.None;
            this.lvwProcess.Dock = DockStyle.Fill;
            listViewGroup1.Header = "System Processes";
            listViewGroup1.Name = "grpSystem";
            listViewGroup2.Header = "User Processes";
            listViewGroup2.Name = "grpUser";
            listViewGroup3.Header = "Dark Ages Processes";
            listViewGroup3.Name = "grpDA";
            this.lvwProcess.Groups.AddRange(new ListViewGroup[3]
            {
      listViewGroup1,
      listViewGroup2,
      listViewGroup3
            });
            this.lvwProcess.LargeImageList = this.ilsIcons;
            this.lvwProcess.Location = new Point(5, 30);
            this.lvwProcess.MultiSelect = false;
            this.lvwProcess.Name = "lvwProcess";
            this.lvwProcess.Size = new Size(569, 87);
            this.lvwProcess.TabIndex = 3;
            this.lvwProcess.View = View.Tile;
            this.lvwProcess.ItemDrag += new ItemDragEventHandler(this.lvwProcess_ItemDrag);
            this.toolStrip1.Items.AddRange(new ToolStripItem[1]
            {
      (ToolStripItem) this.btnRefresh
            });
            this.toolStrip1.Location = new Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(569, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.btnRefresh.Image = (Image)componentResourceManager.GetObject("btnRefresh.Image");
            this.btnRefresh.ImageScaling = ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = " Refresh Processes";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(578, 121);
            this.Controls.Add((Control)this.pnlProcess);
            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmProcess);
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Process Manager";
            this.Shown += new EventHandler(this.frmProcess_Shown);
            this.pnlProcess.ResumeLayout(false);
            this.pnlProcess.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public frmProcess() => this.InitializeComponent();

        private void GetProcesses()
        {
            Process[] processes = Process.GetProcesses();
            this.lvwProcess.Items.Clear();
            foreach (Process process in processes)
            {
                if (process.ProcessName.ToUpper() == "DARKAGES")
                {
                    string str = new MemoryReader((uint)process.Id).ReadString((IntPtr)7754528);
                    if (str.Trim() == "")
                        this.lvwProcess.Items.Add("DarkAges.exe", 0);
                    else
                        this.lvwProcess.Items.Add($"DarkAges.exe ({str})", 0);
                    this.lvwProcess.Items[this.lvwProcess.Items.Count - 1].Group = this.lvwProcess.Groups[2];
                    this.lvwProcess.Items[this.lvwProcess.Items.Count - 1].Tag = (object)process.Id;
                }
            }
            if (this.lvwProcess.Items.Count >= 1)
                return;
            Graphics graphics = Graphics.FromHwnd(this.lvwProcess.Handle);
            StringFormat format = new StringFormat(StringFormat.GenericDefault);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            this.lvwProcess.Refresh();
            graphics.DrawString("No Dark Ages Processes Running.", new Font("Tahoma", 10f, FontStyle.Bold), (Brush)new SolidBrush(SystemColors.ControlText), (RectangleF)this.lvwProcess.ClientRectangle, format);
        }

        private void lvwProcess_ItemDrag(object sender, ItemDragEventArgs e)
        {
            int num = (int)this.DoDragDrop((object)((ListViewItem)e.Item).Tag.ToString(), DragDropEffects.Copy);
        }

        private void pnlProcess_Paint(object sender, PaintEventArgs e)
        {
            Rectangle clientRectangle = this.pnlProcess.ClientRectangle;
            clientRectangle.Inflate(-4, -4);
            e.Graphics.DrawRectangle(new Pen(SystemColors.ControlDark), clientRectangle);
            if (this.lvwProcess.Items.Count >= 1)
                return;
            Graphics graphics = Graphics.FromHwnd(this.lvwProcess.Handle);
            this.lvwProcess.Refresh();
            graphics.DrawString("No Dark Ages Processes Running.", new Font("Tahoma", 10f, FontStyle.Bold), (Brush)new SolidBrush(SystemColors.ControlText), (RectangleF)this.lvwProcess.ClientRectangle, new StringFormat(StringFormat.GenericDefault)
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
        }

        private void frmProcess_Shown(object sender, EventArgs e) => this.GetProcesses();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.btnRefresh.Enabled = false;
            this.GetProcesses();
            this.btnRefresh.Enabled = true;
        }
    }
}