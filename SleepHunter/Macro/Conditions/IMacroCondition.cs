
namespace SleepHunter.Macro.Conditions
{
    public interface IMacroCondition
    {
        bool Evaluate(IMacroContext context);
    }
}
