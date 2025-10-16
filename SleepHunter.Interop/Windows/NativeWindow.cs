using System;

namespace SleepHunter.Interop.Windows
{
    public readonly struct NativeWindow
    {
        public IntPtr Handle { get; }
        public string Title { get; }
        public string ClassName { get; }
        public int ProcessId { get; }

        public NativeWindow(IntPtr windowHandle, string windowTitle, string windowClass, int processId)
        {
            Handle = windowHandle;
            Title = windowTitle;
            ClassName = windowClass;
            ProcessId = processId;
        }
    }
}
