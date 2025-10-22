
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterMouseCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseLeftClick,
                DisplayName = "Left Click",
                Description = "Clicks the left mouse button at the current pointer position."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseRightClick,
                DisplayName = "Right Click",
                Description = "Clicks the right mouse button at the current pointer position."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseMove,
                DisplayName = "Move Cursor",
                Description = "Moves the mouse pointer to the position specified.",
                Parameters = { MacroParameterType.Point }               
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseSavePosition,
                DisplayName = "Save Cursor Position",
                Description = "Saves the mouse pointer's current position so it can be recalled later."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseRecallPosition,
                DisplayName = "Recall Cursor Position",
                Description = "Recalls the mouse pointer to the last saved position."
            });
        }
    }
}
