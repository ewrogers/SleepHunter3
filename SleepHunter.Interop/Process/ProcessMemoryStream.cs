using SleepHunter.Interop.Win32;
using System;
using System.Buffers;
using System.IO;

namespace SleepHunter.Interop.Process
{
    public sealed class ProcessMemoryStream : Stream
    {
        private const int ReadBufferSize = 1024;
        private const int WriteBufferSize = 1024;

        private IntPtr handle;
        private readonly ProcessAccess access;
        private readonly bool leaveOpen;

        private long position = 0x400000;
        private bool isDisposed;

        public int ProcessId { get; private set; }

        public override bool CanSeek => true;
        public override bool CanRead => handle != IntPtr.Zero && access.HasFlag(ProcessAccess.Read);
        public override bool CanWrite => handle != IntPtr.Zero && access.HasFlag(ProcessAccess.Write);
        public override bool CanTimeout => false;

        public override long Position
        {
            get => position;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                position = value;
            }
        }

        public override long Length => throw new NotSupportedException();

        public ProcessMemoryStream(int processId, ProcessAccess desiredAccess, bool leaveOpen = false)
        {
            var processAccessFlags = Win32ProcessAccessFlags.VmOperation;
            if (desiredAccess.HasFlag(ProcessAccess.Read))
            {
                processAccessFlags |= Win32ProcessAccessFlags.VmRead;
            }
            if (desiredAccess.HasFlag(ProcessAccess.Write))
            {
                processAccessFlags |= Win32ProcessAccessFlags.VmWrite;
            }

            var processHandle = NativeMethods.OpenProcess(processAccessFlags, false, processId);
            if (processHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Unable to open process");
            }

            ProcessId = processId;
            handle = processHandle;
            access = desiredAccess;
            this.leaveOpen = leaveOpen;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            CheckIfDisposed();

            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset; break;
                case SeekOrigin.Current:
                    Position += offset; break;
                case SeekOrigin.End:
                    throw new NotSupportedException();
            }

            return Position;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            CheckIfDisposed();

            if (handle == IntPtr.Zero) throw new InvalidOperationException("Stream has been closed");

            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset), "Offset must be a positive index");
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive number");
            if (offset + count > buffer.Length) throw new ArgumentOutOfRangeException(nameof(count), "Cannot read past the end of the buffer");

            var readBuffer = ArrayPool<byte>.Shared.Rent(ReadBufferSize);

            try
            {
                var remaining = count;
                while (remaining > 0)
                {
                    var maxReadSize = Math.Min(ReadBufferSize, remaining);
                    if (!NativeMethods.ReadProcessMemory(handle, (IntPtr)position, readBuffer, maxReadSize, out var bytesRead))
                    {
                        throw new InvalidOperationException("Unable to read from the process");
                    }

                    Buffer.BlockCopy(readBuffer, 0, buffer, offset, bytesRead);

                    offset += bytesRead;
                    remaining -= bytesRead;

                    position += bytesRead;
                }

                return count;
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(readBuffer);
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            CheckIfDisposed();

            if (handle == IntPtr.Zero) throw new InvalidOperationException("Stream has been closed");

            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset), "Offset must be a positive index");
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive number");
            if (offset + count > buffer.Length) throw new ArgumentOutOfRangeException(nameof(count), "Cannot write past the end of the buffer");

            var writeBuffer = ArrayPool<byte>.Shared.Rent(WriteBufferSize);

            try
            {
                var remaining = count;
                while (remaining > 0)
                {
                    var maxWriteSize = Math.Min(WriteBufferSize, remaining);
                    Buffer.BlockCopy(buffer, offset, writeBuffer, 0, maxWriteSize);

                    if (!NativeMethods.WriteProcessMemory(handle, (IntPtr)position, writeBuffer, maxWriteSize, out var bytesWritten))
                    {
                        throw new InvalidOperationException("Unable to write to the process");
                    }

                    offset += bytesWritten;
                    remaining -= bytesWritten;

                    position += bytesWritten;
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(writeBuffer);
            }
        }

        public override void SetLength(long value)
        {
            CheckIfDisposed();
            throw new NotSupportedException();
        }

        public override void Flush()
        {
            CheckIfDisposed();
            // Do nothing
        }

        public override void Close()
        {
            CheckIfDisposed();

            if (handle != IntPtr.Zero)
            {
                NativeMethods.CloseHandle(handle);
            }

            handle = IntPtr.Zero;
        }

        ~ProcessMemoryStream() => Dispose(false);

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            base.Dispose(isDisposing);

            if (isDisposing)
            {

            }

            if (handle != IntPtr.Zero)
            {
                NativeMethods.CloseHandle(handle);
            }

            handle = IntPtr.Zero;
            isDisposed = true;
        }

        private void CheckIfDisposed()
        {
            if (isDisposed) throw new ObjectDisposedException(nameof(ProcessMemoryStream));
        }
    }
}
