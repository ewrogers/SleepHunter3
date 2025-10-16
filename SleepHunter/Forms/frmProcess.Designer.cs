using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class frmProcess : Form
    {
        private IContainer components = null;
        private Panel pnlProcess;
        private ImageList ilsIcons;
        private ToolStrip toolStrip1;
        private ToolStripButton btnRefresh;
        public ListView lvwProcess;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
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
            this.Name = "frmProcess";
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Process Manager";
            this.Shown += new EventHandler(this.frmProcess_Shown);
            this.pnlProcess.ResumeLayout(false);
            this.pnlProcess.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}