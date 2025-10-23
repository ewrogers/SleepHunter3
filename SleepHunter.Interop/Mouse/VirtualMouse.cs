using SleepHunter.Interop.Win32;
using System;
using System.Runtime.CompilerServices;

namespace SleepHunter.Interop.Mouse
{
    public sealed class VirtualMouse : IVirtualMouse
    {
        private const uint WM_MOUSEMOVE = 0x200;
        private const uint WM_LBUTTONDOWN = 0x201;
        private const uint WM_LBUTTONUP = 0x202;
        private const uint WM_LBUTTONDBLCLK = 0x203;
        private const uint WM_RBUTTONDOWN = 0x204;
        private const uint WM_RBUTTONUP = 0x205;
        private const uint WM_RBUTTONDBLCLK = 0x206;
        private const uint WM_MBUTTONDOWN = 0x207;
        private const uint WM_MBUTTONUP = 0x208;
        private const uint WM_MBUTTONDBLCLK = 0x209;
        private const uint WM_MOUSEWHEEL = 0x20A;
        private const uint WM_XBUTTONDOWN = 0x20B;
        private const uint WM_XBUTTONUP = 0x20C;
        private const uint WM_XBUTTONDBLCLK = 0x20D;

        private const uint MK_LBUTTON = 0x1;
        private const uint MK_RBUTTON = 0x2;
        private const uint MK_MBUTTON = 0x10;
        private const uint MK_XBUTTON1 = 0x20;
        private const uint MK_XBUTTON2 = 0x40;

        private readonly IntPtr windowHandle;

        public VirtualMouse(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }

        public void MoveMouse(int x, int y)
        {
            var parameter = MakePointParameter(x, y);
            NativeMethods.PostMessage(windowHandle, WM_MOUSEMOVE, IntPtr.Zero, parameter);
        }

        public void SendButtonDown(MouseButton button, int x = 0, int y = 0)
        {
            var parameter = MakePointParameter(x, y);

            if (button.HasFlag(MouseButton.Left))
            {
                NativeMethods.PostMessage(windowHandle, WM_LBUTTONDOWN, (IntPtr)MK_LBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.Right))
            {
                NativeMethods.PostMessage(windowHandle, WM_RBUTTONDOWN, (IntPtr)MK_RBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.Middle))
            {
                NativeMethods.PostMessage(windowHandle, WM_MBUTTONDOWN, (IntPtr)MK_MBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.XButton1))
            {
                NativeMethods.PostMessage(windowHandle, WM_XBUTTONDOWN, (IntPtr)MK_XBUTTON1, parameter);
            }

            if (button.HasFlag(MouseButton.XButton2))
            {
                NativeMethods.PostMessage(windowHandle, WM_XBUTTONDOWN, (IntPtr)MK_XBUTTON2, parameter);
            }
        }

        public void SendButtonUp(MouseButton button, int x = 0, int y = 0)
        {
            var parameter = MakePointParameter(x, y);

            if (button.HasFlag(MouseButton.Left))
            {
                NativeMethods.PostMessage(windowHandle, WM_LBUTTONUP, (IntPtr)MK_LBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.Right))
            {
                NativeMethods.PostMessage(windowHandle, WM_RBUTTONUP, (IntPtr)MK_RBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.Middle))
            {
                NativeMethods.PostMessage(windowHandle, WM_MBUTTONUP, (IntPtr)MK_MBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.XButton1))
            {
                NativeMethods.PostMessage(windowHandle, WM_XBUTTONUP, (IntPtr)MK_XBUTTON1, parameter);
            }

            if (button.HasFlag(MouseButton.XButton2))
            {
                NativeMethods.PostMessage(windowHandle, WM_XBUTTONUP, (IntPtr)MK_XBUTTON2, parameter);
            }
        }

        public void Click(MouseButton button, int x = 0, int y = 0, bool moveMouse = true)
        {
            if (moveMouse)
            {
                MoveMouse(x, y);
            }

            SendButtonDown(button, x, y);
            SendButtonUp(button, x, y);
        }

        public void DoubleClick(MouseButton button, int x = 0, int y = 0)
        {
            var parameter = MakePointParameter(x, y);

            if (button.HasFlag(MouseButton.Left))
            {
                NativeMethods.PostMessage(windowHandle, WM_LBUTTONDBLCLK, (IntPtr)MK_LBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.Right))
            {
                NativeMethods.PostMessage(windowHandle, WM_RBUTTONDBLCLK, (IntPtr)MK_RBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.Middle))
            {
                NativeMethods.PostMessage(windowHandle, WM_MBUTTONDBLCLK, (IntPtr)MK_MBUTTON, parameter);
            }

            if (button.HasFlag(MouseButton.XButton1))
            {
                NativeMethods.PostMessage(windowHandle, WM_XBUTTONDBLCLK, (IntPtr)MK_XBUTTON1, parameter);
            }

            if (button.HasFlag(MouseButton.XButton2))
            {
                NativeMethods.PostMessage(windowHandle, WM_XBUTTONDBLCLK, (IntPtr)MK_XBUTTON2, parameter);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IntPtr MakePointParameter(int x, int y) => (IntPtr)((uint)x | (uint)(y << 16));
    }
}
