
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
                Key = MacroCommandKey.MouseLeftDoubleClick,
                DisplayName = "Double Left Click",
                Description = "Double-clicks the left mouse button at the current pointer position."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseLeftButtonDown,
                DisplayName = "Left Mouse Button Down",
                Description = "Begins holding the left mouse button down at the current pointer position."
            });
            
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseLeftButtonUp,
                DisplayName = "Left Mouse Button Up",
                Description = "Releases the left mouse button at the current pointer position."
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
                Key = MacroCommandKey.MouseRightDoubleClick,
                DisplayName = "Double Right Click",
                Description = "Double-clicks the right mouse button at the current pointer position."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseRightButtonDown,
                DisplayName = "Right Mouse Button Down",
                Description = "Begins holding the right mouse button down at the current pointer position."
            });
            
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseRightButtonUp,
                DisplayName = "Right Mouse Button Up",
                Description = "Releases the right mouse button at the current pointer position."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseMove,
                DisplayName = "Move Mouse",
                Description = "Moves the mouse pointer to the position specified.",
                Parameters = { MacroParameterType.Integer, MacroParameterType.Integer }               
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseMoveOffset,
                DisplayName = "Move Mouse Offset",
                Description = "Moves the mouse pointer by the offset specified.",
                Parameters = { MacroParameterType.Integer, MacroParameterType.Integer }
            });
            
            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseDrag,
                DisplayName = "Drag Mouse",
                Description = "Click and drag from the current position to the position specified.",
                Parameters = { MacroParameterType.Integer, MacroParameterType.Integer }
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseDragOffset,
                DisplayName = "Drag Mouse Offset",
                Description = "Click and drag from the current position by the offset specified.",
                Parameters = { MacroParameterType.Integer, MacroParameterType.Integer }
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseSavePosition,
                DisplayName = "Save Mouse Position",
                Description = "Saves the last mouse move position so it can be recalled later."
            });

            RegisterCommand(new MacroCommandDefinition
            {
                Category = MacroCommandCategory.Mouse,
                Key = MacroCommandKey.MouseRecallPosition,
                DisplayName = "Recall Mouse Position",
                Description = "Recalls the mouse position to the last saved position."
            });
        }
    }
}
