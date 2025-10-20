using SleepHunter.Extensions;
using System;
using System.IO;
using System.Text;

namespace SleepHunter.Interop
{
    internal abstract class MemoryVariable<T> : IMemoryVariable<T>
    {
        protected readonly Stream _stream;
        protected readonly BinaryReader _reader;
        
        public int MaxLength { get; protected set; }

        protected MemoryVariable(Stream stream, int maxLength)
        {
            _stream = stream;
            _reader = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true);

            MaxLength = maxLength;
        }

        public T Read() => (T)ReadValue();

        object IMemoryVariable.Read() => ReadValue();

        private object ReadValue()
        {
            _stream.Position = (long)ResolveAddress();

            var type = typeof(T);

            if (type == typeof(bool))
            {
                return _reader.ReadByte() != 0;
            }
            if (type == typeof(byte))
            {
                return _reader.ReadByte();
            }
            if (type == typeof(sbyte))
            {
                return _reader.ReadSByte();
            }
            if (type == typeof(short))
            {
                return _reader.ReadInt16();
            }
            if (type == typeof(ushort))
            {
                return _reader.ReadUInt16();
            }
            if (type == typeof(int))
            {
                return _reader.ReadInt32();
            }
            if (type == typeof(uint))
            {
                return _reader.ReadUInt32();
            }
            if (type == typeof(long))
            {
                return _reader.ReadInt64();
            }
            if (type == typeof(ulong))
            {
                return _reader.ReadUInt64();
            }
            if (type == typeof(float))
            {
                return _reader.ReadSingle();
            }
            if (type == typeof(double))
            {
                return _reader.ReadDouble();
            }
            if (type == typeof(string))
            {
                return _reader.ReadNullTerminatedString(MaxLength);
            }

            throw new InvalidOperationException($"Unsupported type: {type.Name}");
        }

        protected abstract IntPtr ResolveAddress();
    }
}
