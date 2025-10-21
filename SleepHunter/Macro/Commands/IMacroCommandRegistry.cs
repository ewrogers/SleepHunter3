using System.Collections.Generic;

namespace SleepHunter.Macro.Commands
{
    public interface IMacroCommandRegistry
    {
        IEnumerable<MacroCommandDefinition> Commands { get; }

        bool TryGetCommand(string key, out MacroCommandDefinition command);
        void RegisterCommand(MacroCommandDefinition command);
    }
}