using System;
using SleepHunter.Macro.Conditions;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class WhileCommand : MacroCommand
    {
        private readonly IMacroCondition condition;
        private readonly string fieldName;

        public WhileCommand(IMacroCondition condition, string fieldName = null)
        {
            this.condition = condition ?? throw new ArgumentNullException(nameof(condition));
            this.fieldName = fieldName ?? "Value";
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var currentIndex = context.CurrentCommandIndex;
            var endWhileIndex = context.StructureCache.GetEndWhileIndex(currentIndex);

            var existingLoopState = context.PeekLoopState();
            var isReentry = existingLoopState != null && existingLoopState.LoopType == MacroLoopType.While &&
                            existingLoopState.LoopStartIndex == currentIndex;
            
            // Evaluate the condition
            var conditionMet = condition.Evaluate(context);
            
            if (!conditionMet)
            {
                // Pop the loop state if we're exiting the loop
                if (isReentry)
                {
                    context.PopLoopState();
                }
                
                // Condition is false, skip the while loop
                return Task.FromResult(MacroCommandResult.JumpToIndex(endWhileIndex + 1));
            }

            if (!isReentry)
            {
                var loopState = new MacroLoopState
                {
                    LoopType = MacroLoopType.While,
                    LoopStartIndex = currentIndex,
                    EndLoopIndex = endWhileIndex,
                    CurrentIteration = 0,
                    MaxIterations = -1 // Infinite, controlled by condition instead
                };

                // Push the loop state onto the context stack
                context.PushLoopState(loopState);
            }
            else
            {
                existingLoopState.CurrentIteration += 1;
            }

            // Continue to the first command within the loop
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => $"While {fieldName} {condition}";
    }
}
