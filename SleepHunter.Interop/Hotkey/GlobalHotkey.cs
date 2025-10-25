using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using SleepHunter.Interop.Win32;

namespace SleepHunter.Interop.Hotkey
{
    public sealed class GlobalHotkey : IDisposable
    {
        private const uint WM_HOTKEY = 0x0312;
        private const uint MOD_NOREPEAT = 0x4000;
        
        private static int _nextHotkeyId;
        
        private readonly SynchronizationContext syncContext;
        private readonly IntPtr windowHandle;
        private readonly int hotkeyId;
        private HotkeyModifiers modifiers;
        private VirtualKeys key;

        private bool isDisposed;
        
        public IntPtr WindowHandle => windowHandle;
        
        public int HotkeyId => hotkeyId;
        
        public HotkeyModifiers Modifiers => modifiers;
        
        public VirtualKeys Key => key;
        
        public bool IsRegistered { get; private set; }
        public bool Enabled { get; set; } = true;

        public event EventHandler HotkeyPressed;
        
        public GlobalHotkey(IntPtr windowHandle, VirtualKeys key, HotkeyModifiers modifiers = HotkeyModifiers.None, SynchronizationContext syncContext = null)
        {
            if (windowHandle == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid window handle", nameof(windowHandle));
            }
            
            this.syncContext = syncContext ?? SynchronizationContext.Current;
            this.windowHandle = windowHandle;
            this.key = key;
            this.modifiers = modifiers;

            hotkeyId = Interlocked.Increment(ref _nextHotkeyId);

            Register();
        }

        private void Register()
        {
            if (IsRegistered)
            {
                return;
            }

            if (!NativeMethods.RegisterHotKey(windowHandle, hotkeyId, (uint)modifiers | MOD_NOREPEAT, (uint)key))
            {
                var error = Marshal.GetLastWin32Error();
                throw new Win32Exception(error);
            }

            IsRegistered = true;
        }

        public void Rebind(VirtualKeys newKey, HotkeyModifiers newModifiers = HotkeyModifiers.None)
        {
            if (IsRegistered)
            {
                Unregister();
            }

            modifiers = newModifiers;
            key = newKey;

            Register();
        }

        public void Unregister()
        {
            if (!IsRegistered)
            {
                return;
            }

            NativeMethods.UnregisterHotKey(windowHandle, hotkeyId);
            IsRegistered = false;
        }

        public bool ProcessMessage(int message, IntPtr wParam, IntPtr lParam)
        {
            if (message == WM_HOTKEY && wParam.ToInt32() == hotkeyId && IsRegistered && Enabled)
            {
                OnHotkeyPressed();
                return true;
            }

            return false;
        }

        private void OnHotkeyPressed()
        {
            if (HotkeyPressed != null)
            {
                syncContext.Post(_ => HotkeyPressed(this, EventArgs.Empty), null);
            }
        }

        public override string ToString()
        {
            var modifierText = string.Empty;
            if (modifiers.HasFlag(HotkeyModifiers.Control))
            {
                modifierText += "Ctrl + ";
            }

            if (modifiers.HasFlag(HotkeyModifiers.Alt))
            {
                modifierText += "Alt + ";
            }

            if (modifiers.HasFlag(HotkeyModifiers.Shift))
            {
                modifierText += "Shift + ";
            }

            return $"{modifierText}{key.ToAlias()}";
        }

        ~GlobalHotkey() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            NativeMethods.UnregisterHotKey(windowHandle, hotkeyId);

            IsRegistered = false;
            isDisposed = true;
        }
    }
}