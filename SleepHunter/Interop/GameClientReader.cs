using SleepHunter.Interop.Process;
using System;

namespace SleepHunter.Interop
{
    internal class GameClientReader : IDisposable
    {
        public const string Version741 = "7D4E--1K";

        private readonly ProcessMemoryStream stream;
        private bool isDisposed;

        private IMemoryVariable<string> versionVariable;
        private IMemoryVariable<string> characterNameVariable;
        private IMemoryVariable<string> mapNameVariable;
        private IMemoryVariable<ushort> mapIdVariable;
        private IMemoryVariable<ushort> mapXVariable;
        private IMemoryVariable<ushort> mapYVariable;
        private IMemoryVariable<string> currentHealthVariable;
        private IMemoryVariable<string> maxHealthVariable;
        private IMemoryVariable<string> currentManaVariable;
        private IMemoryVariable<string> maxManaVariable;

        public GameClientReader(int processId)
        {
            stream = new ProcessMemoryStream(processId, ProcessAccess.Read);
            InitializeVariables();
        }

        private void InitializeVariables()
        {
            // These are for client version 7.41
            versionVariable = new StaticMemoryVariable<string>(stream, (IntPtr)0x685B08, maxLength: 8);
            characterNameVariable = new StaticMemoryVariable<string>(stream, (IntPtr)0x73D910, maxLength: 13);

            mapNameVariable = new DynamicMemoryVariable<string>(stream, (IntPtr)0x82B76C, new long[] { 0x4E3C, 0x0 }, maxLength: 32);
            mapIdVariable = new DynamicMemoryVariable<ushort>(stream, (IntPtr)0x882E68, new long[] { 0x26C });
            mapXVariable = new DynamicMemoryVariable<ushort>(stream, (IntPtr)0x882E68, new long[] { 0x23C });
            mapYVariable = new DynamicMemoryVariable<ushort>(stream, (IntPtr)0x882E68, new long[] { 0x238 });

            currentHealthVariable = new DynamicMemoryVariable<string>(stream, (IntPtr)0x755AA4, new long[] { 0x4C6 }, maxLength: 8);
            maxHealthVariable = new DynamicMemoryVariable<string>(stream, (IntPtr)0x755AA4, new long[] { 0x546 }, maxLength: 8);

            currentManaVariable = new DynamicMemoryVariable<string>(stream, (IntPtr)0x755AA4, new long[] { 0x5C6 }, maxLength: 8);
            maxManaVariable = new DynamicMemoryVariable<string>(stream, (IntPtr)0x755AA4, new long[] { 0x646 }, maxLength: 8);
        }

        public string ReadVersion()
        {
            CheckIfDisposed();
            return versionVariable.Read();
        }

        public string ReadCharacterName()
        {
            CheckIfDisposed();
            return characterNameVariable.Read();
        }

        public string ReadMapName()
        {
            CheckIfDisposed();
            return mapNameVariable.Read();
        }

        public int ReadMapId()
        {
            CheckIfDisposed();
            return mapIdVariable.Read();
        }

        public int ReadMapX()
        {
            CheckIfDisposed();
            return mapXVariable.Read();
        }

        public int ReadMapY()
        {
            CheckIfDisposed();
            return mapYVariable.Read();
        }

        public long ReadCurrentHealth()
        {
            CheckIfDisposed();

            var integerString = currentHealthVariable.Read();
            if (int.TryParse(integerString, out var value))
            {
                return value;
            }
            return 0;
        }

        public long ReadMaxHealth()
        {
            CheckIfDisposed();

            var integerString = maxHealthVariable.Read();
            if (int.TryParse(integerString, out var value))
            {
                return value;
            }
            return 0;
        }

        public long ReadCurrentMana()
        {
            CheckIfDisposed();

            var integerString = currentManaVariable.Read();
            if (int.TryParse(integerString, out var value))
            {
                return value;
            }
            return 0;
        }

        public long ReadMaxMana()
        {
            CheckIfDisposed();

            var integerString = maxManaVariable.Read();
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
            if (isDisposed) { return; }

            if (isDisposing)
            {
                stream.Dispose();
            }

            isDisposed = true;
        }

        private void CheckIfDisposed()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(nameof(GameClientReader));
            }
        }
    }
}
