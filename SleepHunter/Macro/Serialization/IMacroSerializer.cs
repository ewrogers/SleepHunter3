using System.Collections.Generic;

namespace SleepHunter.Macro.Serialization
{
    public interface IMacroSerializer
    {
        string Serialize(IReadOnlyList<SerializableMacroCommand> commands);

        string SerializeDocument(SerializableMacroDocument document);

        IReadOnlyList<SerializableMacroCommand> Deserialize(string json);

        SerializableMacroDocument DeserializeDocument(string json);
    }
}