using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        public void StartMacro()
        {
            IsRunning = true;

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