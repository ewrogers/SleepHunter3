using SleepHunter.Macro.Conditions;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class WhileCommand : MacroCommand
    {
        private readonly IMacroCondition condition;
        private readonly string fieldName;

        // These will be set later by the macro execution engine
        public EndWhileCommand EndWhile { get; set; }

        public WhileCommand(IMacroCondition condition, string fieldName = null)
        {
            this.condition = condition;
            this.fieldName = fieldName ?? "Value";
        }

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            // Determine if the condition is true, and jump if necessary
            var result = condition.Evaluate(context);

            return Task.FromResult(MacroCommandResult.NoOp);
        }

        public override string ToString() => $"While {fieldName} {condition}";
    }
}
