namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterInterfaceCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_INVENTORY",
                DisplayName = "Switch to Inventory Pane",
                Description = "Switches to the inventory pane."
            });
            
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_TEMUAIR_SKILL",
                DisplayName = "Switch to Temuair Skill Pane",
                Description = "Switches to the Temuair skill pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_TEMUAIR_SPELL",
                DisplayName = "Switch to Temuair Spell Pane",
                Description = "Switches to the Temuair spell pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_MEDENIA_SKILL",
                DisplayName = "Switch to Medenia Skill Pane",
                Description = "Switches to the Medenia skill pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_MEDENIA_SPELL",
                DisplayName = "Switch to Medenia Spell Pane",
                Description = "Switches to the Medenia spell pane."
            });
            
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_CHAT",
                DisplayName = "Switch to Chat Pane",
                Description = "Switches to the chat pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_STATUS",
                DisplayName = "Switch to Status Pane",
                Description = "Switches to the character status pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = "INTERFACE_WORLD_SKILL_SPELL",
                DisplayName = "Switch to World Skill/Spell Pane",
                Description = "Switches to the world skill/spell pane."
            });
        }
    }
}