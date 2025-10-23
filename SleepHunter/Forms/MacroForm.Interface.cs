using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm : Form
    {
        public MacroParameterValue[] ShowArgumentsForm(MacroCommandDefinition command,
            IReadOnlyList<MacroParameterValue> parameters = null)
        {
            // No args, nothing to show
            if (command.Parameters.Count == 0)
            {
                return Array.Empty<MacroParameterValue>();
            }

            // Set the command definition and existing parameters (if provided)
            var argsForm = serviceProvider.GetRequiredService<ArgumentsForm>();
            argsForm.Command = command;

            if (parameters != null)
            {
                argsForm.SetDefaultParameters(parameters);
            }

            // Show the arguments form for the command requested
            argsForm.ShowDialog(this);

            // Ignore if the user cancelled
            return argsForm.DialogResult != DialogResult.OK
                ? null
                : argsForm.Parameters.ToArray();
        }

        private void UpdateProcessUI()
        {
            var characterName = string.Empty;
            try
            {
                if (isAttached)
                {
                    characterName = clientReader.ReadCharacterName();
                }
            }
            catch
            {
                DetachClient();
                return;
            }

            var name = !string.IsNullOrWhiteSpace(macroName) ? macroName : "Macro";
            Text = isAttached ? $"{characterName} - {name}" : name;

            characterNameLabel.Text = isAttached ? characterName : "No Client";
            characterNameLabel.Enabled = isAttached;
        }

        private void UpdateToolbarAndMenuState()
        {
            var hasSingleSelection = macroListView.SelectedIndices.Count == 1;
            var hasMultipleSelection = macroListView.SelectedIndices.Count > 1;
            var isEmpty = macroListView.Items.Count == 0;
            var hasSelection = hasSingleSelection || hasMultipleSelection;

            // Check for parameter count, only commands with parameters are editable
            var hasParameters = false;
            if (hasSingleSelection)
            {
                var selectedListViewItem = macroListView.SelectedItems[0];
                if (selectedListViewItem.Tag is MacroCommandObject commandObj)
                {
                    hasParameters = commandObj.Parameters.Count > 0;
                }
            }

            if (hasSingleSelection)
            {
                editSelectedMenu.ShortcutKeyDisplayString = !hasParameters ? "(No Parameters)" : "Space";
            }
            else if (hasMultipleSelection)
            {
                editSelectedMenu.ShortcutKeyDisplayString = "(Multiple Selected)";
            }
            else
            {
                editSelectedMenu.ShortcutKeyDisplayString = "Space";
            }

            editButton.Enabled = editSelectedMenu.Enabled = !isEmpty && hasSingleSelection && hasParameters;
            deleteButton.Enabled = deleteSelectedMenu.Enabled = !isEmpty && hasSelection;

            cutButton.Enabled = cutSelectedMenu.Enabled = !isEmpty && hasSelection;
            copyButton.Enabled = copySelectedMenu.Enabled = !isEmpty && hasSelection;
            pasteButton.Enabled = pasteSelectedMenu.Enabled =
                Clipboard.ContainsData("MacroCommands") || Clipboard.ContainsText();

            moveUpButton.Enabled = moveUpMenu.Enabled = !isEmpty && hasSelection;
            moveDownButton.Enabled = moveDownMenu.Enabled = !isEmpty && hasSelection;

            playButton.Enabled = !isEmpty && !IsRunning;
            pauseButton.Enabled = !isEmpty && IsRunning && !IsPaused;
            stopButton.Enabled = IsRunning;

            quickAttachButton.Enabled = !IsRunning;
        }

        private void UpdateStatusBarState()
        {
            const int playImageIndex = 0;
            const int pauseImageIndex = 1;
            const int stopImageIndex = 2;

            if (IsPaused)
            {
                statusLabel.Text = "Macro has been paused.";
                statusLabel.Image = statusImageList.Images[pauseImageIndex];
                return;
            }
            
            if (IsRunning)
            {
                statusLabel.Text = "Macro is running...";
                statusLabel.Image = statusImageList.Images[playImageIndex];
                return;
            }

            switch (StopReason)
            {
                case MacroStopReason.Completed:
                    statusLabel.Text = "Macro has finished running.";
                    break;
                case MacroStopReason.UserStopped:
                    statusLabel.Text = "Macro has been stopped by the user.";
                    break;
                case MacroStopReason.Error:
                    statusLabel.Text = "Macro has encountered an error.";
                    break;
                default:
                    statusLabel.Text = "Macro is not running.";
                    break;
            }
            
            statusLabel.Image = statusImageList.Images[stopImageIndex];
        }
    }
}