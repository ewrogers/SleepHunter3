
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterKeyboardCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Keyboard,
                Key = MacroCommandKey.SendKeystrokes,
                DisplayName = "Send Keystrokes",
                Description = "Sends the specified keystrokes as if they were typed.",
                HelpText = "You can type a single or sequence of letters, numbers or symbols.\n\nFor special characters use <ESC>, <ENTER>, <SPACE>, <UP>, <DOWN>, <LEFT>, <RIGHT>, <TILDE>, etc.",
                Parameters = { MacroParameterType.Keystrokes }
            });
        }
    }
}
