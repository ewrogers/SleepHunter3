using SleepHunter.Macro.Conditions;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Logic
{
    public sealed class IfCommand : MacroCommand
    {
        private readonly IMacroCondition condition;
        private readonly string fieldName;

        // These will be set later by the macro execution engine
        public ElseCommand Else { get; set; }
        public EndIfCommand EndIf { get; set; }

        public IfCommand(IMacroCondition condition, string fieldName = null)
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

        public override string ToString() => $"If {fieldName} {condition}";
    }
}
