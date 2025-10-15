using ProcessMemory;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SleepHunter
{
    public partial class frmChat : Form
    {
        private string m_ChatBuffer;
        private string m_Chat;
        private string m_CharName;
        private MemoryReader memReader;
        private Form myParent;
        private bool enableOnTop;
        private static int SPOKENMAX = 67;
        private static int GUILDMAX = 66;
        private static int WHISPERMAX = 64 /*0x40*/;
        private int charNameLength;
        private int maxChatLength;
        private int chatType;
        private bool hasProcess;
        
        public frmChat()
        {
            InitializeComponent();
            cmbChatType.SelectedIndex = 0;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (IsDisposed || memReader == null)
                return;
            if (!memReader.IsAttached | !memReader.IsRunning)
            {
                Text = "Process Lost! -- Re-Attach";
                m_Chat = null;
                m_ChatBuffer = null;
                tmrUpdate.Enabled = false;
            }
            else
            {
                m_CharName = memReader.ReadString((IntPtr)6585504);
                m_ChatBuffer = memReader.ReadString((IntPtr)memReader.ReadInt32((IntPtr)(memReader.ReadInt32((IntPtr)(memReader.ReadInt32((IntPtr)(memReader.ReadInt32((IntPtr)6585540) + 468)) + 448)) + 24)));
            }
            if (m_CharName != null)
            {
                Text = m_CharName + "'s Chat";
                label1.Text = m_CharName + "'s Chat is located to the left.";
                charNameLength = m_CharName.Length;
            }
            else
            {
                Text = "Chat Window";
            }

            if (m_ChatBuffer != null)
            {
                if (checkNewChat(m_ChatBuffer, m_Chat))
                {
                    m_Chat = m_ChatBuffer;
                    rtbChatLog.Text = m_Chat.Replace('\n', ' ');
                    rtbChatLog.SelectionStart = rtbChatLog.Text.Length;
                    rtbChatLog.ScrollToCaret();
                }
            }
            else
            {
                rtbChatLog.Text = "No Chat Detected";
            }
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
            uint result;
            if (!uint.TryParse((string)e.Data.GetData(DataFormats.Text), out result))
                e.Effect = DragDropEffects.None;
            else if (result < 1U)
            {
                int num = (int)MessageBox.Show($"The process you have selected is invalid. (PID {result.ToString()})", "Invalid Process,", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                memReader = new MemoryReader(result);
                if (!memReader.IsAttached)
                    return;
                tmrUpdate.Enabled = true;
                hasProcess = true;
            }
        }

        private bool checkNewChat(string curBuffer, string newBuffer) => !curBuffer.Equals(newBuffer);

        private void floatChatWindow()
        {
            myParent = MdiParent;
            MdiParent = null;
            Refresh();
        }

        private void dockChatWindow()
        {
            MdiParent = myParent;
            Refresh();
        }

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            if (hasProcess)
            {
                if (txtChatInput.Text == "")
                {
                    if (!(txtWhisperTrgt.Text == ""))
                        return;
                    int num = (int)MessageBox.Show("No text to send!", "Error: No input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtChatInput.Focus();
                }
                else if (cmbChatType.SelectedIndex == 1)
                {
                    int num = (int)MessageBox.Show("Error: You have not specified a Whisper Target", "Error: No Target", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtWhisperTrgt.Focus();
                }
                else
                {
                    txtChatInput.Enabled = false;
                    ProcessChat(txtChatInput.Text);
                    txtChatInput.Text = "";
                    rtbChatLog.SelectionStart = rtbChatLog.Text.Length;
                    rtbChatLog.ScrollToCaret();
                    txtChatInput.Enabled = true;
                }
            }
            else
            {
                int num1 = (int)MessageBox.Show("Error: No process has been attached", "Error: Missing Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public int MakeDWord(short LoWord, short HiWord)
        {
            return HiWord * 65536 /*0x010000*/ | LoWord & ushort.MaxValue;
        }

        private void ProcessChat(string chatString)
        {
            PostMessage(256 /*0x0100*/, Keys.Escape);
            switch (chatType)
            {
                case 0:
                    PostMessage(256 /*0x0100*/, Keys.Return);
                    break;
                case 1:
                    PostMessage(256 /*0x0100*/, Keys.ShiftKey);
                    User32.PostMessage((IntPtr)(long)memReader.WindowHandle, 256U /*0x0100*/, (UIntPtr)222U, (UIntPtr)2621440U /*0x280000*/);
                    PostMessage(257, Keys.ShiftKey);
                    Thread.Sleep(80 /*0x50*/);
                    PostString(txtWhisperTrgt.Text);
                    PostMessage(256 /*0x0100*/, Keys.Return);
                    break;
                case 2:
                    byte postKey1 = Encoding.ASCII.GetBytes("!")[0];
                    PostMessage(256 /*0x0100*/, Keys.ShiftKey);
                    User32.PostMessage((IntPtr)(long)memReader.WindowHandle, 256U /*0x0100*/, (UIntPtr)222U, (UIntPtr)2621440U /*0x280000*/);
                    PostMessage(257, Keys.ShiftKey);
                    Thread.Sleep(80 /*0x50*/);
                    PostMessage(258, postKey1);
                    PostMessage(256 /*0x0100*/, Keys.Return);
                    break;
                case 3:
                    byte postKey2 = Encoding.ASCII.GetBytes("!")[0];
                    PostMessage(256 /*0x0100*/, Keys.ShiftKey);
                    User32.PostMessage((IntPtr)(long)memReader.WindowHandle, 256U /*0x0100*/, (UIntPtr)222U, (UIntPtr)2621440U /*0x280000*/);
                    PostMessage(257, Keys.ShiftKey);
                    Thread.Sleep(80 /*0x50*/);
                    PostMessage(258, postKey2);
                    Thread.Sleep(60);
                    PostMessage(258, postKey2);
                    PostMessage(256 /*0x0100*/, Keys.Return);
                    break;
            }
            PostString(chatString);
            Thread.Sleep(50);
            PostMessage(256 /*0x0100*/, Keys.Return);
        }

        private void cmbChatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbChatType.SelectedIndex)
            {
                case 0:
                    chatType = 0;
                    Height = 459;
                    lblWhisperTo.Visible = false;
                    txtWhisperTrgt.Visible = false;
                    break;
                case 1:
                    chatType = 1;
                    Height = 477;
                    lblWhisperTo.Visible = true;
                    txtWhisperTrgt.Visible = true;
                    break;
                case 2:
                    chatType = 2;
                    Height = 459;
                    lblWhisperTo.Visible = false;
                    txtWhisperTrgt.Visible = false;
                    break;
                case 3:
                    chatType = 3;
                    Height = 459;
                    lblWhisperTo.Visible = false;
                    txtWhisperTrgt.Visible = false;
                    break;
                default:
                    chatType = 0;
                    Height = 459;
                    lblWhisperTo.Visible = false;
                    txtWhisperTrgt.Visible = false;
                    break;
            }
        }

        private void PostMessage(short keyState, Keys postKey)
        {
            User32.PostMessage((IntPtr)(long)memReader.WindowHandle, (uint)keyState, (UIntPtr)(ulong)postKey, (UIntPtr)(ulong)MakeDWord(0, (short)User32.MapVirtualKey((uint)postKey, 0U)));
        }

        private void PostMessage(short keyState, short postKey)
        {
            User32.PostMessage((IntPtr)(long)memReader.WindowHandle, (uint)keyState, (UIntPtr)(ulong)postKey, (UIntPtr)(ulong)MakeDWord(0, (short)User32.MapVirtualKey((uint)postKey, 0U)));
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
            KeystrokeItem[] keystrokeItemArray = new KeystrokeItem[length];
            for (string str3 = str1; str3.Length > 0; str3 = str3.Remove(0, 1))
            {
                ch = str3[0];
                keystrokeItemArray[index].Keystroke = str3.Substring(0, 1);
                ++index;
            }
            foreach (KeystrokeItem keystrokeItem in keystrokeItemArray)
            {
                short postKey = Encoding.ASCII.GetBytes(keystrokeItem.Keystroke)[0];
                Thread.Sleep(60);
                PostMessage(258, postKey);
            }
        }

        private void txtChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            btnSendChat_Click(sender, e);
        }

        private void btnFloat_Click(object sender, EventArgs e)
        {
            btnFloat.Enabled = false;
            btnDock.Enabled = true;
            btnToggleTopmost.Enabled = true;
            btnToggleTopmost.Visible = true;
            floatChatWindow();
        }

        private void btnDock_Click(object sender, EventArgs e)
        {
            btnFloat.Enabled = true;
            btnDock.Enabled = false;
            btnToggleTopmost.Enabled = false;
            btnToggleTopmost.Visible = false;
            dockChatWindow();
        }

        private void btnToggleTopmost_Click(object sender, EventArgs e)
        {
            if (!enableOnTop)
            {
                enableOnTop = true;
                TopMost = true;
                btnToggleTopmost.Text = "Toggle Stay On Top (Enabled)";
                Refresh();
            }
            else
            {
                enableOnTop = false;
                TopMost = false;
                btnToggleTopmost.Text = "Toggle Stay On Top";
                Refresh();
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