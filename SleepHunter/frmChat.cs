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
    public partial class frmChat : Form
    {
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