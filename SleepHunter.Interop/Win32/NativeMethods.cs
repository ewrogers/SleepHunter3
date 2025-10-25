using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SleepHunter.Interop.Win32
{

    [return: MarshalAs(UnmanagedType.Bool)]
    internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    internal static class NativeMethods
    {
        #region User32.dll

        [DllImport("user32.dll", EntryPoint = "EnumWindows", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumWindows(EnumWindowsProc enumWindowsProc, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        [DllImport("user32.dll", EntryPoint = "GetClassName", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int maxLength);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder buffer, int maxLength);

        [DllImport("user32", EntryPoint = "PostMessage", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool PostMessage(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam);

        [DllImport("user32", EntryPoint = "SendMessage", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam);

        [DllImport("user32", EntryPoint = "GetCursorPos", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out Win32Point point);

        [DllImport("user32", EntryPoint = "MapVirtualKey", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern uint MapVirtualKey(uint uCode, Win32VirtualKeyMapType mapType);

        [DllImport("user32", EntryPoint = "VkKeyScan", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern ushort VkKeyScan(char c);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint modifiers, uint virtualKey);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        
        #endregion

        #region Kernel32.dll

        [DllImport("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true)]
        internal static extern IntPtr OpenProcess(Win32ProcessAccessFlags desiredAccess, bool inheritHandle,
            int processId);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size,
            out int bytesRead);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size,
            out int bytesWritten);

        [DllImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr handle);

        #endregion
    }
}
