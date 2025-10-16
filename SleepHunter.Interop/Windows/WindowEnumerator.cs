using SleepHunter.Interop.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace SleepHunter.Interop.Windows
{
    public sealed class WindowEnumerator : IWindowEnumerator
    {
        public IReadOnlyList<NativeWindow> FindWindows(string findClassName, string findWindowTitle = null)
        {
            var windows = new List<NativeWindow>();

            // Enumerate all top-level windows
            NativeMethods.EnumWindows((windowHandle, lParam) =>
            {
                var threadId = NativeMethods.GetWindowThreadProcessId(windowHandle, out var processId);

                // Get the window class
                var classNameBuffer = new StringBuilder(256);
                var classNameLength = NativeMethods.GetClassName(windowHandle, classNameBuffer, classNameBuffer.Capacity);
                var className = classNameBuffer.ToString(0, classNameLength);

                // Check if the window class name matches the desired window class (if provided)
                if (!string.IsNullOrWhiteSpace(findClassName) && !string.Equals(className, findClassName, StringComparison.Ordinal))
                {
                    return true;
                }

                // Get the window title
                var windowTitleLength = NativeMethods.GetWindowTextLength(windowHandle);
                var windowTitleBuffer = new StringBuilder(windowTitleLength + 1);
                windowTitleLength = NativeMethods.GetWindowText(windowHandle, windowTitleBuffer, windowTitleBuffer.Capacity);
                var windowTitle = windowTitleBuffer.ToString(0, windowTitleLength);

                // Check if the window title matches the desired window title (if provided)
                if (!string.IsNullOrWhiteSpace(findWindowTitle) && !string.Equals(windowTitle, findWindowTitle, StringComparison.Ordinal))
                {
                    return true;
                }

                // Add the window to the matches
                var window = new NativeWindow(windowHandle, windowTitle, className, processId);
                windows.Add(window);
                return true;
            }, IntPtr.Zero);

            return windows;
        }
    }
}
