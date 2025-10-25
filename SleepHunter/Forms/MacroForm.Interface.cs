using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm : Form
    {
        public void SelectMacroItem(int index)
        {
            if (index < 0 || macroListView.Items.Count == 0)
            {
                return;
            }

            index = Math.Min(index, macroListView.Items.Count - 1);

            macroListView.EnsureVisible(index);
            macroListView.SelectedIndices.Clear();
            macroListView.SelectedIndices.Add(index);
        }

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

            if (command.MaxLength.HasValue)
            {
                argsForm.SetMaxLength(command.MaxLength.Value);
            }

            if (command.Pattern != null)
            {
                argsForm.SetPatternConstraint(command.Pattern);
            }

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

        private void UpdateMacroUi()
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

            editButton.Enabled =
                editSelectedMenu.Enabled = !IsRunning && !isEmpty && hasSingleSelection && hasParameters;
            deleteButton.Enabled = deleteSelectedMenu.Enabled = !IsRunning && !isEmpty && hasSelection;

            cutButton.Enabled = cutSelectedMenu.Enabled = !IsRunning && !isEmpty && hasSelection;
            copyButton.Enabled = copySelectedMenu.Enabled = !isEmpty && hasSelection;
            pasteButton.Enabled = pasteSelectedMenu.Enabled = !IsRunning &&
                Clipboard.ContainsData("MacroCommands") || Clipboard.ContainsText();

            moveUpButton.Enabled = moveUpMenu.Enabled = !IsRunning && !isEmpty && hasSelection;
            moveDownButton.Enabled = moveDownMenu.Enabled = !IsRunning && !isEmpty && hasSelection;

            playButton.Text = IsPaused ? "Continue Macro" : "Start Macro";
            playButton.Enabled = string.IsNullOrWhiteSpace(validationErrorMessage) && !isEmpty && isAttached &&
                                 (!IsRunning || IsPaused);

            pauseButton.Enabled = !isEmpty && IsRunning && !IsPaused;
            stopButton.Enabled = IsRunning;

            quickAttachButton.Enabled = !IsRunning;
        }

        private void UpdateStatusBarState()
        {
            const int playImageIndex = 0;
            const int pauseImageIndex = 1;
            const int stopImageIndex = 2;

            if (!string.IsNullOrWhiteSpace(validationErrorMessage))
            {
                statusLabel.Text = validationErrorMessage;
                statusLabel.ForeColor = ValidationTextColor;
                statusLabel.Image = deleteButton.Image;
                return;
            }

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
                case MacroStopReason.ProcessNotFound:
                    statusLabel.Text = "Macro has been stopped due to missing client.";
                    break;
                case MacroStopReason.Error:
                    statusLabel.Text = "Macro has encountered an error.";
                    break;
                default:
                    statusLabel.Text = "Macro is not running.";
                    break;
            }

            statusLabel.ForeColor = SystemColors.ControlText;
            statusLabel.Image = statusImageList.Images[stopImageIndex];
        }

        private IEnumerable<int> GetSelectedIndices()
            => macroListView.SelectedIndices.Cast<int>().OrderBy(i => i);

        private void HighlightItem(int index, Color? color = null)
        {
            if (index < 0 || index >= macroListView.Items.Count)
            {
                return;
            }

            highlightedItem = macroListView.Items[index];
            highlightedItem.BackColor = color ?? Color.Yellow;
            highlightedItem.EnsureVisible();
        }

        private void ClearHighlight()
        {
            if (highlightedItem == null)
            {
                return;
            }

            highlightedItem.BackColor = macroListView.BackColor;
            highlightedItem = null;
        }
    }
}