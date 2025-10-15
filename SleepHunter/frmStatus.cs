using ProcessMemory;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SleepHunter
{
    public class frmStatus : Form
    {
        private const int chatShowHeight = 415;
        private const int chatHideHeight = 187;
        private IContainer components = (IContainer)null;
        private PictureBox picHP;
        private Label lblHPCaption;
        private PictureBox picMP;
        private Label lblMPCaption;
        private Label lblMAPCaption;
        private Label lblXCaption;
        private Label lblYCaption;
        private Timer tmrUpdate;
        private Label lblHP;
        private Label lblMP;
        private Label lblHPPercent;
        private Label lblMPPercent;
        private Label lblMAP;
        private Label lblX;
        private Label lblY;
        private Label lblHelp;
        private RichTextBox rtbChatLog;
        private CheckBox cbShowChat;
        private long m_HP = 0;
        private long m_MP = 0;
        private long m_MaxHP = 0;
        private long m_MaxMP = 0;
        private long m_XLoc = 0;
        private long m_YLoc = 0;
        private string m_MapLoc = (string)null;
        private string m_CharName = (string)null;
        private string m_ChatBuffer = (string)null;
        private string m_Chat = (string)null;
        private Color HPGradSoft = Color.FromArgb((int)byte.MaxValue, 100, 100);
        private Color HPGradHard = Color.FromArgb(150, 0, 0);
        private Color MPGradSoft = Color.FromArgb(100, 100, (int)byte.MaxValue);
        private Color MPGradHard = Color.FromArgb(0, 0, 150);
        private Color PrgBackColor = Color.White;
        private Color ShadingLight = SystemColors.ControlDark;
        private Color ShadingDark = SystemColors.ControlDarkDark;
        private Padding PrgPadding = new Padding(1, 1, 1, 1);
        private int BarWidth = 3;
        private int BarSpacing = 1;
        private MemoryReader memRead = (MemoryReader)null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmStatus));
            this.picHP = new PictureBox();
            this.lblHPCaption = new Label();
            this.picMP = new PictureBox();
            this.lblMPCaption = new Label();
            this.lblMAPCaption = new Label();
            this.lblXCaption = new Label();
            this.lblYCaption = new Label();
            this.tmrUpdate = new Timer(this.components);
            this.lblHP = new Label();
            this.lblMP = new Label();
            this.lblHPPercent = new Label();
            this.lblMPPercent = new Label();
            this.lblMAP = new Label();
            this.lblX = new Label();
            this.lblY = new Label();
            this.lblHelp = new Label();
            this.rtbChatLog = new RichTextBox();
            this.cbShowChat = new CheckBox();
            ((ISupportInitialize)this.picHP).BeginInit();
            ((ISupportInitialize)this.picMP).BeginInit();
            this.SuspendLayout();
            this.picHP.BackColor = SystemColors.Control;
            this.picHP.Location = new Point(13, 25);
            this.picHP.Name = "picHP";
            this.picHP.Size = new Size(271, 17);
            this.picHP.TabIndex = 0;
            this.picHP.TabStop = false;
            this.picHP.Paint += new PaintEventHandler(this.picHP_Paint);
            this.lblHPCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblHPCaption.ForeColor = Color.FromArgb(192 /*0xC0*/, 0, 0);
            this.lblHPCaption.Location = new Point(12, 9);
            this.lblHPCaption.Name = "lblHPCaption";
            this.lblHPCaption.Size = new Size(25, 12);
            this.lblHPCaption.TabIndex = 1;
            this.lblHPCaption.Text = "HP:";
            this.picMP.Location = new Point(12, 67);
            this.picMP.Name = "picMP";
            this.picMP.Size = new Size(271, 17);
            this.picMP.TabIndex = 2;
            this.picMP.TabStop = false;
            this.picMP.Paint += new PaintEventHandler(this.picMP_Paint);
            this.lblMPCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblMPCaption.ForeColor = Color.FromArgb(0, 0, 192 /*0xC0*/);
            this.lblMPCaption.Location = new Point(12, 52);
            this.lblMPCaption.Name = "lblMPCaption";
            this.lblMPCaption.Size = new Size(27, 12);
            this.lblMPCaption.TabIndex = 3;
            this.lblMPCaption.Text = "MP:";
            this.lblMAPCaption.Image = (Image)componentResourceManager.GetObject("lblMAPCaption.Image");
            this.lblMAPCaption.ImageAlign = ContentAlignment.MiddleLeft;
            this.lblMAPCaption.Location = new Point(11, 87);
            this.lblMAPCaption.Name = "lblMAPCaption";
            this.lblMAPCaption.Size = new Size(56, 23);
            this.lblMAPCaption.TabIndex = 5;
            this.lblMAPCaption.Text = "       MAP:";
            this.lblMAPCaption.TextAlign = ContentAlignment.MiddleLeft;
            this.lblXCaption.Image = (Image)componentResourceManager.GetObject("lblXCaption.Image");
            this.lblXCaption.ImageAlign = ContentAlignment.MiddleLeft;
            this.lblXCaption.Location = new Point(11, 110);
            this.lblXCaption.Name = "lblXCaption";
            this.lblXCaption.Size = new Size(56, 22);
            this.lblXCaption.TabIndex = 6;
            this.lblXCaption.Text = "       X:";
            this.lblXCaption.TextAlign = ContentAlignment.MiddleLeft;
            this.lblYCaption.Image = (Image)componentResourceManager.GetObject("lblYCaption.Image");
            this.lblYCaption.ImageAlign = ContentAlignment.MiddleLeft;
            this.lblYCaption.Location = new Point(10, 132);
            this.lblYCaption.Name = "lblYCaption";
            this.lblYCaption.Size = new Size(57, 22);
            this.lblYCaption.TabIndex = 7;
            this.lblYCaption.Text = "       Y:";
            this.lblYCaption.TextAlign = ContentAlignment.MiddleLeft;
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new EventHandler(this.tmrUpdate_Tick);
            this.lblHP.Location = new Point(39, 9);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new Size(174, 13);
            this.lblHP.TabIndex = 8;
            this.lblHP.Text = "0/0";
            this.lblHP.TextAlign = ContentAlignment.MiddleRight;
            this.lblMP.ForeColor = SystemColors.ControlText;
            this.lblMP.Location = new Point(39, 51);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new Size(174, 13);
            this.lblMP.TabIndex = 9;
            this.lblMP.Text = "0/0";
            this.lblMP.TextAlign = ContentAlignment.MiddleRight;
            this.lblHPPercent.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblHPPercent.Location = new Point(220, 9);
            this.lblHPPercent.Name = "lblHPPercent";
            this.lblHPPercent.Size = new Size(63 /*0x3F*/, 13);
            this.lblHPPercent.TabIndex = 10;
            this.lblHPPercent.TextAlign = ContentAlignment.MiddleRight;
            this.lblMPPercent.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblMPPercent.Location = new Point(221, 51);
            this.lblMPPercent.Name = "lblMPPercent";
            this.lblMPPercent.Size = new Size(63 /*0x3F*/, 13);
            this.lblMPPercent.TabIndex = 11;
            this.lblMPPercent.TextAlign = ContentAlignment.MiddleRight;
            this.lblMAP.AutoSize = true;
            this.lblMAP.ForeColor = SystemColors.ControlText;
            this.lblMAP.Location = new Point(73, 92);
            this.lblMAP.Name = "lblMAP";
            this.lblMAP.Size = new Size(22, 13);
            this.lblMAP.TabIndex = 12;
            this.lblMAP.Text = "???";
            this.lblMAP.TextAlign = ContentAlignment.MiddleLeft;
            this.lblX.AutoSize = true;
            this.lblX.ForeColor = SystemColors.ControlText;
            this.lblX.Location = new Point(73, 115);
            this.lblX.Name = "lblX";
            this.lblX.Size = new Size(22, 13);
            this.lblX.TabIndex = 13;
            this.lblX.Text = "???";
            this.lblX.TextAlign = ContentAlignment.MiddleLeft;
            this.lblY.AutoSize = true;
            this.lblY.ForeColor = SystemColors.ControlText;
            this.lblY.Location = new Point(73, 137);
            this.lblY.Name = "lblY";
            this.lblY.Size = new Size(22, 13);
            this.lblY.TabIndex = 14;
            this.lblY.Text = "???";
            this.lblY.TextAlign = ContentAlignment.MiddleLeft;
            this.lblHelp.ForeColor = SystemColors.GrayText;
            this.lblHelp.Location = new Point(98, 115);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new Size(186, 41);
            this.lblHelp.TabIndex = 15;
            this.lblHelp.Text = "Drag the Dark Ages process icon anywhere on this window to attach.";
            this.lblHelp.TextAlign = ContentAlignment.BottomRight;
            this.rtbChatLog.Enabled = false;
            this.rtbChatLog.Location = new Point(13, 175);
            this.rtbChatLog.Name = "rtbChatLog";
            this.rtbChatLog.Size = new Size(272, 199);
            this.rtbChatLog.TabIndex = 16 /*0x10*/;
            this.rtbChatLog.Text = "";
            this.cbShowChat.AutoSize = true;
            this.cbShowChat.Enabled = false;
            this.cbShowChat.ForeColor = SystemColors.Desktop;
            this.cbShowChat.Location = new Point(203, 110);
            this.cbShowChat.Name = "cbShowChat";
            this.cbShowChat.Size = new Size(84, 17);
            this.cbShowChat.TabIndex = 17;
            this.cbShowChat.Text = "Enable Chat";
            this.cbShowChat.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.AllowDrop = true;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(297, 162);
            this.Controls.Add((Control)this.cbShowChat);
            this.Controls.Add((Control)this.rtbChatLog);
            this.Controls.Add((Control)this.lblHelp);
            this.Controls.Add((Control)this.lblY);
            this.Controls.Add((Control)this.lblX);
            this.Controls.Add((Control)this.lblMAP);
            this.Controls.Add((Control)this.lblMPPercent);
            this.Controls.Add((Control)this.lblHPPercent);
            this.Controls.Add((Control)this.lblMP);
            this.Controls.Add((Control)this.lblHP);
            this.Controls.Add((Control)this.lblYCaption);
            this.Controls.Add((Control)this.lblXCaption);
            this.Controls.Add((Control)this.lblMAPCaption);
            this.Controls.Add((Control)this.lblMPCaption);
            this.Controls.Add((Control)this.picMP);
            this.Controls.Add((Control)this.lblHPCaption);
            this.Controls.Add((Control)this.picHP);
            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = nameof(frmStatus);
            this.Text = "Status Window";
            this.DragDrop += new DragEventHandler(this.frmStatus_DragDrop);
            this.DragEnter += new DragEventHandler(this.frmStatus_DragEnter);
            ((ISupportInitialize)this.picHP).EndInit();
            ((ISupportInitialize)this.picMP).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void DrawProgress(
          Graphics g,
          Rectangle rClient,
          long Value,
          long Min,
          long Max,
          int BarWidth,
          int BarSpacing,
          bool Smooth,
          Padding padSides,
          Color GradientA,
          Color GradientB,
          LinearGradientMode LinearGradient,
          bool IsRadialGradient)
        {
            if (Value == 0L)
                return;
            float num = (float)Value / (float)Max;
            if ((double)num > 1.0)
                num = 1f;
            Rectangle rectangle = new Rectangle(rClient.X + 2 + padSides.Left, rClient.Y + 2 + padSides.Top, (int)((double)(rClient.Width - 5 - padSides.Left - padSides.Right) * (double)num), rClient.Height - 5 - (padSides.Top + padSides.Bottom));
            if (IsRadialGradient)
                this.RadialGradient(rectangle, g, GradientA, GradientB);
            else
                g.FillRectangle((Brush)new LinearGradientBrush(rectangle, GradientA, GradientB, LinearGradient), rectangle);
            if (Smooth)
                return;
            for (int index = 1; index < rectangle.Width / (BarWidth + BarSpacing) + 1; ++index)
                g.FillRectangle((Brush)new SolidBrush(this.PrgBackColor), rectangle.Left + index * BarWidth + (index - 1) * BarSpacing, rectangle.Top, BarSpacing, rectangle.Height);
        }

        private void RadialGradient(Rectangle rFill, Graphics g, Color GradientA, Color GradientB)
        {
            Rectangle rect1 = new Rectangle(rFill.X, rFill.Y, rFill.Width, rFill.Height / 2);
            Rectangle rect2 = new Rectangle(rFill.X, rFill.Y + rFill.Height / 2, rFill.Width, rFill.Height / 2);
            g.FillRectangle((Brush)new LinearGradientBrush(rect1, GradientB, GradientA, LinearGradientMode.Vertical), rect1);
            g.FillRectangle((Brush)new LinearGradientBrush(rect2, GradientA, GradientB, LinearGradientMode.Vertical), rect2);
        }

        private void DrawBorder(
          Graphics g,
          Rectangle rClient,
          BorderStyle BorderType,
          Color ShaderLight,
          Color ShaderDark)
        {
            rClient.Inflate(-1, -1);
            rClient.Offset(-1, -1);
            if (BorderType.Equals((object)BorderStyle.None))
                return;
            g.DrawLine(new Pen(ShaderDark), rClient.Left, rClient.Top, rClient.Left + rClient.Width, rClient.Top);
            if (BorderType.Equals((object)BorderStyle.Fixed3D))
            {
                g.DrawLine(new Pen(ShaderLight), rClient.Left + rClient.Width, rClient.Top, rClient.Left + rClient.Width, rClient.Top + rClient.Height);
                g.DrawLine(new Pen(ShaderLight), rClient.Left + rClient.Width, rClient.Top + rClient.Height, rClient.Left, rClient.Top + rClient.Height);
            }
            else
            {
                g.DrawLine(new Pen(ShaderDark), rClient.Left + rClient.Width, rClient.Top, rClient.Left + rClient.Width, rClient.Top + rClient.Height);
                g.DrawLine(new Pen(ShaderDark), rClient.Left + rClient.Width, rClient.Top + rClient.Height, rClient.Left, rClient.Top + rClient.Height);
            }
            g.DrawLine(new Pen(ShaderDark), rClient.Left, rClient.Top + rClient.Height, rClient.Left, rClient.Top);
        }

        public frmStatus() => this.InitializeComponent();

        private void picHP_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.PrgBackColor);
            this.DrawProgress(e.Graphics, this.picHP.ClientRectangle, this.m_HP, 0L, this.m_MaxHP, this.BarWidth, this.BarSpacing, false, this.PrgPadding, this.HPGradSoft, this.HPGradHard, LinearGradientMode.Vertical, false);
            this.DrawBorder(e.Graphics, this.picHP.ClientRectangle, BorderStyle.Fixed3D, this.ShadingLight, this.ShadingDark);
        }

        private void picMP_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.PrgBackColor);
            this.DrawProgress(e.Graphics, this.picMP.ClientRectangle, this.m_MP, 0L, this.m_MaxMP, this.BarWidth, this.BarSpacing, false, this.PrgPadding, this.MPGradSoft, this.MPGradHard, LinearGradientMode.Vertical, false);
            this.DrawBorder(e.Graphics, this.picMP.ClientRectangle, BorderStyle.Fixed3D, this.ShadingLight, this.ShadingDark);
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed || this.memRead == null)
                return;
            if (!this.memRead.IsAttached | !this.memRead.IsRunning)
            {
                this.Text = "Process Lost! -- Re-Attach";
                this.m_HP = 0L;
                this.m_MaxHP = 0L;
                this.m_MaxMP = 0L;
                this.m_MP = 0L;
                this.m_XLoc = 0L;
                this.m_YLoc = 0L;
                this.m_MapLoc = (string)null;
                this.m_CharName = (string)null;
                this.tmrUpdate.Enabled = false;
            }
            else
            {
                this.m_CharName = this.memRead.ReadString((IntPtr)7754528);
                ulong num = (ulong)this.memRead.ReadUInt32((IntPtr)8535904);
                this.m_HP = (long)this.memRead.ReadInt32((IntPtr)((long)num + 19644L));
                this.m_MP = (long)this.memRead.ReadInt32((IntPtr)((long)num + 19652L));
                this.m_MaxHP = (long)this.memRead.ReadInt32((IntPtr)((long)num + 19648L));
                this.m_MaxMP = (long)this.memRead.ReadInt32((IntPtr)((long)num + 19656L));
                this.m_MapLoc = this.memRead.ReadString((IntPtr)(this.memRead.ReadInt32((IntPtr)(this.memRead.ReadInt32((IntPtr)(this.memRead.ReadInt32((IntPtr)7153024) + 76)) + 108)) + 28));
                this.m_XLoc = (long)this.memRead.ReadInt32((IntPtr)(this.memRead.ReadInt32((IntPtr)(this.memRead.ReadInt32((IntPtr)7327488) + 516)) + 44));
                this.m_YLoc = (long)this.memRead.ReadInt32((IntPtr)(this.memRead.ReadInt32((IntPtr)(this.memRead.ReadInt32((IntPtr)7327488) + 516)) + 40));
                this.m_ChatBuffer = "Chat is currently disabled.";
            }
            if (this.m_CharName != null)
                this.Text = this.m_CharName + "'s Status";
            else
                this.Text = "Status Window";
            if (this.cbShowChat.Checked)
            {
                if (this.m_ChatBuffer != null)
                {
                    if (this.checkNewChat(this.m_ChatBuffer, this.m_Chat))
                    {
                        this.m_Chat = this.m_ChatBuffer;
                        this.rtbChatLog.Text = this.m_Chat.Replace('\n', ' ');
                        this.rtbChatLog.SelectionStart = this.rtbChatLog.Text.Length;
                    }
                }
                else
                    this.rtbChatLog.Text = "Chat Text";
            }
            Decimal num1 = 0M;
            Decimal num2 = 0M;
            try
            {
                num1 = Math.Round((Decimal)this.m_HP / (Decimal)this.m_MaxHP * 100M, 2);
            }
            catch (DivideByZeroException)
            {
            }
            try
            {
                num2 = Math.Round((Decimal)this.m_MP / (Decimal)this.m_MaxMP * 100M, 2);
            }
            catch (DivideByZeroException)
            {
            }
            this.lblHP.Text = $"{this.m_HP.ToString()} / {this.m_MaxHP.ToString()}";
            this.lblHPPercent.Text = num1.ToString() + " %";
            this.lblMP.Text = $"{this.m_MP.ToString()} / {this.m_MaxMP.ToString()}";
            this.lblMPPercent.Text = num2.ToString() + " %";
            this.lblMAP.Text = this.m_MapLoc.ToString();
            this.lblX.Text = this.m_XLoc.ToString();
            this.lblY.Text = this.m_YLoc.ToString();
            this.picHP.Refresh();
            this.picMP.Refresh();
        }

        private void frmStatus_DragEnter(object sender, DragEventArgs e)
        {
            uint result = 0;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text), out result))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void frmStatus_DragDrop(object sender, DragEventArgs e)
        {
            uint result = 0;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text), out result))
                e.Effect = DragDropEffects.None;
            else if (result < 1U)
            {
                int num = (int)MessageBox.Show($"The process you have selected is invalid. (PID {result.ToString()})", "Invalid Process,", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.memRead = new MemoryReader(result);
                if (this.memRead.IsAttached)
                    this.tmrUpdate.Enabled = true;
                this.lblHelp.Visible = false;
            }
        }

        private bool checkNewChat(string curBuffer, string newBuffer) => !curBuffer.Equals(newBuffer);

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbShowChat.Checked)
            {
                this.Height = 415;
                this.rtbChatLog.Enabled = true;
            }
            else
            {
                this.Height = 187;
                this.rtbChatLog.Enabled = false;
            }
        }
    }
}