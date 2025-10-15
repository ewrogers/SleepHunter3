using ProcessMemory;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SleepHunter
{
    public partial class frmStatus : Form
    {
        private const int chatShowHeight = 415;
        private const int chatHideHeight = 187;

        private long m_HP = 0;
        private long m_MP = 0;
        private long m_MaxHP = 0;
        private long m_MaxMP = 0;
        private long m_XLoc = 0;
        private long m_YLoc = 0;
        private string m_MapLoc = null;
        private string m_CharName = null;
        private string m_ChatBuffer = null;
        private string m_Chat = null;
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
        private MemoryReader memRead = null;

        public frmStatus()
        {
            InitializeComponent();
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
                this.m_MapLoc = null;
                this.m_CharName = null;
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
            decimal num1 = 0M;
            decimal num2 = 0M;
            try
            {
                num1 = Math.Round((decimal)this.m_HP / (decimal)this.m_MaxHP * 100M, 2);
            }
            catch (DivideByZeroException)
            {
            }
            try
            {
                num2 = Math.Round((decimal)this.m_MP / (decimal)this.m_MaxMP * 100M, 2);
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
                MessageBox.Show($"The process you have selected is invalid. (PID {result.ToString()})", "Invalid Process,", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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