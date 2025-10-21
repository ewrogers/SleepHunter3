
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterManaCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = "IF_MP_VALUE",
                DisplayName = "If MP",
                Description = "Performs the actions if the current mana value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = "IF_MP_PERCENT",
                DisplayName = "If MP %",
                Description = "Performs the actions if the current mana percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = "WHILE_MP_VALUE",
                DisplayName = "While MP",
                Description = "Loops actions while the current mana value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = "WHILE_MP_PERCENT",
                DisplayName = "While MP %",
                Description = "Loops actions while the current mana percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });
        }
    }
}
