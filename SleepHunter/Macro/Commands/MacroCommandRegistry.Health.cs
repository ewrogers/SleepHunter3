
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterHealthCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = MacroCommandKey.IfHealthValue,
                DisplayName = "If HP",
                Description = "Performs actions if the current health value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = MacroCommandKey.IfHealthPercent,
                DisplayName = "If HP %",
                Description = "Performs actions if the current health percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = MacroCommandKey.WhileHealthValue,
                DisplayName = "While HP",
                Description = "Repeats actions while the current health value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = MacroCommandKey.WhileHealthPercent,
                DisplayName = "While HP %",
                Description = "Repeats actions while the current health percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });
        }
    }
}
