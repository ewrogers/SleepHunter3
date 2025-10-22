using SleepHunter.Models;

namespace SleepHunter.Macro
{
    public class MacroContext
    {
        public PlayerState Player { get; }

        public MacroContext(PlayerState player)
        {
            Player = player;
        }
    }
}
