
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterLoopCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = MacroCommandKey.LoopInfinite,
                DisplayName = "Loop",
                Description = "Repeats actions until the loop is broken."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = MacroCommandKey.LoopCount,
                DisplayName = "Loop Count",
                Description = "Repeats actions a certain number of times.",
                Parameters = { MacroParameterType.Integer }
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = MacroCommandKey.LoopReset,
                DisplayName = "Loop Reset",
                Description = "Restarts the loop and resets the loop counter to zero.",
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = MacroCommandKey.Continue,
                DisplayName = "Continue",
                Description = "Restarts the loop or while block.",
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = MacroCommandKey.Break,
                DisplayName = "Break",
                Description = "Breaks from the current loop or while block."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = MacroCommandKey.EndLoop,
                DisplayName = "End Loop",
                Description = "Closes the nearest loop statement block."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Loop,
                Key = MacroCommandKey.EndWhile,
                DisplayName = "End While",
                Description = "Closes the nearest while statement block."
            });
        }
    }
}
