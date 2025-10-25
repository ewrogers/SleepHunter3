using System;
using System.Linq;
using SleepHunter.Macro;
using SleepHunter.Macro.Commands.Jump;
using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        private void ValidateCommand(MacroCommandObject commandObj)
        {
            // Check for duplicate labels
            if (commandObj.Command is DefineLabelCommand labelCommand)
            {
                var labelName = labelCommand.Label;
                for (var i = 0; i < macroCommands.Count; i++)
                {
                    var existingCommand = macroCommands[i];
                    if (existingCommand.Command is DefineLabelCommand existingLabel &&
                        string.Equals(existingLabel.Label, labelName, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new MacroValidationException($"Label '{existingLabel.Label}' is already defined.", i);
                    }
                }
            }
        }

        private void ValidateMacro()
        {
            try
            {
                _ = new MacroStructureCache(macroCommands.Select(c => c.Command).ToList());

                ClearHighlight();
                validationErrorMessage = null;
            }
            catch (MacroValidationException ex)
            {
                validationErrorMessage = ex.Message;
                ClearHighlight();
                HighlightItem(ex.CommandIndex, ValidationHighlightColor);
            }

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }
    }
}