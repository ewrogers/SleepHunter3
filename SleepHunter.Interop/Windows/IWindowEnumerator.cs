using System.Collections.Generic;

namespace SleepHunter.Interop.Windows
{
    public interface IWindowEnumerator
    {
        IReadOnlyList<NativeWindow> FindWindows(string className, string title = null);
    }
}
