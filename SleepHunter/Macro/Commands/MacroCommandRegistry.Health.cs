
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterHealthCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = "IF_HP_VALUE",
                DisplayName = "If HP",
                Description = "Performs the actions if the current health value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = "IF_HP_PERCENT",
                DisplayName = "If HP %",
                Description = "Performs the actions if the current health percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = "WHILE_HP_VALUE",
                DisplayName = "While HP",
                Description = "Loops actions while the current health value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Health,
                Key = "WHILE_HP_PERCENT",
                DisplayName = "While HP %",
                Description = "Loops actions while the current health percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });
        }
    }
}
