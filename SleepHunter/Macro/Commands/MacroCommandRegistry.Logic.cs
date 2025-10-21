
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterLogicCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Logic,
                Key = "IF_ELSE",
                DisplayName = "Else",
                Description = "Adds a statement for performing actions if conditions are not met."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Logic,
                Key = "IF_END",
                DisplayName = "End If",
                Description = "Closes the nearest if statement block."
            });
        }
    }
}
