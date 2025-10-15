using System;
using System.Runtime.InteropServices;

namespace ProcessMemory
{

    public class User32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(ulong hWnd, out uint lpdwProcessId);
    }
}