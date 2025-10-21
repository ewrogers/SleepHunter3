using SleepHunter.Models;
using System.Threading;

namespace SleepHunter.Macro
{
    public class MacroContext
    {
        private readonly CancellationToken _cancellationToken;
        private readonly PlayerState _player;

        public MacroContext(PlayerState player)
        {
            _player = player;
        }
    }
}
