namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterInterfaceCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToInventoryPane,
                DisplayName = "Switch to Inventory Pane",
                Description = "Switches to the inventory pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToTemuairSkillPane,
                DisplayName = "Switch to Temuair Skill Pane",
                Description = "Switches to the Temuair skill pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToTemuairSpellPane,
                DisplayName = "Switch to Temuair Spell Pane",
                Description = "Switches to the Temuair spell pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToMedeniaSkillPane,
                DisplayName = "Switch to Medenia Skill Pane",
                Description = "Switches to the Medenia skill pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToMedeniaSpellPane,
                DisplayName = "Switch to Medenia Spell Pane",
                Description = "Switches to the Medenia spell pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToChatPane,
                DisplayName = "Switch to Chat Pane",
                Description = "Switches to the chat pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToStatsPane,
                DisplayName = "Switch to Status Pane",
                Description = "Switches to the character status pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToWorldSkillSpellPane,
                DisplayName = "Switch to World Skill/Spell Pane",
                Description = "Switches to the world skill/spell pane."
            });
        }
    }
}