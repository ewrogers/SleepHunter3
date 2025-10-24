using System;
using SleepHunter.Macro.Conditions;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Logic
{
    public sealed class IfCommand : MacroCommand
    {
        private readonly IMacroCondition condition;
        private readonly string fieldName;

        public IfCommand(IMacroCondition condition, string fieldName = null)
        {
            this.condition = condition ?? throw new ArgumentNullException(nameof(condition));
            this.fieldName = fieldName ?? "Value";
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var conditionMet = condition.Evaluate(context);

            if (conditionMet)
            {
                // Condition is true, continue to the next command within
                return Task.FromResult(MacroCommandResult.Continue);
            }

            // Condition is false, find where to jump
            var currentIndex = context.CurrentCommandIndex;
            var elseIndex = context.StructureCache.GetElseIndex(currentIndex);

            if (elseIndex >= 0)
            {
                // Jump to the Else command
                return Task.FromResult(MacroCommandResult.JumpToIndex(elseIndex + 1));
            }

            // No else, jump to the end If statement
            var endIfIndex = context.StructureCache.GetEndIfIndex(currentIndex);
            return Task.FromResult(MacroCommandResult.JumpToIndex(endIfIndex + 1));
        }

        public override string ToString() => $"If {fieldName} {condition}";
    }
}
