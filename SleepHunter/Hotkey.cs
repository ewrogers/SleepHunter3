using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SleepHunter
{
    public class Hotkey
    {
        public const int MOD_ALT = 1;
        public const int MOD_CONTROL = 2;
        public const int MOD_SHIFT = 4;
        public const int MOD_WIN = 8;
        private short hotkeyID;
        private Keys hotkeyKey;
        private int modifiers;
        private bool enabled;
        private IntPtr targethWnd;
        private bool useCtrl;
        private bool useAlt;
        private bool useWin;
        private bool useShift;

        [DllImport("user32", SetLastError = true)]
        public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

        [DllImport("user32", SetLastError = true)]
        public static extern int UnregisterHotKey(IntPtr hwnd, int id);

        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);

        public short HotkeyID => this.hotkeyID;

        public Keys ShortcutKey => this.hotkeyKey;

        public bool Enabled
        {
            get => this.enabled;
            set
            {
                if (value)
                    this.ReRegisterGlobalHotKey();
                else
                    this.UnregisterGlobalHotKey();
            }
        }

        public IntPtr WindowHandle
        {
            get => this.targethWnd;
            set => this.targethWnd = value;
        }

        public bool UseCTRL => (this.modifiers & 2) != 0;

        public bool UseALT => (this.modifiers & 1) != 0;

        public bool UseWinKey => (this.modifiers & 8) != 0;

        public bool UseSHIFT => (this.modifiers & 4) != 0;

        public Hotkey(IntPtr hWnd, Keys keys, int modifiers)
        {
            this.targethWnd = hWnd;
            this.hotkeyKey = keys;
            this.modifiers = modifiers;
            this.RegisterGlobalHotKey(this.hotkeyKey, this.modifiers);
        }

        ~Hotkey() => this.UnregisterGlobalHotKey();

        public void Dispose() => this.UnregisterGlobalHotKey();

        public void SetHotkey(Keys keys, int modifiers)
        {
            this.hotkeyKey = keys;
            this.modifiers = modifiers;
        }

        private void RegisterGlobalHotKey(Keys hotkey, int modifiers)
        {
            try
            {
                int num = Thread.CurrentThread.ManagedThreadId;
                this.hotkeyID = Hotkey.GlobalAddAtom(num.ToString("X8") + (object)(int)(hotkey + modifiers * 65536 /*0x010000*/));
                if (this.hotkeyID == (short)0)
                {
                    num = Marshal.GetLastWin32Error();
                    throw new Exception("Unable to generate unique hotkey ID. Error code: " + num.ToString());
                }
                if (Hotkey.RegisterHotKey(this.targethWnd, (int)this.hotkeyID, modifiers, (int)hotkey) == 0)
                {
                    num = Marshal.GetLastWin32Error();
                    throw new Exception("Unable to register hotkey. Error code: " + num.ToString());
                }
            }
            catch (Exception)
            {
                this.UnregisterGlobalHotKey();
            }
        }

        public void ReRegisterGlobalHotKey()
        {
            this.UnregisterGlobalHotKey();
            this.RegisterGlobalHotKey(this.hotkeyKey, this.modifiers);
        }

        private void UnregisterGlobalHotKey()
        {
            if (this.hotkeyID == (short)0)
                return;
            Hotkey.UnregisterHotKey(this.targethWnd, (int)this.hotkeyID);
            int num = (int)Hotkey.GlobalDeleteAtom(this.hotkeyID);
            this.hotkeyID = (short)0;
        }
    }
}