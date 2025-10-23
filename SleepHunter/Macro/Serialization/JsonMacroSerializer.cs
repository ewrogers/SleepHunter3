using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SleepHunter.Interop.Keyboard;
using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Conditions;

namespace SleepHunter.Macro.Serialization
{
    public sealed class JsonMacroSerializer : IMacroSerializer
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                new JsonParameterValueConverter()
            }
        };

        public string Serialize(IReadOnlyList<SerializableMacroCommand> commands)
        {
            return JsonSerializer.Serialize(commands, JsonOptions);
        }

        public string SerializeDocument(SerializableMacroDocument document)
        {
            return JsonSerializer.Serialize(document, JsonOptions);
        }

        public IReadOnlyList<SerializableMacroCommand> Deserialize(string json)
        {
            var commands = JsonSerializer.Deserialize<List<SerializableMacroCommand>>(json, JsonOptions);

            foreach (var command in commands)
            {
                command.Parameters = command.Parameters ?? new List<SerializableMacroParameter>();
                foreach (var parameter in command.Parameters)
                {
                    parameter.Value = GetParameterValue(parameter);
                }
            }

            return commands;
        }

        public SerializableMacroDocument DeserializeDocument(string json)
        {
            var document = JsonSerializer.Deserialize<SerializableMacroDocument>(json, JsonOptions);

            foreach (var command in document.Commands)
            {
                command.Parameters = command.Parameters ?? new List<SerializableMacroParameter>();
                foreach (var parameter in command.Parameters)
                {
                    parameter.Value = GetParameterValue(parameter);
                }
            }

            return document;
        }

        private object GetParameterValue(SerializableMacroParameter parameter)
        {
            if (parameter?.Value == null)
            {
                return null;
            }

            if (parameter.Type == MacroParameterType.Boolean)
            {
                if (parameter.Value is JsonElement element)
                {
                    return element.GetBoolean();
                }

                return Convert.ToBoolean(parameter.Value);
            }

            if (parameter.Type == MacroParameterType.Integer)
            {
                if (parameter.Value is JsonElement element)
                {
                    return element.GetInt64();
                }

                return Convert.ToInt64(parameter.Value);
            }

            if (parameter.Type == MacroParameterType.Float)
            {
                if (parameter.Value is JsonElement element)
                {
                    return element.GetDouble();
                }

                return Convert.ToDouble(parameter.Value);
            }

            if (parameter.Type == MacroParameterType.String)
            {
                if (parameter.Value is JsonElement element)
                {
                    return element.GetString();
                }

                return parameter.Value.ToString();
            }

            if (parameter.Type == MacroParameterType.CompareOperator)
            {
                var value = parameter.Value is JsonElement element
                    ? element.GetString()
                    : parameter.Value.ToString();

                return Enum.Parse(typeof(CompareOperator), value ?? string.Empty, true);
            }

            if (parameter.Type == MacroParameterType.StringCompareOperator)
            {
                var value = parameter.Value is JsonElement element
                    ? element.GetString()
                    : parameter.Value.ToString();

                return Enum.Parse(typeof(StringCompareOperator), value ?? string.Empty, true);
            }

            if (parameter.Type == MacroParameterType.LogicalOperator)
            {
                var value = parameter.Value is JsonElement element
                    ? element.GetString()
                    : parameter.Value.ToString();

                return Enum.Parse(typeof(LogicalOperator), value ?? string.Empty, true);
            }

            if (parameter.Type == MacroParameterType.Keystrokes)
            {
                var value = parameter.Value is JsonElement element
                    ? element.GetString()
                    : parameter.Value.ToString();

                return KeystrokeParser.ParseLine(value?.Trim() ?? string.Empty);
            }

            throw new ArgumentException($"Invalid parameter type: {parameter.Type}", nameof(parameter));
        }
    }
}