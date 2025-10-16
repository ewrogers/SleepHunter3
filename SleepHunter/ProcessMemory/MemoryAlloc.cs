using System;
using System.Diagnostics;

namespace ProcessMemory
{
    public class MemoryAlloc
    {
        private uint m_ProcessID;
        private ulong m_WindowHandle;
        private bool m_IsAttached;
        private ulong m_ProcHandle;

        public MemoryAlloc()
        {
            this.m_ProcessID = 0U;
            this.m_WindowHandle = 0UL;
            this.m_IsAttached = false;
        }

        public MemoryAlloc(ulong WindowHandle)
        {
            this.m_WindowHandle = WindowHandle;
            int windowThreadProcessId = (int)User32.GetWindowThreadProcessId(WindowHandle, out this.m_ProcessID);
            if (this.m_ProcessID == 0U)
                return;
            this.AttachByPID(this.m_ProcessID);
        }

        public MemoryAlloc(uint ProcessID)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if ((long)process.Id == (long)ProcessID)
                {
                    this.m_ProcessID = (uint)process.Id;
                    this.m_WindowHandle = (ulong)(long)process.MainWindowHandle;
                    this.AttachByPID(this.m_ProcessID);
                }
            }
        }

        public MemoryAlloc(string WindowTitle)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.MainWindowTitle == WindowTitle)
                {
                    this.m_ProcessID = (uint)process.Id;
                    this.m_WindowHandle = (ulong)(long)process.MainWindowHandle;
                    this.AttachByPID(this.m_ProcessID);
                }
            }
        }

        ~MemoryAlloc()
        {
            if (this.m_ProcHandle == 0UL)
                return;
            Kernel32.CloseHandle(this.m_ProcHandle);
        }

        public ulong ProcHandle => this.m_ProcHandle;

        public uint ProcessID => this.m_ProcessID;

        public ulong WindowHandle => this.m_WindowHandle;

        public string WindowTitle
        {
            get
            {
                if (this.m_WindowHandle == 0UL)
                    return string.Empty;
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.MainWindowHandle == (IntPtr)(long)this.m_WindowHandle)
                        return process.MainWindowTitle;
                }
                return string.Empty;
            }
        }

        public string ProcessName
        {
            get
            {
                if (this.m_ProcessID == 0U)
                    return string.Empty;
                foreach (Process process in Process.GetProcesses())
                {
                    if ((long)process.Id == (long)this.m_ProcessID)
                        return process.ProcessName + ".exe";
                }
                return string.Empty;
            }
        }

        public bool IsAttached => this.m_IsAttached;

        public bool IsRunning => this.IsProcessRunning(this.m_ProcessID, this.ProcessName);

        public bool AttachByPID(uint ProcessID)
        {
            if (this.m_ProcHandle != 0UL)
                Kernel32.CloseHandle(this.m_ProcHandle);
            this.m_ProcHandle = (ulong)(long)Kernel32.OpenProcess(2035711U, false, ProcessID);
            this.m_IsAttached = this.m_ProcHandle != 0UL;
            return this.m_IsAttached;
        }

        public bool AttachByHwnd(ulong WindowHandle)
        {
            if (this.m_ProcHandle != 0UL)
                Kernel32.CloseHandle(this.m_ProcHandle);
            this.m_WindowHandle = WindowHandle;
            int windowThreadProcessId = (int)User32.GetWindowThreadProcessId(WindowHandle, out this.m_ProcessID);
            this.m_ProcHandle = (ulong)(long)Kernel32.OpenProcess(2035711U, false, this.m_ProcessID);
            this.m_IsAttached = this.m_ProcHandle != 0UL;
            return this.m_IsAttached;
        }

        public bool AttachByWinTitle(string WinTitle)
        {
            if (this.m_ProcHandle != 0UL)
                Kernel32.CloseHandle(this.m_ProcHandle);
            foreach (Process process in Process.GetProcesses())
            {
                if (process.MainWindowTitle == this.WindowTitle)
                {
                    this.m_ProcessID = (uint)process.Id;
                    this.m_WindowHandle = (ulong)(long)process.MainWindowHandle;
                }
            }
            this.m_ProcHandle = (ulong)(long)Kernel32.OpenProcess(2035711U, false, this.m_ProcessID);
            this.m_IsAttached = this.m_ProcHandle != 0UL;
            return this.m_IsAttached;
        }

        public bool AttachByEXEName(string EXEName)
        {
            if (this.m_ProcHandle != 0UL)
                Kernel32.CloseHandle(this.m_ProcHandle);
            foreach (Process process in Process.GetProcesses())
            {
                if ((process.ProcessName + ".exe").ToUpper() == EXEName.ToUpper())
                {
                    this.m_ProcessID = (uint)process.Id;
                    this.m_WindowHandle = (ulong)(long)process.MainWindowHandle;
                }
            }
            this.m_ProcHandle = (ulong)(long)Kernel32.OpenProcess(2035711U, false, this.m_ProcessID);
            this.m_IsAttached = this.m_ProcHandle != 0UL;
            return this.m_IsAttached;
        }

        public bool DetachProcess()
        {
            bool flag;
            if (this.m_ProcHandle != 0UL)
            {
                Kernel32.CloseHandle(this.m_ProcHandle);
                flag = true;
            }
            else
                flag = false;
            this.m_IsAttached = false;
            this.m_ProcessID = 0U;
            this.m_ProcHandle = 0UL;
            this.m_WindowHandle = 0UL;
            return flag;
        }

        private bool IsProcessRunning(uint ProcessID, string EXEName)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if ((long)process.Id == (long)ProcessID & (process.ProcessName + ".exe").Equals(EXEName, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}