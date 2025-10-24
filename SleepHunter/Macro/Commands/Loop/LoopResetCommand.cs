using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class LoopResetCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var loopState = context.PeekLoopState();

            // If not in a loop, do nothing and proceed
            if (loopState == null || loopState.LoopType != MacroLoopType.Loop)
            {
                return Task.FromResult(MacroCommandResult.Continue);
            }

            // Reset the counter and continue to the first command within the loop
            loopState.CurrentIteration = 0;
            return Task.FromResult(MacroCommandResult.JumpToIndex(loopState.LoopStartIndex + 1));
        }

        public override string ToString() => "Loop Reset";
    }
}
