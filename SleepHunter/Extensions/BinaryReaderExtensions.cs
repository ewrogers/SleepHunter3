using System.Buffers;
using System.IO;

namespace SleepHunter.Extensions
{
    internal static class BinaryReaderExtensions
    {
        public static string ReadNullTerminatedString(this BinaryReader reader, int maxLength = 256)
        {
            var charBuffer = ArrayPool<char>.Shared.Rent(maxLength);

            try
            {
                for (var i = 0; i < maxLength; i++)
                {
                    var c = reader.ReadChar();
                    if (c == '\0')
                    {
                        return new string(charBuffer, 0, i);
                    }

                    charBuffer[i] = c;
                }

                return new string(charBuffer, 0, maxLength);
            }
            finally
            {
                ArrayPool<char>.Shared.Return(charBuffer);
            }
        }
    }
}
