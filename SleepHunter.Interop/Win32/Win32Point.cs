using System.Runtime.InteropServices;

namespace SleepHunter.Interop.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Win32Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}