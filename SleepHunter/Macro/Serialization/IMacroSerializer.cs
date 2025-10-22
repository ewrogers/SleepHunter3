using System.Collections.Generic;

namespace SleepHunter.Macro.Serialization
{
    public interface IMacroSerializer
    {
        string Serialize(IReadOnlyList<SerializableMacroCommand> commands);

        IReadOnlyList<SerializableMacroCommand> Deserialize(string json);
    }
}