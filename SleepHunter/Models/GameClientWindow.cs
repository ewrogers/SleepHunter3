using System;

namespace SleepHunter.Models
{
    public readonly struct GameClientWindow
    {
        public IntPtr WindowHandle { get; }
        public int ProcessId { get; }

        public GameClientWindow(IntPtr windoHandle, int processId)
        {
            WindowHandle = windoHandle;
            ProcessId = processId;
        }
    }
}
