using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class BreakCommand : MacroCommand
    {
        // These are set by the macro execution engine
        public MacroCommand Parent { get; set; }

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => "Break";
    }
}
