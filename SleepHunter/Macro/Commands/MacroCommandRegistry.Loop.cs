
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterLoopCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = "LOOP_INFINITE",
                DisplayName = "Loop",
                Description = "Repeats actions until the loop is broken."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = "LOOP_COUNT",
                DisplayName = "Loop Count",
                Description = "Repeats actions a certain number of times.",
                Parameters = { MacroParameterType.Integer }
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = "LOOP_BREAK",
                DisplayName = "Loop Break",
                Description = "Breaks from the current loop."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = "LOOP_END",
                DisplayName = "End Loop",
                Description = "Closes the nearest loop statement block."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = "WHILE_END",
                DisplayName = "End While",
                Description = "Closes the nearest while statement block."
            });
        }
    }
}
