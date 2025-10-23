using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Jump
{
    public sealed class GotoLineCommand : MacroCommand
    {
        // This can be updated when its relative position changes
        public int LineNumber { get; set; }

        public GotoLineCommand(int lineNumber)
        {
            LineNumber = lineNumber;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"Goto Line {LineNumber}";
    }
}
