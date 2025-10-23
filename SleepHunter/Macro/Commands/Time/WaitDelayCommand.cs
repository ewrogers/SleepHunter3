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

        public override async Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            await Task.Delay(Delay);
            return MacroCommandResult.NoOp;
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

            return $"Wait {totalMilliseconds} ms";
        }
    }
}
