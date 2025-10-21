using System;
using System.Collections.Generic;

namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry : IMacroCommandRegistry
    {
        private readonly Dictionary<string, MacroCommandDefinition> commands =
            new Dictionary<string, MacroCommandDefinition>(StringComparer.OrdinalIgnoreCase);

        public MacroCommandRegistry()
        {
            RegisterInterfaceCommands();
            RegisterMapCommands();
        }

        public IEnumerable<MacroCommandDefinition> Commands => commands.Values;

        public bool TryGetCommand(string name, out MacroCommandDefinition command)
            => commands.TryGetValue(name, out command);

        public void RegisterCommand(MacroCommandDefinition command)
        {
            commands[command.Key] = command;
        }
    }
}