using SleepHunter.Models;
using System.Threading;

namespace SleepHunter.Macro
{
    public class MacroContext
    {
        private readonly CancellationToken cancellationToken;
        private readonly PlayerState player;

        public MacroContext(PlayerState player)
        {
            this.player = player;
        }
    }
}
