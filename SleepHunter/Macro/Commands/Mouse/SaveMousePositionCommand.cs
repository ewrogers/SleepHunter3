using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class SaveMousePositionCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => "Save Mouse Position";
    }
}
