using ProcessMemory;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SleepHunter
{
    public class frmChat : Form
    {
        private IContainer components = (IContainer)null;
        private RichTextBox rtbChatLog;
        private Label label1;
        private System.Windows.Forms.Timer tmrUpdate;
        private Label lblHelp;
        private TextBox txtChatInput;
        private Label lblEnterTxt;
        private Button btnSendChat;
        private ComboBox cmbChatType;
        private ToolStrip toolStrip1;
        private ToolStripButton btnFloat;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDock;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnToggleTopmost;
        private TextBox txtWhisperTrgt;
        private Label lblWhisperTo;
        private string m_ChatBuffer = (string)null;
        private string m_Chat = (string)null;
        private string m_CharName = (string)null;
        private MemoryReader memReader = (MemoryReader)null;
        private Form myParent;
        private bool enableOnTop = false;
        private static int SPOKENMAX = 67;
        private static int GUILDMAX = 66;
        private static int WHISPERMAX = 64 /*0x40*/;
        private int charNameLength;
        private int maxChatLength;
        private int chatType = 0;
        private bool hasProcess = false;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmChat));
            this.rtbChatLog = new RichTextBox();
            this.label1 = new Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblHelp = new Label();
            this.btnFloat = new ToolStripButton();
            this.txtChatInput = new TextBox();
            this.lblEnterTxt = new Label();
            this.btnSendChat = new Button();
            this.cmbChatType = new ComboBox();
            this.toolStrip1 = new ToolStrip();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.btnDock = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.btnToggleTopmost = new ToolStripButton();
            this.txtWhisperTrgt = new TextBox();
            this.lblWhisperTo = new Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            this.rtbChatLog.Location = new Point(10, 37);
            this.rtbChatLog.Name = "rtbChatLog";
            this.rtbChatLog.ReadOnly = true;
            this.rtbChatLog.Size = new Size(419, 345);
            this.rtbChatLog.TabIndex = 0;
            this.rtbChatLog.Text = "";
            this.label1.BackColor = Color.Transparent;
            this.label1.ForeColor = SystemColors.GrayText;
            this.label1.Location = new Point(453, 25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(111, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chat will appear to the left when you attach a DA process.";
            this.label1.TextAlign = ContentAlignment.BottomRight;
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new EventHandler(this.tmrUpdate_Tick);
            this.lblHelp.Anchor = AnchorStyles.Top;
            this.lblHelp.ForeColor = SystemColors.GrayText;
            this.lblHelp.Location = new Point(431, 323);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new Size(133, 59);
            this.lblHelp.TabIndex = 16 /*0x10*/;
            this.lblHelp.Text = "Drag the Dark Ages process icon anywhere on this window to attach for reading.";
            this.lblHelp.TextAlign = ContentAlignment.BottomRight;
            this.btnFloat.Image = (Image)componentResourceManager.GetObject("btnFloat.Image");
            this.btnFloat.ImageTransparentColor = Color.Magenta;
            this.btnFloat.Name = "btnFloat";
            this.btnFloat.Size = new Size(92, 22);
            this.btnFloat.Text = "Float Window";
            this.btnFloat.Click += new EventHandler(this.btnFloat_Click);
            this.txtChatInput.Location = new Point(97, 403);
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new Size(418, 20);
            this.txtChatInput.TabIndex = 18;
            this.txtChatInput.KeyDown += new KeyEventHandler(this.txtChatInput_KeyDown);
            this.lblEnterTxt.AutoSize = true;
            this.lblEnterTxt.ForeColor = SystemColors.Desktop;
            this.lblEnterTxt.Location = new Point(8, 385);
            this.lblEnterTxt.Name = "lblEnterTxt";
            this.lblEnterTxt.Size = new Size(135, 13);
            this.lblEnterTxt.TabIndex = 19;
            this.lblEnterTxt.Text = "Enter Text To Send Below:";
            this.btnSendChat.Location = new Point(521, 403);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new Size(43, 20);
            this.btnSendChat.TabIndex = 20;
            this.btnSendChat.Text = "Send";
            this.btnSendChat.UseVisualStyleBackColor = true;
            this.btnSendChat.Click += new EventHandler(this.btnSendChat_Click);
            this.cmbChatType.FormattingEnabled = true;
            this.cmbChatType.Items.AddRange(new object[4]
            {
      (object) "Say",
      (object) "Whisper",
      (object) "Guild",
      (object) "Group"
            });
            this.cmbChatType.Location = new Point(11, 402);
            this.cmbChatType.Name = "cmbChatType";
            this.cmbChatType.Size = new Size(85, 21);
            this.cmbChatType.TabIndex = 21;
            this.cmbChatType.SelectedIndexChanged += new EventHandler(this.cmbChatType_SelectedIndexChanged);
            this.toolStrip1.Items.AddRange(new ToolStripItem[5]
            {
      (ToolStripItem) this.btnFloat,
      (ToolStripItem) this.toolStripSeparator1,
      (ToolStripItem) this.btnDock,
      (ToolStripItem) this.toolStripSeparator2,
      (ToolStripItem) this.btnToggleTopmost
            });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(568, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 25);
            this.btnDock.Enabled = false;
            this.btnDock.Image = (Image)componentResourceManager.GetObject("btnDock.Image");
            this.btnDock.ImageTransparentColor = Color.Magenta;
            this.btnDock.Name = "btnDock";
            this.btnDock.Size = new Size(91, 22);
            this.btnDock.Text = "Dock Window";
            this.btnDock.Click += new EventHandler(this.btnDock_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 25);
            this.btnToggleTopmost.Image = (Image)componentResourceManager.GetObject("btnToggleTopmost.Image");
            this.btnToggleTopmost.ImageTransparentColor = Color.Magenta;
            this.btnToggleTopmost.Name = "btnToggleTopmost";
            this.btnToggleTopmost.Size = new Size(122, 22);
            this.btnToggleTopmost.Text = "Toggle Stay On Top";
            this.btnToggleTopmost.Visible = false;
            this.btnToggleTopmost.Click += new EventHandler(this.btnToggleTopmost_Click);
            this.txtWhisperTrgt.Location = new Point(165, 427);
            this.txtWhisperTrgt.Name = "txtWhisperTrgt";
            this.txtWhisperTrgt.Size = new Size(153, 20);
            this.txtWhisperTrgt.TabIndex = 23;
            this.txtWhisperTrgt.Visible = false;
            this.lblWhisperTo.AutoSize = true;
            this.lblWhisperTo.ForeColor = SystemColors.Desktop;
            this.lblWhisperTo.Location = new Point(94, 430);
            this.lblWhisperTo.Name = "lblWhisperTo";
            this.lblWhisperTo.Size = new Size(65, 13);
            this.lblWhisperTo.TabIndex = 24;
            this.lblWhisperTo.Text = "Whisper To:";
            this.lblWhisperTo.TextAlign = ContentAlignment.BottomRight;
            this.lblWhisperTo.Visible = false;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(568, 452);
            this.Controls.Add((Control)this.lblWhisperTo);
            this.Controls.Add((Control)this.txtWhisperTrgt);
            this.Controls.Add((Control)this.toolStrip1);
            this.Controls.Add((Control)this.cmbChatType);
            this.Controls.Add((Control)this.btnSendChat);
            this.Controls.Add((Control)this.lblEnterTxt);
            this.Controls.Add((Control)this.txtChatInput);
            this.Controls.Add((Control)this.lblHelp);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.rtbChatLog);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = nameof(frmChat);
            this.Text = "Chat Window";
            this.DragDrop += new DragEventHandler(this.frmChat_DragDrop);
            this.DragEnter += new DragEventHandler(this.frmChat_DragEnter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public frmChat()
        {
            this.InitializeComponent();
            this.cmbChatType.SelectedIndex = 0;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed || this.memReader == null)
                return;
            if (!this.memReader.IsAttached | !this.memReader.IsRunning)
            {
                this.Text = "Process Lost! -- Re-Attach";
                this.m_Chat = (string)null;
                this.m_ChatBuffer = (string)null;
                this.tmrUpdate.Enabled = false;
            }
            else
            {
                this.m_CharName = this.memReader.ReadString((IntPtr)6585504);
                this.m_ChatBuffer = this.memReader.ReadString((IntPtr)this.memReader.ReadInt32((IntPtr)(this.memReader.ReadInt32((IntPtr)(this.memReader.ReadInt32((IntPtr)(this.memReader.ReadInt32((IntPtr)6585540) + 468)) + 448)) + 24)));
            }
            if (this.m_CharName != null)
            {
                this.Text = this.m_CharName + "'s Chat";
                this.label1.Text = this.m_CharName + "'s Chat is located to the left.";
                this.charNameLength = this.m_CharName.Length;
            }
            else
                this.Text = "Chat Window";
            if (this.m_ChatBuffer != null)
            {
                if (this.checkNewChat(this.m_ChatBuffer, this.m_Chat))
                {
                    this.m_Chat = this.m_ChatBuffer;
                    this.rtbChatLog.Text = this.m_Chat.Replace('\n', ' ');
                    this.rtbChatLog.SelectionStart = this.rtbChatLog.Text.Length;
                    this.rtbChatLog.ScrollToCaret();
                }
            }
            else
                this.rtbChatLog.Text = "No Chat Detected";
        }

        private void frmChat_DragEnter(object sender, DragEventArgs e)
        {
            uint result = 0;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text), out result))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void frmChat_DragDrop(object sender, DragEventArgs e)
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
                this.memReader = new MemoryReader(result);
                if (!this.memReader.IsAttached)
                    return;
                this.tmrUpdate.Enabled = true;
                this.hasProcess = true;
            }
        }

        private bool checkNewChat(string curBuffer, string newBuffer) => !curBuffer.Equals(newBuffer);

        private void floatChatWindow()
        {
            this.myParent = this.MdiParent;
            this.MdiParent = (Form)null;
            this.Refresh();
        }

        private void dockChatWindow()
        {
            this.MdiParent = this.myParent;
            this.Refresh();
        }

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            if (this.hasProcess)
            {
                if (this.txtChatInput.Text == "")
                {
                    if (!(this.txtWhisperTrgt.Text == ""))
                        return;
                    int num = (int)MessageBox.Show("No text to send!", "Error: No input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtChatInput.Focus();
                }
                else if (this.cmbChatType.SelectedIndex == 1)
                {
                    int num = (int)MessageBox.Show("Error: You have not specified a Whisper Target", "Error: No Target", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtWhisperTrgt.Focus();
                }
                else
                {
                    this.txtChatInput.Enabled = false;
                    this.ProcessChat(this.txtChatInput.Text);
                    this.txtChatInput.Text = "";
                    this.rtbChatLog.SelectionStart = this.rtbChatLog.Text.Length;
                    this.rtbChatLog.ScrollToCaret();
                    this.txtChatInput.Enabled = true;
                }
            }
            else
            {
                int num1 = (int)MessageBox.Show("Error: No process has been attached", "Error: Missing Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public int MakeDWord(short LoWord, short HiWord)
        {
            return (int)HiWord * 65536 /*0x010000*/ | (int)LoWord & (int)ushort.MaxValue;
        }

        private void ProcessChat(string chatString)
        {
            this.PostMessage((short)256 /*0x0100*/, Keys.Escape);
            switch (this.chatType)
            {
                case 0:
                    this.PostMessage((short)256 /*0x0100*/, Keys.Return);
                    break;
                case 1:
                    this.PostMessage((short)256 /*0x0100*/, Keys.ShiftKey);
                    frmChat.User32.PostMessage((IntPtr)(long)this.memReader.WindowHandle, 256U /*0x0100*/, (UIntPtr)222U, (UIntPtr)2621440U /*0x280000*/);
                    this.PostMessage((short)257, Keys.ShiftKey);
                    Thread.Sleep(80 /*0x50*/);
                    this.PostString(this.txtWhisperTrgt.Text);
                    this.PostMessage((short)256 /*0x0100*/, Keys.Return);
                    break;
                case 2:
                    byte postKey1 = Encoding.ASCII.GetBytes("!")[0];
                    this.PostMessage((short)256 /*0x0100*/, Keys.ShiftKey);
                    frmChat.User32.PostMessage((IntPtr)(long)this.memReader.WindowHandle, 256U /*0x0100*/, (UIntPtr)222U, (UIntPtr)2621440U /*0x280000*/);
                    this.PostMessage((short)257, Keys.ShiftKey);
                    Thread.Sleep(80 /*0x50*/);
                    this.PostMessage((short)258, (short)postKey1);
                    this.PostMessage((short)256 /*0x0100*/, Keys.Return);
                    break;
                case 3:
                    byte postKey2 = Encoding.ASCII.GetBytes("!")[0];
                    this.PostMessage((short)256 /*0x0100*/, Keys.ShiftKey);
                    frmChat.User32.PostMessage((IntPtr)(long)this.memReader.WindowHandle, 256U /*0x0100*/, (UIntPtr)222U, (UIntPtr)2621440U /*0x280000*/);
                    this.PostMessage((short)257, Keys.ShiftKey);
                    Thread.Sleep(80 /*0x50*/);
                    this.PostMessage((short)258, (short)postKey2);
                    Thread.Sleep(60);
                    this.PostMessage((short)258, (short)postKey2);
                    this.PostMessage((short)256 /*0x0100*/, Keys.Return);
                    break;
            }
            this.PostString(chatString);
            Thread.Sleep(50);
            this.PostMessage((short)256 /*0x0100*/, Keys.Return);
        }

        private void cmbChatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbChatType.SelectedIndex)
            {
                case 0:
                    this.chatType = 0;
                    this.Height = 459;
                    this.lblWhisperTo.Visible = false;
                    this.txtWhisperTrgt.Visible = false;
                    break;
                case 1:
                    this.chatType = 1;
                    this.Height = 477;
                    this.lblWhisperTo.Visible = true;
                    this.txtWhisperTrgt.Visible = true;
                    break;
                case 2:
                    this.chatType = 2;
                    this.Height = 459;
                    this.lblWhisperTo.Visible = false;
                    this.txtWhisperTrgt.Visible = false;
                    break;
                case 3:
                    this.chatType = 3;
                    this.Height = 459;
                    this.lblWhisperTo.Visible = false;
                    this.txtWhisperTrgt.Visible = false;
                    break;
                default:
                    this.chatType = 0;
                    this.Height = 459;
                    this.lblWhisperTo.Visible = false;
                    this.txtWhisperTrgt.Visible = false;
                    break;
            }
        }

        private void PostMessage(short keyState, Keys postKey)
        {
            frmChat.User32.PostMessage((IntPtr)(long)this.memReader.WindowHandle, (uint)keyState, (UIntPtr)(ulong)postKey, (UIntPtr)(ulong)this.MakeDWord((short)0, (short)frmChat.User32.MapVirtualKey((uint)postKey, 0U)));
        }

        private void PostMessage(short keyState, short postKey)
        {
            frmChat.User32.PostMessage((IntPtr)(long)this.memReader.WindowHandle, (uint)keyState, (UIntPtr)(ulong)postKey, (UIntPtr)(ulong)this.MakeDWord((short)0, (short)frmChat.User32.MapVirtualKey((uint)postKey, 0U)));
        }

        private void PostString(string postString)
        {
            string str1 = postString;
            if (!(str1.Trim() != ""))
                return;
            int length = 0;
            int index = 0;
            char ch;
            for (string str2 = str1; str2.Length > 0; str2 = str2.Remove(0, 1))
            {
                ch = str2[0];
                ++length;
            }
            frmChat.KeystrokeItem[] keystrokeItemArray = new frmChat.KeystrokeItem[length];
            for (string str3 = str1; str3.Length > 0; str3 = str3.Remove(0, 1))
            {
                ch = str3[0];
                keystrokeItemArray[index].Keystroke = str3.Substring(0, 1);
                ++index;
            }
            foreach (frmChat.KeystrokeItem keystrokeItem in keystrokeItemArray)
            {
                short postKey = (short)Encoding.ASCII.GetBytes(keystrokeItem.Keystroke.ToString())[0];
                Thread.Sleep(60);
                this.PostMessage((short)258, postKey);
            }
        }

        private void txtChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            this.btnSendChat_Click(sender, (EventArgs)e);
        }

        private void btnFloat_Click(object sender, EventArgs e)
        {
            this.btnFloat.Enabled = false;
            this.btnDock.Enabled = true;
            this.btnToggleTopmost.Enabled = true;
            this.btnToggleTopmost.Visible = true;
            this.floatChatWindow();
        }

        private void btnDock_Click(object sender, EventArgs e)
        {
            this.btnFloat.Enabled = true;
            this.btnDock.Enabled = false;
            this.btnToggleTopmost.Enabled = false;
            this.btnToggleTopmost.Visible = false;
            this.dockChatWindow();
        }

        private void btnToggleTopmost_Click(object sender, EventArgs e)
        {
            if (!this.enableOnTop)
            {
                this.enableOnTop = true;
                this.TopMost = true;
                this.btnToggleTopmost.Text = "Toggle Stay On Top (Enabled)";
                this.Refresh();
            }
            else
            {
                this.enableOnTop = false;
                this.TopMost = false;
                this.btnToggleTopmost.Text = "Toggle Stay On Top";
                this.Refresh();
            }
        }

        public class User32
        {
            public const short WM_CHAR = 258;
            public const short WM_KEYDOWN = 256 /*0x0100*/;
            public const short WM_KEYUP = 257;

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool PostMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, UIntPtr lParam);

            [DllImport("user32.dll")]
            public static extern uint MapVirtualKey(uint uCode, uint uMapType);
        }

        public struct KeystrokeItem
        {
            public string Keystroke;
            public bool IsSpecialChar;
            public object Tag;
        }
    }
}