using System;
using System.Linq;
using System.Windows.Forms;
using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Macro;
using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        public void StartMacro()
        {
            if (IsRunning)
            {
                return;
            }

            IsRunning = true;

            if (macroExecutor != null)
            {
                macroExecutor.DebugStep -= OnMacroDebugStep;
                macroExecutor.StateChanged -= OnMacroStateChanged;
                macroExecutor.Exception -= OnMacroException;
                macroExecutor.Dispose();
            }

            // Create a new macro executor with the current macro commands
            macroExecutor = new MacroExecutor(macroCommands.Select(c => c.Command), clientReader,
                new VirtualKeyboard(clientWindow.WindowHandle), new VirtualMouse(clientWindow.WindowHandle));

            macroExecutor.DebugStep += OnMacroDebugStep;
            macroExecutor.StateChanged += OnMacroStateChanged;
            macroExecutor.Exception += OnMacroException;

            macroExecutor.SetDebugStepEnabled(debugStepEnabled);
            macroExecutor.StartAsync();

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        public void PauseMacro()
        {
            if (!IsRunning || IsPaused)
            {
                return;
            }

            IsPaused = true;
            macroExecutor?.Pause();

            ClearHighlight();
            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        public void ResumeMacro()
        {
            if (!IsPaused)
            {
                return;
            }

            IsPaused = false;
            macroExecutor?.Resume();

            ClearHighlight();
            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        public void StopMacro(MacroStopReason reason)
        {
            if (!IsRunning)
            {
                return;
            }

            IsRunning = false;
            IsPaused = false;

            macroExecutor?.StopAsync();

            StopReason = reason;

            ClearHighlight();
            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        private void OnMacroDebugStep(int commandIndex)
        {
            ClearHighlight();

            macroListView.SelectedIndices.Clear();
            HighlightItem(commandIndex, DebugStepHighlightColor);

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        private void OnMacroStateChanged(MacroRunState state)
        {
            if (state == MacroRunState.Stopped)
            {
                StopReason = macroExecutor.StopReason;

                if (StopReason == MacroStopReason.ProcessNotFound)
                {
                    DetachClient();
                }
            }

            IsRunning = state == MacroRunState.Running || state == MacroRunState.Paused;
            IsPaused = state == MacroRunState.Paused;

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        private void OnMacroException(Exception ex)
        {
            MessageBox.Show(this, $"An error occurred while executing the macro: {ex.Message}",
                "Macro Execution Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }
    }
}