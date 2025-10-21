using System;

namespace SleepHunter.Macro.Commands
{
    public class MacroCommandDefinition
    {
        public MacroCommandCategory Category { get; set; }
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string HelpText { get; set; }
        public Type CommandType { get; set; }
        public MacroParameterType ParameterType { get; set; } = MacroParameterType.None;
    }
}