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
            if (lineNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lineNumber), "Line number must be greater than or equal to 0");
            }
            
            LineNumber = lineNumber;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Convert 1-based index to 0-based index
            var targetIndex = Math.Max(0, LineNumber - 1);

            // Cleanup any loop states that this jump would exit
            context.CleanupLoopStatesForJump(targetIndex);

            // Jump to the target index, executor will cap it at the end of the macro
            return Task.FromResult(MacroCommandResult.JumpToIndex(targetIndex));
        }

        public override string ToString() => $"Goto Line {LineNumber}";
    }
}
