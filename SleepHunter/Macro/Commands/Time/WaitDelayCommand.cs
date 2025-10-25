using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Time
{
    public sealed class WaitDelayCommand : MacroCommand
    {
        public TimeSpan Delay { get; }

        public WaitDelayCommand(int milliseconds)
        : this(TimeSpan.FromMilliseconds(milliseconds)) { }

        public WaitDelayCommand(TimeSpan delay)
        {
            Delay = delay;
        }

        public override async Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            await Task.Delay(Delay, context.CancellationToken);
            return MacroCommandResult.Continue;
        }

        public override string ToString()
        {
            var totalMilliseconds = (int)Delay.TotalMilliseconds;
            if (totalMilliseconds == 0)
            {
                return "Zero Delay";
            }

            if (totalMilliseconds == 1)
            {
                return "Wait 1 ms";
            }

            if (totalMilliseconds < 1000)
            {
                return $"Wait {totalMilliseconds} ms";
            }
            if (totalMilliseconds == 1000)
            {
                return "Wait 1 second";           
            }

            var totalSeconds = totalMilliseconds / 1000.0;
            return $"Wait {totalSeconds} seconds";
        }
    }
}
