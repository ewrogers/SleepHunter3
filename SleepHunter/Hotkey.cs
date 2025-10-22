using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SleepHunter
{
    public class Hotkey
    {
        public const int ModAlt = 1;
        public const int ModControl = 2;
        public const int ModShift = 4;
        public const int ModWin = 8;
        private short hotkeyId;
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

        public short HotkeyId => hotkeyId;

        public Keys ShortcutKey => hotkeyKey;

        public bool Enabled
        {
            get => enabled;
            set
            {
                if (value)
                    ReRegisterGlobalHotKey();
                else
                    UnregisterGlobalHotKey();
            }
        }

        public IntPtr WindowHandle
        {
            get => targethWnd;
            set => targethWnd = value;
        }

        public bool UseCtrl => (modifiers & 2) != 0;

        public bool UseAlt => (modifiers & 1) != 0;

        public bool UseWinKey => (modifiers & 8) != 0;

        public bool UseShift => (modifiers & 4) != 0;

        public Hotkey(IntPtr hWnd, Keys keys, int modifiers)
        {
            targethWnd = hWnd;
            hotkeyKey = keys;
            this.modifiers = modifiers;
            RegisterGlobalHotKey(hotkeyKey, this.modifiers);
        }

        ~Hotkey() => UnregisterGlobalHotKey();

        public void Dispose() => UnregisterGlobalHotKey();

        public void SetHotkey(Keys keys, int modifiers)
        {
            hotkeyKey = keys;
            this.modifiers = modifiers;
        }

        private void RegisterGlobalHotKey(Keys hotkey, int modifiers)
        {
            try
            {
                int num = Thread.CurrentThread.ManagedThreadId;
                hotkeyId = GlobalAddAtom(num.ToString("X8") + (int)(hotkey + modifiers * 65536 /*0x010000*/));
                if (hotkeyId == 0)
                {
                    num = Marshal.GetLastWin32Error();
                    throw new Exception("Unable to generate unique hotkey ID. Error code: " + num);
                }
                if (RegisterHotKey(targethWnd, hotkeyId, modifiers, (int)hotkey) == 0)
                {
                    num = Marshal.GetLastWin32Error();
                    throw new Exception("Unable to register hotkey. Error code: " + num);
                }
            }
            catch (Exception)
            {
                UnregisterGlobalHotKey();
            }
        }

        public void ReRegisterGlobalHotKey()
        {
            UnregisterGlobalHotKey();
            RegisterGlobalHotKey(hotkeyKey, modifiers);
        }

        private void UnregisterGlobalHotKey()
        {
            if (hotkeyId == 0)
                return;
            UnregisterHotKey(targethWnd, hotkeyId);
            int num = GlobalDeleteAtom(hotkeyId);
            hotkeyId = 0;
        }
    }
}