namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterMapCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "IF_MAP_X",
                DisplayName = "If Map X",
                Description = "Compares the map X coordinate against a certain value."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Map,
                Key = "IF_MAP_Y",
                DisplayName = "If Map Y",
                Description = "Compares the map Y coordinate against a certain value."
            });
        }
    }
}