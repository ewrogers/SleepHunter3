namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterMapCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.IfMapName,
                DisplayName = "If Map Name",
                Description = "Performs actions if the map name matches a certain condition.",
                Parameters = { MacroParameterType.StringCompareOperator, MacroParameterType.String },
                MaxLength = 50,
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.IfMapNumber,
                DisplayName = "If Map Number",
                Description = "Performs actions if the map number matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.IfMapX,
                DisplayName = "If Map X",
                Description = "Performs actions if the map X coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.IfMapY,
                DisplayName = "If Map Y",
                Description = "Performs actions if the map Y coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.WhileMapName,
                DisplayName = "While Map Name",
                Description = "Repeats actions while the map name matches a certain condition.",
                Parameters = { MacroParameterType.StringCompareOperator, MacroParameterType.String },
                MaxLength = 50
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.WhileMapNumber,
                DisplayName = "While Map Number",
                Description = "Repeats actions while the map number matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.WhileMapX,
                DisplayName = "While Map X",
                Description = "Loops actions while the map X coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = MacroCommandKey.WhileMapY,
                DisplayName = "While Map Y",
                Description = "Repeats actions while the map X coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });
        }
    }
}