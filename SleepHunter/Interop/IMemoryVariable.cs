
namespace SleepHunter.Interop
{
    internal interface IMemoryVariable
    {
        object Read();
    }

    internal interface IMemoryVariable<T> : IMemoryVariable
    {
        new T Read();
    }
}
