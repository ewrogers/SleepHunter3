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
        private IMemoryVariable<string> _mapNameVariable;
        private IMemoryVariable<ushort> _mapIdVariable;
        private IMemoryVariable<ushort> _mapXVariable;
        private IMemoryVariable<ushort> _mapYVariable;
        private IMemoryVariable<string> _currentHealthVariable;
        private IMemoryVariable<string> _maxHealthVariable;
        private IMemoryVariable<string> _currentManaVariable;
        private IMemoryVariable<string> _maxManaVariable;

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

            _mapNameVariable = new DynamicMemoryVariable<string>(_stream, (IntPtr)0x82B76C, new long[] { 0x4E3C, 0x0 }, maxLength: 32);
            _mapIdVariable = new DynamicMemoryVariable<ushort>(_stream, (IntPtr)0x882E68, new long[] { 0x26C });
            _mapXVariable = new DynamicMemoryVariable<ushort>(_stream, (IntPtr)0x882E68, new long[] { 0x23C });
            _mapYVariable = new DynamicMemoryVariable<ushort>(_stream, (IntPtr)0x882E68, new long[] { 0x238 });

            _currentHealthVariable = new DynamicMemoryVariable<string>(_stream, (IntPtr)0x755AA4, new long[] { 0x4C6 }, maxLength: 8);
            _maxHealthVariable = new DynamicMemoryVariable<string>(_stream, (IntPtr)0x755AA4, new long[] { 0x546 }, maxLength: 8);

            _currentManaVariable = new DynamicMemoryVariable<string>(_stream, (IntPtr)0x755AA4, new long[] { 0x5C6 }, maxLength: 8);
            _maxManaVariable = new DynamicMemoryVariable<string>(_stream, (IntPtr)0x755AA4, new long[] { 0x646 }, maxLength: 8);
        }

        public string ReadVersion()
        {
            CheckIfDisposed();
            return _versionVariable.Read();
        }

        public string ReadCharacterName()
        {
            CheckIfDisposed();
            return _characterNameVariable.Read();
        }

        public string ReadMapName()
        {
            CheckIfDisposed();
            return _mapNameVariable.Read();
        }

        public int ReadMapId()
        {
            CheckIfDisposed();
            return _mapIdVariable.Read();
        }

        public int ReadMapX()
        {
            CheckIfDisposed();
            return _mapXVariable.Read();
        }

        public int ReadMapY()
        {
            CheckIfDisposed();
            return _mapYVariable.Read();
        }

        public long ReadCurrentHealth()
        {
            CheckIfDisposed();

            var integerString = _currentHealthVariable.Read();
            if (int.TryParse(integerString, out var value))
            {
                return value;
            }
            return 0;
        }

        public long ReadMaxHealth()
        {
            CheckIfDisposed();

            var integerString = _maxHealthVariable.Read();
            if (int.TryParse(integerString, out var value))
            {
                return value;
            }
            return 0;
        }

        public long ReadCurrentMana()
        {
            CheckIfDisposed();

            var integerString = _currentManaVariable.Read();
            if (int.TryParse(integerString, out var value))
            {
                return value;
            }
            return 0;
        }

        public long ReadMaxMana()
        {
            CheckIfDisposed();

            var integerString = _maxManaVariable.Read();
            if (int.TryParse(integerString, out var value))
            {
                return value;
            }
            return 0;
        }

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
