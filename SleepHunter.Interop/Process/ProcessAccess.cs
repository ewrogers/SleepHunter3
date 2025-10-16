using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepHunter.Interop.Process
{
    [Flags]
    public enum ProcessAccess
    {
        Read = 1,
        Write = 2,
        ReadWrite = Read | Write,
    }
}
