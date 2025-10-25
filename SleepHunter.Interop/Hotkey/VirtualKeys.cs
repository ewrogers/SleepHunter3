namespace SleepHunter.Interop.Hotkey
{
    public enum VirtualKeys : uint
    {
        // Function keys
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,

        // Letters
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,

        // Numbers
        D0 = 0x30,
        D1 = 0x31,
        D2 = 0x32,
        D3 = 0x33,
        D4 = 0x34,
        D5 = 0x35,
        D6 = 0x36,
        D7 = 0x37,
        D8 = 0x38,
        D9 = 0x39,

        Tilde = 0xC0,
        Plus = 0xBB,
        Minus = 0xBD,
        OpenBracket = 0xDB,
        CloseBracket = 0xDD,
        Semicolon = 0xBA,
        Quote = 0xDE,
        Comma = 0xBC,
        Period = 0xBE,
        ForwardSlash = 0xBF,
        BackSlash = 0xDC,

        // Special keys
        Space = 0x20,
        Enter = 0x0D,
        Escape = 0x1B,
        Tab = 0x09,
        Backspace = 0x08,
        Delete = 0x2E,
        Insert = 0x2D,
        Home = 0x24,
        End = 0x23,
        PageUp = 0x21,
        PageDown = 0x22,

        // Arrow keys
        Left = 0x25,
        Up = 0x26,
        Right = 0x27,
        Down = 0x28,

        // Numpad
        NumPad0 = 0x60,
        NumPad1 = 0x61,
        NumPad2 = 0x62,
        NumPad3 = 0x63,
        NumPad4 = 0x64,
        NumPad5 = 0x65,
        NumPad6 = 0x66,
        NumPad7 = 0x67,
        NumPad8 = 0x68,
        NumPad9 = 0x69,
    }

    public static class VirtualKeyExtensions
    {
        public static string ToAlias(this VirtualKeys key)
        {
            switch (key)
            {
                case VirtualKeys.D1: return "1";
                case VirtualKeys.D2: return "2";
                case VirtualKeys.D3: return "3";
                case VirtualKeys.D4: return "4";
                case VirtualKeys.D5: return "5";
                case VirtualKeys.D6: return "6";
                case VirtualKeys.D7: return "7";
                case VirtualKeys.D8: return "8";
                case VirtualKeys.D9: return "9";
                case VirtualKeys.D0: return "0";
                case VirtualKeys.ForwardSlash: return "/";
                case VirtualKeys.BackSlash: return "\\";
                case VirtualKeys.OpenBracket: return "[";
                case VirtualKeys.CloseBracket: return "]";

                default:
                    return key.ToString();
            }
        }
    }
}