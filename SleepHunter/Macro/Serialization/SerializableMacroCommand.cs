using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using SleepHunter.Macro.Commands;

namespace SleepHunter.Macro.Serialization
{
    [Serializable]
    public sealed class SerializableMacroCommand
    {
        [JsonPropertyName("command")]
        public string Key { get; set; }
        
        public List<SerializableMacroParameter> Parameters { get; set; }

        [JsonConstructor]
        internal SerializableMacroCommand()
        {
            
        }
        
        public SerializableMacroCommand(string key)
        {
            Key = key;
        }

        public SerializableMacroCommand(MacroCommandDefinition definition)
            : this(definition, Array.Empty<MacroParameterValue>())
        {
        }

        public SerializableMacroCommand(MacroCommandDefinition definition,
            IReadOnlyList<MacroParameterValue> parameters)
        {
            Key = definition.Key;

            if (parameters != null && parameters.Count > 0)
            {
                Parameters = parameters.Select(p => new SerializableMacroParameter(p.Type, p.Value)).ToList();
            }
        }
    }
}