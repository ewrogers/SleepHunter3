using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class ContinueCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var loopState = context.PeekLoopState();

            // If not in a loop, do nothing and proceed
            if (loopState == null)
            {
                return Task.FromResult(MacroCommandResult.Continue);
            }

            switch (loopState.LoopType)
            {
                case MacroLoopType.Loop:
                    // For loops, increment the counter and jump to the end for evaluation
                    loopState.CurrentIteration += 1;
                    return Task.FromResult(MacroCommandResult.JumpToIndex(loopState.EndLoopIndex));

                case MacroLoopType.While:
                    // For while loops, increment the counter and jump back to the while command for condition check
                    loopState.CurrentIteration += 1;
                    return Task.FromResult(MacroCommandResult.JumpToIndex(loopState.LoopStartIndex));
            }

            // Should never get here, but just in case...
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => "Continue";
    }
}
