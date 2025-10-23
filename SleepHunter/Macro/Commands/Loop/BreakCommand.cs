using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class BreakCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => "Break";
    }
}
