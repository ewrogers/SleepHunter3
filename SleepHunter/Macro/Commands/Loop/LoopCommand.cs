using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class LoopCommand : MacroCommand
    {
        public int LoopCount { get; }

        public LoopCommand()
        : this(-1) { }

        public LoopCommand(int loopCount)
        {
            LoopCount = loopCount;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (LoopCount < 1)
            {
                return "Loop";
            }
            ;

            if (LoopCount == 1)
            {
                return "Loop Once";
            }

            return $"Loop {LoopCount} Times";
        }
    }
}
