using System;
using System.Collections.Generic;

namespace SleepHunter.Macro.Keyboard
{
    public readonly struct Keystroke
    {
        public static Keystroke None => new Keystroke('\0');

        private static readonly Dictionary<string, int> VirtualKeyMap =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "ESC", 0x1B }, { "ESCAPE", 0x1B }, { "TAB", 0x09 }, { "ENTER", 0x0D }, { "RETURN", 0x0D }, { "SPACE", 0x20 },
                { "UP", 0x26 }, { "DOWN", 0x28 }, { "LEFT", 0x25 }, { "RIGHT", 0x27 },
                { "INSERT", 0x2D }, { "DELETE", 0x2E }, { "BACKSPACE", 0x08 },
                { "INS", 0x2D }, { "DEL", 0x2E },
                { "HOME", 0x24 }, { "END", 0x23 },
                { "PAGEUP", 0x21 }, { "PAGEDOWN", 0x22 }, { "PGUP", 0x21 }, { "PGDN", 0x22 },
                { "F1", 0x70 }, { "F2", 0x71 }, { "F3", 0x72 }, { "F4", 0x73 }, { "F5", 0x74 }, { "F6", 0x75 },
                { "F7", 0x76 }, { "F8", 0x77 }, { "F9", 0x78 }, { "F10", 0x79 }, { "F11", 0x7A }, { "F12", 0x7B },
                { "F13", 0x7C }, { "F14", 0x7D }, { "F15", 0x7E }, { "F16", 0x7F }, { "F17", 0x80 }, { "F18", 0x81 },
                { "F19", 0x82 }, { "F20", 0x83 }, { "F21", 0x84 }, { "F22", 0x85 }, { "F23", 0x86 }, { "F24", 0x87 },
                { "NUMLOCK", 0x90 }, { "SCROLLLOCK", 0x91 }, { "CAPSLOCK", 0x14 }, { "PRINTSCREEN", 0x2C },
                { "LSHIFT", 0xA0 }, { "RSHIFT", 0xA1 },
                { "LCTRL", 0xA2 }, { "RCTRL", 0xA3 },
                { "LALT", 0xA4 }, { "RALT", 0xA5 },
                { "LWIN", 0x5B }, { "RWIN", 0x5C },
                { "TILDE", 0x0E }, { "MINUS", 0xBD }, { "EQUALS", 0xBB },
                { "COMMA", 0xBC }, { "PERIOD", 0xBE }, { "SLASH", 0xBF }, { "SEMICOLON", 0xBA }, { "QUOTE", 0xDE },
                { "OPENBRACKET", 0xDB }, { "CLOSEBRACKET", 0xDD }, { "BACKSLASH", 0xDC }, { "BACKQUOTE", 0xC0 },
                { "PAUSE", 0x13 },
                { "NUMPAD 0", 0x60 }, { "NUMPAD 1", 0x61 }, { "NUMPAD 2", 0x62 }, { "NUMPAD 3", 0x63 },
                { "NUMPAD 4", 0x64 }, { "NUMPAD 5", 0x65 }, { "NUMPAD 6", 0x66 }, { "NUMPAD 7", 0x67 },
                { "NUMPAD 8", 0x68 }, { "NUMPAD 9", 0x69 }, { "NUMPAD +", 0x6B }, { "NUMPAD -", 0x6D },
            };

        public bool IsChar { get; }
        public char? Char { get; }
        public int? VirtualKey { get; }
        public string Alias { get; }

        public Keystroke(char character, int? virtualKey = null, string alias = null)
        {
            IsChar = character != '\0';
            Char = IsChar ? character : (char?)null;
            VirtualKey = virtualKey;
            Alias = alias;
        }

        public Keystroke(int virtualKey, string alias = null)
        {
            IsChar = false;
            Char = null;
            VirtualKey = virtualKey;
            Alias = alias;
        }

        public override string ToString()
        {
            if (IsChar && Char.HasValue)
            {
                var c = Char.Value;
                switch (c)
                {
                    case '\0': return string.Empty;
                    case '<': return "<LT>";
                    case '>': return "<GT>";
                    case '\t': return "<TAB>";
                    case '\r':
                    case '\n': return "<ENTER>";
                    case ' ': return "<SPACE>";
                    default: return c.ToString();
                }
            }
            else
            {
                return !string.IsNullOrEmpty(Alias) ? $"<{Alias}>" : $"<VK {VirtualKey}>";
            }
        }

        public static Keystroke Parse(string value)
        {
            return !TryParse(value, out var key) ? throw new FormatException($"Invalid keystroke: {value}") : key;
        }

        public static bool TryParse(string value, out Keystroke key)
        {
            key = default;

            if (string.IsNullOrWhiteSpace(value))
            {
                key = None;
                return true;
            }

            // Remove angle brackets if present
            var cleanInput = value.Trim();
            if (cleanInput.StartsWith("<") && cleanInput.EndsWith(">"))
            {
                cleanInput = cleanInput.Substring(1, cleanInput.Length - 2);
            }

            // Handle special cases first
            switch (cleanInput.ToUpperInvariant())
            {
                case "LT":
                    key = new Keystroke('<');
                    return true;
                case "GT":
                    key = new Keystroke('>');
                    return true;
                case "TAB":
                    key = new Keystroke('\t', null, "TAB");
                    return true;
                case "ENTER":
                case "RETURN":
                    key = new Keystroke('\n', null, "ENTER");
                    return true;
                case "SPACE":
                    key = new Keystroke(' ', null, "SPACE");
                    return true;
                case "":
                    key = None;
                    return true;
            }

            // Check if its a virtual key
            if (VirtualKeyMap.TryGetValue(cleanInput, out var virtualKey))
            {
                key = new Keystroke(virtualKey, cleanInput.ToUpperInvariant());
                return true;
            }

            // Handle raw VK notation (ex: VK 56)
            if (cleanInput.StartsWith("VK", StringComparison.OrdinalIgnoreCase))
            {
                var vkString = cleanInput.Substring(3).Trim();
                if (int.TryParse(vkString, out var vk))
                {
                    key = new Keystroke(vk);
                    return true;
                }
            }

            // If it's a single character treat as such
            if (cleanInput.Length == 1)
            {
                key = new Keystroke(cleanInput[0]);
                return true;
            }

            return false;
        }
    }
}