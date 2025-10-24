using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class BreakCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var loopState = context.PeekLoopState();

            // If not in a loop, do nothing and proceed
            if (loopState == null)
            {
                return Task.FromResult(MacroCommandResult.Continue);
            }

            // Pop the inner loop state
            context.PopLoopState();

            // Jump to the command after the loop
            return Task.FromResult(MacroCommandResult.JumpToIndex(loopState.EndLoopIndex + 1));
        }

        public override string ToString() => "Break";
    }
}
