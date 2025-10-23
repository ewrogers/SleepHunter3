using System;
using System.Collections.Generic;

namespace SleepHunter.Macro.Serialization
{
    [Serializable]
    public class SerializableMacroDocument
    {
        public const string CurrentVersion = "3.1";

        public string Version { get; set; } = CurrentVersion;
        public string Name { get; set; } = "Untitled";
        public string Author { get; set; } = "Anonymous";
  
        public List<SerializableMacroCommand> Commands { get; set; } = new List<SerializableMacroCommand>();
    }
}