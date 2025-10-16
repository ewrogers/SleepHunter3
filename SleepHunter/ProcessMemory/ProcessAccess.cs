namespace ProcessMemory
{

    public enum ProcessAccess
    {
        PROCESS_VM_OPERATION = 8,
        PROCESS_VM_READ = 16, // 0x00000010
        PROCESS_VM_WRITE = 32, // 0x00000020
        PROCESS_VM = 56, // 0x00000038
        STANDARD_RIGHTS_REQUIRED = 983040, // 0x000F0000
        SYNCHRONIZE = 1048576, // 0x00100000
        PROCESS_ALL_ACCESS = 2035711, // 0x001F0FFF
    }
}