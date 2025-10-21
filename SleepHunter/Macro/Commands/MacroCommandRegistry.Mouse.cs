
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterMouseCommands()
        {
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = "MOUSE_LEFT_CLICK",
                DisplayName = "Left Click",
                Description = "Clicks the left mouse button at the current pointer position."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = "MOUSE_RIGHT_CLICK",
                DisplayName = "Right Click",
                Description = "Clicks the right mouse button at the current pointer position."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = "MOUSE_MOVE",
                DisplayName = "Move Cursor",
                Description = "Moves the mouse pointer to the position specified.",
                Parameters = { MacroParameterType.Point }               
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = "MOUSE_SAVE_POSITION",
                DisplayName = "Save Cursor Position",
                Description = "Saves the mouse pointer's current position so it can be recalled later."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = "MOUSE_LOAD_POSITION",
                DisplayName = "Recall Cursor Position",
                Description = "Recalls the mouse pointer to the last saved position."
            });
        }
    }
}
