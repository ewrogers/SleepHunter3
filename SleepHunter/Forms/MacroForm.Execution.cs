using System.Linq;
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
            IsRunning = true;
            
            macroExecutor?.Dispose();
            
            // Create a new macro executor with the current macro commands
            macroExecutor = new MacroExecutor(macroCommands.Select(c => c.Command), clientReader,
                new VirtualKeyboard(clientWindow.WindowHandle), new VirtualMouse(clientWindow.WindowHandle));
            
            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        public void PauseMacro()
        {
            IsPaused = true;

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        public void ResumeMacro()
        {
            IsPaused = false;

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        public void StopMacro(MacroStopReason reason)
        {
            IsRunning = false;
            IsPaused = false;
            
            StopReason = reason;

            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }
    }
}