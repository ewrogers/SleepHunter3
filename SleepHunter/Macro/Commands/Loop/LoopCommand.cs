using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class LoopCommand : MacroCommand
    {
        public int LoopCount { get; }

        public LoopCommand()
            : this(-1)
        {
        }

        public LoopCommand(int loopCount)
        {
            LoopCount = loopCount;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var currentIndex = context.CurrentCommandIndex;
            var endLoopIndex = context.StructureCache.GetEndLoopIndex(currentIndex);

            // Create a new loop state
            var loopState = new MacroLoopState
            {
                LoopType = MacroLoopType.Loop,
                LoopStartIndex = currentIndex,
                EndLoopIndex = endLoopIndex,
                CurrentIteration = 0,
                MaxIterations = LoopCount
            };

            // Push the loop state onto the context stack
            context.PushLoopState(loopState);

            // For finite loops, check if we should execute at least once
            if (!loopState.IsInfinite && loopState.CurrentIteration >= loopState.MaxIterations)
            {
                context.PopLoopState();
                return Task.FromResult(MacroCommandResult.JumpToIndex(endLoopIndex + 1));
            }

            // Continue to the first command within the loop
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString()
        {
            if (LoopCount < 1)
            {
                return "Loop";
            }

            return LoopCount == 1 ? "Loop Once" : $"Loop {LoopCount} Times";
        }
    }
}
