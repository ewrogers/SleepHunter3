namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterMapCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "IF_MAP_NAME",
                DisplayName = "If Map Name",
                Description = "Performs actions if the map name matches a certain condition.",
                Parameters = { MacroParameterType.StringCompareOperator, MacroParameterType.String },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "IF_MAP_NUM",
                DisplayName = "If Map Number",
                Description = "Performs actions if the map number matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "IF_MAP_X",
                DisplayName = "If Map X",
                Description = "Performs actions if the map X coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "IF_MAP_Y",
                DisplayName = "If Map Y",
                Description = "Performs actions if the map Y coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "WHILE_MAP_NAME",
                DisplayName = "While Map Name",
                Description = "Repeats actions while the map name matches a certain condition.",
                Parameters = { MacroParameterType.StringCompareOperator, MacroParameterType.String },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "WHILE_MAP_NUM",
                DisplayName = "While Map Num",
                Description = "Repeats actions while the map number matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "WHILE_MAP_X",
                DisplayName = "While Map X",
                Description = "Loops actions while the map X coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "WHILE_MAP_Y",
                DisplayName = "While Map Y",
                Description = "Repeats actions while the map X coordinate matches a certain condition.",
                Parameters = { MacroParameterType.CompareOperator, MacroParameterType.Integer },
            });
        }
    }
}