using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SleepHunter.Interop.Keyboard;

namespace SleepHunter.Macro.Serialization
{
    public class JsonParameterValueConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(object);

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is IEnumerable<Keystroke> keystrokes)
            {
                var keysString = string.Join("", keystrokes);
                JsonSerializer.Serialize(writer, keysString, options);
            }
            else if (value is long longValue)
            {
                JsonSerializer.Serialize(writer, longValue, options);
            }
            else if (value is int intValue)
            {
                JsonSerializer.Serialize(writer, intValue, options);
            }
            else if (value is double doubleValue)
            {
                JsonSerializer.Serialize(writer, doubleValue, options);
            }
            else if (value is float floatValue)
            {
                JsonSerializer.Serialize(writer, floatValue, options);
            }
            else if (value is string stringValue)
            {
                JsonSerializer.Serialize(writer, stringValue, options);
            }
            else if (value is Enum enumValue)
            {
                JsonSerializer.Serialize(writer, enumValue.ToString(), options);
            }
            else
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
            }
        }
    }
}