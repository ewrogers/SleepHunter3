using SleepHunter.Macro.Commands;
using System.Collections.Generic;

namespace SleepHunter.Models
{
    public sealed class MacroCommandObject
    {
        public IMacroCommand Command { get; set; }
        public MacroCommandDefinition Definition { get; set; }
        public IReadOnlyList<MacroParameterValue> Parameters { get; set; }
    }
}
