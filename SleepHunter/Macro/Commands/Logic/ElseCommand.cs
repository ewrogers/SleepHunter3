using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Logic
{
    public sealed class ElseCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var currentIndex = context.CurrentCommandIndex;
            var endIfIndex = context.StructureCache.GetEndIfIndex(currentIndex);

            // Jump to the end of the If statement or continue if not found
            return Task.FromResult(endIfIndex >= 0
                ? MacroCommandResult.JumpToIndex(endIfIndex + 1)
                : MacroCommandResult.Continue);
        }

        public override string ToString() => "Else";
    }
}
