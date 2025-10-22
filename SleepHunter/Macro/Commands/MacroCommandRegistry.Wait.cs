
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterWaitCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Wait,
                Key = MacroCommandKey.WaitDelay,
                DisplayName = "Wait Delay",
                Description = "Waits the specified number of milliseconds.",
                Parameters = { MacroParameterType.Integer }
            });
        }
    }
}
