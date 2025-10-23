
using SleepHunter.Macro.Commands;

namespace SleepHunter.Macro.Serialization
{
    public interface ILegacySerializer
    {
        SerializableMacroDocument DeserializeDocument(string contents);

        SerializableMacroCommand DeserializeCommand(string line);

        SerializableMacroParameter DeserializeParameter(string value, MacroParameterType expectedType);
    }
}
