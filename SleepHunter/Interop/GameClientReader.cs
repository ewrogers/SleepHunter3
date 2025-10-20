using SleepHunter.Interop.Process;
using System;

namespace SleepHunter.Interop
{
    internal class GameClientReader : IDisposable
    {
        public const string Version741 = "7D4E--1K";

        private readonly ProcessMemoryStream _stream;
        private bool _isDisposed;

        private IMemoryVariable<string> _versionVariable;
        private IMemoryVariable<string> _characterNameVariable;

        public GameClientReader(int processId)
        {
            _stream = new ProcessMemoryStream(processId, ProcessAccess.Read);
            InitializeVariables();
        }

        private void InitializeVariables()
        {
            // These are for client version 7.41
            _versionVariable = new StaticMemoryVariable<string>(_stream, (IntPtr)0x685B08, maxLength: 8);
            _characterNameVariable = new StaticMemoryVariable<string>(_stream, (IntPtr)0x73D910, maxLength: 13);
        }

        public string ReadVersion() => _versionVariable.Read();
        public string ReadCharacterName() => _characterNameVariable.Read();

        ~GameClientReader() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (_isDisposed) { return; }

            if (isDisposing)
            {
                _stream.Dispose();
            }

            _isDisposed = true;
        }

        private void CheckIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(GameClientReader));
            }
        }
    }
}
