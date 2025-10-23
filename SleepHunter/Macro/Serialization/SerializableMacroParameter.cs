using System;
using System.Text.Json.Serialization;
using SleepHunter.Macro.Commands;

namespace SleepHunter.Macro.Serialization
{
    [Serializable]
    public sealed class SerializableMacroParameter
    {
        public MacroParameterType Type { get; set; }
        public object Value { get; set; }

        [JsonConstructor]
        internal SerializableMacroParameter()
        {

        }

        public SerializableMacroParameter(MacroParameterType type, object value = null)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => Value?.ToString() ?? "NULL";
    }
}