using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Serialization;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        private void CopyToClipboard(IReadOnlyList<int> indexes)
        {
            var commands = indexes.Select(index => macroCommands[index])
                .Select(commandObj => new SerializableMacroCommand(commandObj.Definition, commandObj.Parameters))
                .ToList();

            var jsonString = serializer.Serialize(commands);
            var dataObject = new DataObject();

            // This lets people copy and paste the text into a text editor or other application
            dataObject.SetData(DataFormats.Text, jsonString);
            dataObject.SetData(DataFormats.UnicodeText, jsonString);

            // This is what we will look for first, but can fall back to text
            dataObject.SetData("MacroCommands", jsonString);

            Clipboard.SetDataObject(dataObject, true);
        }

        private bool TryPasteFromClipboard()
        {
            string json = null;

            if (Clipboard.ContainsData("MacroCommands"))
            {
                json = Clipboard.GetData("MacroCommands") as string;
            }
            else if (Clipboard.ContainsText())
            {
                json = Clipboard.GetText();
            }

            if (string.IsNullOrWhiteSpace(json))
            {
                return false;
            }

            var hasError = false;

            try
            {
                var commands = serializer.Deserialize(json);

                if (commands == null || commands.Count == 0)
                {
                    return false;
                }

                var insertIndex = macroListView.SelectedIndices.Count > 0
                    ? macroListView.SelectedIndices[macroListView.SelectedIndices.Count - 1] + 1
                    : macroCommands.Count;

                for (var i = 0; i < commands.Count; i++)
                {
                    var command = commands[i];

                    // Try to get the command definition
                    if (!commandRegistry.TryGetCommand(command.Key, out var definition) || definition == null)
                    {
                        hasError = true;
                        MessageBox.Show(this, $"Unknown command: {command.Key}", "Paste Commands Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    }

                    // Create the command parameters
                    var parameters =
                        command.Parameters?.Select(p => new MacroParameterValue(p.Type, p.Value)).ToArray() ??
                        Array.Empty<MacroParameterValue>();

                    // Add the command to the list (add closing tag only if this the last command in the pasted set)
                    var isLastCommand = i + 1 >= commands.Count;
                    AddMacroCommand(definition, parameters, insertIndex++, addClosingCommand: isLastCommand, autoSelect: true, validate: false);
                }

                return !hasError;
            }
            catch (JsonException)
            {
                MessageBox.Show(this, "Invalid command syntax.", "Paste Commands Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Failed to create commands.", "Paste Commands Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }
            finally
            {
                ValidateMacro();

                UpdateToolbarAndMenuState();
                UpdateStatusBarState();
            }
        }
    }
}