using System;
using System.Threading.Tasks;
using SleepHunter.Models;

namespace SleepHunter.Macro
{
    public interface IMacroExecutor : IDisposable
    {
        MacroRunState State { get; }
        MacroStopReason StopReason { get; }

        event Action<int> DebugStep;
        event Action<MacroRunState> StateChanged;
        event Action<Exception> Exception;

        void SetDebugStepEnabled(bool enabled);

        Task StartAsync();
        Task StopAsync();

        void Pause();
        void Resume();
    }
}
