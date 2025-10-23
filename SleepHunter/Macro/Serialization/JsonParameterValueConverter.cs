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
            else
            {
                JsonSerializer.Serialize(writer, value, options);
            }
        }
    }
}