using SleepHunter.Interop.Win32;
using System;
using System.Runtime.CompilerServices;

namespace SleepHunter.Interop.Keyboard
{
    public sealed class VirtualKeyboard : IVirtualKeyboard
    {
        private const uint WM_KEYDOWN = 0x100;

        private const uint WM_KEYUP = 0x101;
        //private const uint WM_CHAR = 0x102;
        //private const uint WM_DEADCHAR = 0x103;
        //private const uint WM_SYSKEYDOWN = 0x104;
        //private const uint WM_SYSKEYUP = 0x105;
        //private const uint WM_SYSCHAR = 0x106;
        //private const uint WM_SYSDEADCHAR = 0x107;

        private const int VK_SHIFT = 0x10;
        private const int VK_CONTROL = 0x11;
        private const int VK_MENU = 0x12; // ALT key

        private readonly IntPtr windowHandle;

        public VirtualKeyboard(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }

        #region Key Down

        public void SendKeyDown(Keystroke keystroke)
        {
            if (keystroke.IsChar)
            {
                SendKeyDown(keystroke.Char ?? '\0');
            }
            else
            {
                SendKeyDown(keystroke.VirtualKey ?? 0);
            }
        }

        public void SendKeyDown(char c) => SendKeyDown(GetVirtualKey(c));

        public void SendKeyDown(int virtualKey)
        {
            var scanCode = GetScanCode(virtualKey);
            var keyParameter = GetKeyParameter(1, scanCode, false, false);

            NativeMethods.PostMessage(windowHandle, WM_KEYDOWN, (IntPtr)virtualKey, keyParameter);
        }

        #endregion

        #region Key Up

        public void SendKeyUp(Keystroke keystroke)
        {
            if (keystroke.IsChar)
            {
                SendKeyUp(keystroke.Char ?? '\0');
            }
            else
            {
                SendKeyUp(keystroke.VirtualKey ?? 0);
            }
        }

        public void SendKeyUp(char c) => SendKeyUp(GetVirtualKey(c));

        public void SendKeyUp(int virtualKey)
        {
            var scanCode = GetScanCode(virtualKey);
            var keyParameter = GetKeyParameter(1, scanCode, true);

            NativeMethods.PostMessage(windowHandle, WM_KEYUP, (IntPtr)virtualKey, keyParameter);
        }

        #endregion

        #region Modifier Keys

        public void SendModifierKeyDown(ModifierKeys modifier)
        {
            if (modifier.HasFlag(ModifierKeys.Shift))
            {
                var scanCode = GetScanCode(VK_SHIFT);
                var keyParameter = GetKeyParameter(1, scanCode, false, false);

                NativeMethods.PostMessage(windowHandle, WM_KEYDOWN, (IntPtr)VK_SHIFT, keyParameter);
            }

            if (modifier.HasFlag(ModifierKeys.Control))
            {
                var scanCode = GetScanCode(VK_CONTROL);
                var keyParameter = GetKeyParameter(1, scanCode, false, false);

                NativeMethods.PostMessage(windowHandle, WM_KEYDOWN, (IntPtr)VK_CONTROL, keyParameter);
            }

            if (modifier.HasFlag(ModifierKeys.Alt))
            {
                var scanCode = GetScanCode(VK_MENU);
                var keyParameter = GetKeyParameter(1, scanCode, false, false);

                NativeMethods.PostMessage(windowHandle, WM_KEYDOWN, (IntPtr)VK_MENU, keyParameter);
            }
        }

        public void SendModifierKeyUp(ModifierKeys modifier)
        {
            if (modifier.HasFlag(ModifierKeys.Shift))
            {
                var scanCode = GetScanCode(VK_SHIFT);
                var keyParameter = GetKeyParameter(1, scanCode, true);

                NativeMethods.PostMessage(windowHandle, WM_KEYUP, (IntPtr)VK_SHIFT, keyParameter);
            }

            if (modifier.HasFlag(ModifierKeys.Control))
            {
                var scanCode = GetScanCode(VK_CONTROL);
                var keyParameter = GetKeyParameter(1, scanCode, true);

                NativeMethods.PostMessage(windowHandle, WM_KEYUP, (IntPtr)VK_CONTROL, keyParameter);
            }

            if (modifier.HasFlag(ModifierKeys.Alt))
            {
                var scanCode = GetScanCode(VK_MENU);
                var keyParameter = GetKeyParameter(1, scanCode, true);

                NativeMethods.PostMessage(windowHandle, WM_KEYUP, (IntPtr)VK_MENU, keyParameter);
            }
        }

        #endregion

        public void SendKeyPress(Keystroke keystroke)
        {
            SendKeyDown(keystroke);

            // optionally send WM_CHAR here, but most games rely on WM_KEYDOWN

            SendKeyUp(keystroke);
        }

        public void SendKeyPress(char c)
        {
            SendKeyDown(c);

            // optionally send WM_CHAR here, but most games rely on WM_KEYDOWN

            SendKeyUp(c);
        }

        public void SendKeyPress(int virtualKey)
        {
            SendKeyDown(virtualKey);

            // optionally send WM_CHAR here, but most games rely on WM_KEYDOWN

            SendKeyUp(virtualKey);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IntPtr GetKeyParameter(int repeatCount, byte scanCode, bool previousState = false,
            bool transitionState = true, bool isExtendedKey = false, bool contextCode = false)
        {
            var param = (uint)(repeatCount & 0xFFFF);

            param |= (uint)scanCode << 16;

            if (isExtendedKey)
            {
                param |= 1u << 24;
            }

            // Whether alt is held down
            if (contextCode)
            {
                param |= 1u << 29;
            }

            if (previousState)
            {
                param |= 1u << 30;
            }

            if (transitionState)
            {
                param |= 1u << 31;
            }

            return (IntPtr)param;
        }

        private static byte GetScanCode(char c)
        {
            var vkey = GetVirtualKey(c);
            var scanCode = NativeMethods.MapVirtualKey((uint)vkey, Win32VirtualKeyMapType.VirtualKeyToScanCode);

            return (byte)scanCode;
        }

        private static byte GetScanCode(int vkey)
        {
            var result = NativeMethods.MapVirtualKey((uint)vkey, Win32VirtualKeyMapType.VirtualKeyToScanCode);
            return (byte)result;
        }

        private static int GetVirtualKey(char c) => GetVirtualKey(c, out _);

        private static int GetVirtualKey(char c, out ModifierKeys modifiers)
        {
            var keyScan = NativeMethods.VkKeyScan(c);

            var vkey = (byte)keyScan;
            var modifiersScan = (byte)(keyScan >> 8);

            modifiers = (ModifierKeys)modifiersScan;
            return vkey;
        }
    }
}
