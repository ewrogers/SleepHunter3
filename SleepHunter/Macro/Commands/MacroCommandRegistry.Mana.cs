
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterManaCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = MacroCommandKey.IfManaValue,
                DisplayName = "If MP",
                Description = "Performs actions if the current mana value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = MacroCommandKey.IfManaPercent,
                DisplayName = "If MP %",
                Description = "Performs actions if the current mana percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = MacroCommandKey.WhileManaValue,
                DisplayName = "While MP",
                Description = "Repeats actions while the current mana value matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mana,
                Key = MacroCommandKey.WhileManaPercent,
                DisplayName = "While MP %",
                Description = "Repeats actions while the current mana percentage matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Float },
            });
        }
    }
}
