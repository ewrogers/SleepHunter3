using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class EndLoopCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var loopState = context.PeekLoopState();

            // If not in a loop, do nothing and proceed
            if (loopState == null || loopState.LoopType != MacroLoopType.Loop)
            {
                return Task.FromResult(MacroCommandResult.Continue);
            }

            loopState.CurrentIteration += 1;

            // Check if we should continue looping
            if (loopState.IsInfinite || loopState.CurrentIteration < loopState.MaxIterations)
            {
                return Task.FromResult(MacroCommandResult.JumpToIndex(loopState.LoopStartIndex + 1));
            }

            // Loop has completed, pop the loop state and continue normally
            context.PopLoopState();
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => "End Loop";
    }
}
