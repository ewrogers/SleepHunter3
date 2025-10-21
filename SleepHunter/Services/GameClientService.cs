using SleepHunter.Interop.Process;
using SleepHunter.Interop.Windows;
using SleepHunter.Models;
using System.Collections.Generic;
using System.Linq;

namespace SleepHunter.Services
{
    public class GameClientService : IGameClientService
    {
        private readonly IWindowEnumerator windowEnumerator;

        public GameClientService(IWindowEnumerator windowEnumerator)
        {
            this.windowEnumerator = windowEnumerator;
        }

        public IReadOnlyList<GameClientWindow> FindClientWindows() =>
            windowEnumerator.FindWindows("Darkages").Select(w => new GameClientWindow(w.Handle, w.ProcessId)).ToList();
    }
}
