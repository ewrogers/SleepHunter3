using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        #region Add Command Methods
        public void AddMacroCommand(MacroCommandDefinition definition, MacroParameterValue[] parameters, int desiredIndex = -1, bool addClosingCommand = true, bool autoSelect = true)
        {
            var success = false;
            try
            {
                // Attempt to create the built command with the parameters
                var command = commandFactory.Create(definition, parameters);

                if (command != null)
                {
                    var commandObj = new MacroCommandObject
                    {
                        Command = command,
                        Definition = definition,
                        Parameters = parameters
                    };
                    AddMacroCommand(commandObj, desiredIndex, addClosingCommand, autoSelect);
                    success = true;
                }
            }
            catch
            {
                success = false;
            }

            if (!success)
            {
                MessageBox.Show(this, "Failed to create the command, please try again.", "Command Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        
        private void AddMacroCommand(MacroCommandObject commandObj, int desiredIndex = -1, bool addClosingCommand = true, bool autoSelect = true)
        {
            if (desiredIndex >= 0)
            {
                // Determine the specified index, capping at the end of the collection
                desiredIndex = Math.Min(desiredIndex, macroCommands.Count);
            }
            else
            {
                // Check if we have a selection
                if (macroListView.SelectedIndices.Count > 0)
                {
                    // Insert at the end of the selection
                    desiredIndex = macroListView.SelectedIndices[macroListView.SelectedIndices.Count - 1] + 1;
                }
                else
                {
                    // Insert to the bottom
                    desiredIndex = macroCommands.Count;
                }
            }

            // Add to our list of commands
            macroCommands.Insert(desiredIndex, commandObj);

            // Add to the list view (text is blank, we will re-number afterwards)
            var listViewItem = macroListView.Items.Insert(desiredIndex, "");
            listViewItem.Tag = commandObj;

            listViewItem.SubItems.Add(commandObj.Command.ToString());

            // Automatically add an accompanying closing command for stuff like if/while/loop
            if (addClosingCommand && commandObj.Command.IsOpeningCommand() && AddClosingCommand(commandObj, desiredIndex + 1) != null)
            {
                return;
            }

            ReformatLines();

            if (autoSelect)
            {
                macroListView.SelectedIndices.Clear();
                macroListView.SelectedIndices.Add(desiredIndex);
            }
        }
        
        private MacroCommandObject AddClosingCommand(MacroCommandObject commandObj, int desiredIndex)
        {
            var closingCommand = commandObj.Command.GetClosingCommand();
            if (closingCommand == null)
            {
                return null;
            }

            var endingObj = new MacroCommandObject
            {
                Command = closingCommand,
                Definition = commandRegistry.GetClosingDefinition(commandObj.Command),
                Parameters = Array.Empty<MacroParameterValue>()
            };

            AddMacroCommand(endingObj, desiredIndex, autoSelect: false);
            
            macroListView.SelectedIndices.Clear();
            macroListView.SelectedIndices.Add(Math.Max(0, desiredIndex - 1));
            return endingObj;
        }
        #endregion
        
        private void DeleteMacroCommands(IReadOnlyList<int> indexes)
        {
            macroListView.BeginUpdate();

            try
            {
                for (var i = indexes.Count - 1; i >=0; i--)
                {
                    var index = indexes[i];
                    macroCommands.RemoveAt(index);
                    macroListView.Items.RemoveAt(index);
                }
                
                ReformatLines();
            }
            finally
            {
                macroListView.EndUpdate();
            }

            
        }
    }
}