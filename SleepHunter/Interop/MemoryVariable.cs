using SleepHunter.Extensions;
using System;
using System.IO;
using System.Text;

namespace SleepHunter.Interop
{
    internal abstract class MemoryVariable<T> : IMemoryVariable<T>
    {
        protected readonly Stream Stream;
        protected readonly BinaryReader Reader;
        
        public int MaxLength { get; protected set; }

        protected MemoryVariable(Stream stream, int maxLength)
        {
            Stream = stream;
            Reader = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true);

            MaxLength = maxLength;
        }

        public T Read() => (T)ReadValue();

        object IMemoryVariable.Read() => ReadValue();

        private object ReadValue()
        {
            Stream.Position = (long)ResolveAddress();

            var type = typeof(T);

            if (type == typeof(bool))
            {
                return Reader.ReadByte() != 0;
            }
            if (type == typeof(byte))
            {
                return Reader.ReadByte();
            }
            if (type == typeof(sbyte))
            {
                return Reader.ReadSByte();
            }
            if (type == typeof(short))
            {
                return Reader.ReadInt16();
            }
            if (type == typeof(ushort))
            {
                return Reader.ReadUInt16();
            }
            if (type == typeof(int))
            {
                return Reader.ReadInt32();
            }
            if (type == typeof(uint))
            {
                return Reader.ReadUInt32();
            }
            if (type == typeof(long))
            {
                return Reader.ReadInt64();
            }
            if (type == typeof(ulong))
            {
                return Reader.ReadUInt64();
            }
            if (type == typeof(float))
            {
                return Reader.ReadSingle();
            }
            if (type == typeof(double))
            {
                return Reader.ReadDouble();
            }
            if (type == typeof(string))
            {
                return Reader.ReadNullTerminatedString(MaxLength);
            }

            throw new InvalidOperationException($"Unsupported type: {type.Name}");
        }

        protected abstract IntPtr ResolveAddress();
    }
}
