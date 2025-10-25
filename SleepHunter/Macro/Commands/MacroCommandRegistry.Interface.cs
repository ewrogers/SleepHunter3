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
                Key = MacroCommandKey.SwitchToChatHistoryPane,
                DisplayName = "Switch to Chat History Pane",
                Description = "Switches to the chat history pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToStatsPane,
                DisplayName = "Switch to Stats Pane",
                Description = "Switches to the character stats pane."
            });
            
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToModifiersPane,
                DisplayName = "Switch to Modifiers Pane",
                Description = "Switches to the character modifiers pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.SwitchToWorldSkillSpellPane,
                DisplayName = "Switch to World Skill/Spell Pane",
                Description = "Switches to the world skill/spell pane."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.IfChatInputOpen,
                DisplayName = "If Chat Input Open",
                Description = "Performs actions if the chat input text area is open."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.WhileChatInputOpen,
                DisplayName = "While Chat Input Open",
                Description = "Repeats actions while the chat input text area is open."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.IfMinimizedMode,
                DisplayName = "If Minimized Mode",
                Description = "Performs actions if the game viewport is in the minimized view mode.",
                HelpText = "This is when you click the button or press forward slash (/) key."
            });
            
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Interface,
                Key = MacroCommandKey.IfInventoryExpanded,
                DisplayName = "If Inventory Expanded",
                Description = "Performs actions if the inventory pane is expanded to show the entire inventory."
            });
        }
    }
}