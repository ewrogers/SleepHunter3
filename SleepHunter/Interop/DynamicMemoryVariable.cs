using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SleepHunter.Interop
{
    internal class DynamicMemoryVariable<T> : MemoryVariable<T>
    {
        public IntPtr BaseAddress { get; }
        public IReadOnlyList<long> Offsets { get; }


        public DynamicMemoryVariable(Stream stream, IntPtr baseAddress, IEnumerable<long> offsets, int maxLength = 256)
            :base(stream, maxLength)
        {
            BaseAddress = baseAddress;
            Offsets = offsets.ToList();
        }

        protected override IntPtr ResolveAddress()
        {
            long currentAddress = (long)BaseAddress;

            foreach (var offset in Offsets)
            {
                Stream.Position = currentAddress;
                currentAddress = Reader.ReadUInt32() + offset;
            }

            return (IntPtr)currentAddress;
        }
    }
}
