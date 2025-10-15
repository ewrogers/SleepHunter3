using ProcessMemory;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SleepHunter
{
    public partial class frmStatus : Form
    {
        private const int chatShowHeight = 415;
        private const int chatHideHeight = 187;

        private long m_HP;
        private long m_MP;
        private long m_MaxHP;
        private long m_MaxMP;
        private long m_XLoc;
        private long m_YLoc;
        private string m_MapLoc;
        private string m_CharName;
        private string m_ChatBuffer;
        private string m_Chat;
        private Color HPGradSoft = Color.FromArgb(byte.MaxValue, 100, 100);
        private Color HPGradHard = Color.FromArgb(150, 0, 0);
        private Color MPGradSoft = Color.FromArgb(100, 100, (int)byte.MaxValue);
        private Color MPGradHard = Color.FromArgb(0, 0, 150);
        private Color PrgBackColor = Color.White;
        private Color ShadingLight = SystemColors.ControlDark;
        private Color ShadingDark = SystemColors.ControlDarkDark;
        private Padding PrgPadding = new Padding(1, 1, 1, 1);
        private int BarWidth = 3;
        private int BarSpacing = 1;
        private MemoryReader memRead;

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
            float num = (float)Value / Max;
            if (num > 1.0)
                num = 1f;
            Rectangle rectangle = new Rectangle(rClient.X + 2 + padSides.Left, rClient.Y + 2 + padSides.Top, (int)((double)(rClient.Width - 5 - padSides.Left - padSides.Right) * num), rClient.Height - 5 - (padSides.Top + padSides.Bottom));
            if (IsRadialGradient)
                RadialGradient(rectangle, g, GradientA, GradientB);
            else
                g.FillRectangle(new LinearGradientBrush(rectangle, GradientA, GradientB, LinearGradient), rectangle);
            if (Smooth)
                return;
            for (int index = 1; index < rectangle.Width / (BarWidth + BarSpacing) + 1; ++index)
                g.FillRectangle(new SolidBrush(PrgBackColor), rectangle.Left + index * BarWidth + (index - 1) * BarSpacing, rectangle.Top, BarSpacing, rectangle.Height);
        }

        private void RadialGradient(Rectangle rFill, Graphics g, Color GradientA, Color GradientB)
        {
            Rectangle rect1 = new Rectangle(rFill.X, rFill.Y, rFill.Width, rFill.Height / 2);
            Rectangle rect2 = new Rectangle(rFill.X, rFill.Y + rFill.Height / 2, rFill.Width, rFill.Height / 2);
            g.FillRectangle(new LinearGradientBrush(rect1, GradientB, GradientA, LinearGradientMode.Vertical), rect1);
            g.FillRectangle(new LinearGradientBrush(rect2, GradientA, GradientB, LinearGradientMode.Vertical), rect2);
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
            if (BorderType.Equals(BorderStyle.None))
                return;
            g.DrawLine(new Pen(ShaderDark), rClient.Left, rClient.Top, rClient.Left + rClient.Width, rClient.Top);
            if (BorderType.Equals(BorderStyle.Fixed3D))
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
            e.Graphics.Clear(PrgBackColor);
            DrawProgress(e.Graphics, picHP.ClientRectangle, m_HP, 0L, m_MaxHP, BarWidth, BarSpacing, false, PrgPadding, HPGradSoft, HPGradHard, LinearGradientMode.Vertical, false);
            DrawBorder(e.Graphics, picHP.ClientRectangle, BorderStyle.Fixed3D, ShadingLight, ShadingDark);
        }

        private void picMP_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(PrgBackColor);
            DrawProgress(e.Graphics, picMP.ClientRectangle, m_MP, 0L, m_MaxMP, BarWidth, BarSpacing, false, PrgPadding, MPGradSoft, MPGradHard, LinearGradientMode.Vertical, false);
            DrawBorder(e.Graphics, picMP.ClientRectangle, BorderStyle.Fixed3D, ShadingLight, ShadingDark);
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (IsDisposed || memRead == null)
                return;
            if (!memRead.IsAttached | !memRead.IsRunning)
            {
                Text = "Process Lost! -- Re-Attach";
                m_HP = 0L;
                m_MaxHP = 0L;
                m_MaxMP = 0L;
                m_MP = 0L;
                m_XLoc = 0L;
                m_YLoc = 0L;
                m_MapLoc = null;
                m_CharName = null;
                tmrUpdate.Enabled = false;
            }
            else
            {
                m_CharName = memRead.ReadString((IntPtr)7754528);
                ulong num = memRead.ReadUInt32((IntPtr)8535904);
                m_HP = memRead.ReadInt32((IntPtr)((long)num + 19644L));
                m_MP = memRead.ReadInt32((IntPtr)((long)num + 19652L));
                m_MaxHP = memRead.ReadInt32((IntPtr)((long)num + 19648L));
                m_MaxMP = memRead.ReadInt32((IntPtr)((long)num + 19656L));
                m_MapLoc = memRead.ReadString((IntPtr)(memRead.ReadInt32((IntPtr)(memRead.ReadInt32((IntPtr)(memRead.ReadInt32((IntPtr)7153024) + 76)) + 108)) + 28));
                m_XLoc = memRead.ReadInt32((IntPtr)(memRead.ReadInt32((IntPtr)(memRead.ReadInt32((IntPtr)7327488) + 516)) + 44));
                m_YLoc = memRead.ReadInt32((IntPtr)(memRead.ReadInt32((IntPtr)(memRead.ReadInt32((IntPtr)7327488) + 516)) + 40));
                m_ChatBuffer = "Chat is currently disabled.";
            }
            if (m_CharName != null)
                Text = m_CharName + "'s Status";
            else
                Text = "Status Window";
            if (cbShowChat.Checked)
            {
                if (m_ChatBuffer != null)
                {
                    if (checkNewChat(m_ChatBuffer, m_Chat))
                    {
                        m_Chat = m_ChatBuffer;
                        rtbChatLog.Text = m_Chat.Replace('\n', ' ');
                        rtbChatLog.SelectionStart = rtbChatLog.Text.Length;
                    }
                }
                else
                {
                    rtbChatLog.Text = "Chat Text";
                }
            }
            decimal num1 = 0M;
            decimal num2 = 0M;
            try
            {
                num1 = Math.Round((decimal)m_HP / m_MaxHP * 100M, 2);
            }
            catch (DivideByZeroException)
            {
            }
            try
            {
                num2 = Math.Round((decimal)m_MP / m_MaxMP * 100M, 2);
            }
            catch (DivideByZeroException)
            {
            }
            lblHP.Text = $"{m_HP.ToString()} / {m_MaxHP.ToString()}";
            lblHPPercent.Text = num1 + " %";
            lblMP.Text = $"{m_MP.ToString()} / {m_MaxMP.ToString()}";
            lblMPPercent.Text = num2 + " %";
            lblMAP.Text = m_MapLoc;
            lblX.Text = m_XLoc.ToString();
            lblY.Text = m_YLoc.ToString();
            picHP.Refresh();
            picMP.Refresh();
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
            uint result;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text), out result))
                e.Effect = DragDropEffects.None;
            else if (result < 1U)
            {
                MessageBox.Show($"The process you have selected is invalid. (PID {result.ToString()})", "Invalid Process,", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                memRead = new MemoryReader(result);
                if (memRead.IsAttached)
                    tmrUpdate.Enabled = true;
                lblHelp.Visible = false;
            }
        }

        private bool checkNewChat(string curBuffer, string newBuffer) => !curBuffer.Equals(newBuffer);

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowChat.Checked)
            {
                Height = 415;
                rtbChatLog.Enabled = true;
            }
            else
            {
                Height = 187;
                rtbChatLog.Enabled = false;
            }
        }
    }
}