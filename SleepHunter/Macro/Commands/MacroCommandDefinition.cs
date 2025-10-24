using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SleepHunter.Macro.Commands
{
    public class MacroCommandDefinition
    {
        public MacroCommandCategory Category { get; set; }
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string HelpText { get; set; }
        public List<MacroParameterType> Parameters { get; set; } = new List<MacroParameterType>();
        public Regex Pattern { get; set; }
        public int? MaxLength { get; set; }
        
        public override string ToString() => DisplayName;
    }
}