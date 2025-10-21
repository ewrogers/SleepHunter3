
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterKeyboardCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Keyboard,
                Key = "KEYBOARD_SEND_KEYS",
                DisplayName = "Send Keystrokes",
                Description = "Sends the specified keystrokes as if they keyboard typed them.",
                Parameters = { MacroParameterType.Keystrokes }
            });
        }
    }
}
