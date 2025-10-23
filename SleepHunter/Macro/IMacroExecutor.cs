using System;
using System.Threading.Tasks;
using SleepHunter.Models;

namespace SleepHunter.Macro
{
    public interface IMacroExecutor : IDisposable
    {
        MacroRunState State { get; }
        MacroStopReason StopReason { get; }

        event Action<MacroRunState> StateChanged;
        event Action<Exception> Exception;

        Task StartAsync();
        Task StopAsync();
    }
}
