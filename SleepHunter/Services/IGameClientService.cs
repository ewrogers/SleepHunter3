using SleepHunter.Models;
using System.Collections.Generic;

namespace SleepHunter.Services
{
    public interface IGameClientService
    {
        IReadOnlyList<GameClientWindow> FindClientWindows();
    }
}
