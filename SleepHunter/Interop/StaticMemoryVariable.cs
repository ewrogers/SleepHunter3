using System;
using System.IO;

namespace SleepHunter.Interop
{
    internal class StaticMemoryVariable<T> : MemoryVariable<T>
    {
        public IntPtr Address { get; }

        public StaticMemoryVariable(Stream stream, IntPtr address, int maxLength = 256)
        : base(stream, maxLength)
        {
            Address = address;
        }

        protected override IntPtr ResolveAddress() => Address;
    }
}
