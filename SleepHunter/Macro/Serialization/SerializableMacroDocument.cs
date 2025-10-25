using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SleepHunter.Macro.Serialization
{
    [Serializable]
    public class SerializableMacroDocument
    {
        public const string CurrentVersion = "3.1";

        public string Version { get; set; } = CurrentVersion;
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
  
        public List<SerializableMacroCommand> Commands { get; set; } = new List<SerializableMacroCommand>();
    }
}