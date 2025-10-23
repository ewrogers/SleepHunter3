using System;
using System.Linq;
using System.Windows.Forms;
using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Serialization;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        public SerializableMacroDocument GetMacroDocument()
        {
            var document = new SerializableMacroDocument
            {
                Name = macroName.Trim(),
                Author = macroAuthor.Trim(),
            };

            foreach (var command in macroCommands)
            {
                document.Commands.Add(new SerializableMacroCommand(command.Definition, command.Parameters));
            }

            return document;
        }

        public bool LoadMacroDocument(SerializableMacroDocument document)
        {
            macroListView.Items.Clear();
            macroListView.BeginUpdate();

            try
            {
                macroCommands.Clear();

                var hasError = false;
                foreach (var command in document.Commands)
                {
                    // Try to get the command definition
                    if (!commandRegistry.TryGetCommand(command.Key, out var definition) || definition == null)
                    {
                        hasError = true;
                        MessageBox.Show(this, $"Unknown command: {command.Key}", "Load Commands Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    }

                    // Create the command parameters
                    var parameters =
                        command.Parameters?.Select(p => new MacroParameterValue(p.Type, p.Value)).ToArray() ??
                        Array.Empty<MacroParameterValue>();
                    AddMacroCommand(definition, parameters, addClosingCommand: false, autoSelect: false);
                }

                nameTextBox.Text = macroName = document.Name.Trim();
                authorTextBox.Text = macroAuthor = document.Author.Trim();

                return !hasError;
            }
            catch
            {
                MessageBox.Show(this, "Failed to load commands.", "Load Commands Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }
            finally
            {
                macroListView.EndUpdate();
                UpdateProcessUI();
            }
        }
    }
}