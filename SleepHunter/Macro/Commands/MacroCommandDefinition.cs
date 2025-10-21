using System;
using System.Collections.Generic;

namespace SleepHunter.Macro.Commands
{
    public class MacroCommandDefinition
    {
        public MacroCommandCategory Category { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string HelpText { get; set; }
        public Type CommandType { get; set; }
        public List<MacroParameterType> Parameters { get; set; } = new List<MacroParameterType>();
    }
}