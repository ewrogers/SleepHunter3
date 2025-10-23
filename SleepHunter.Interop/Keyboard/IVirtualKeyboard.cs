
namespace SleepHunter.Interop.Keyboard
{
    public interface IVirtualKeyboard
    {
        void SendKeyDown(Keystroke keystroke);
        void SendKeyDown(char c);
        void SendKeyDown(int virtualKey);

        void SendKeyUp(Keystroke keystroke);
        void SendKeyUp(char c);
        void SendKeyUp(int virtualKey);
        
        void SendModifierKeyDown(ModifierKeys modifier);
        void SendModifierKeyUp(ModifierKeys modifier);

        void SendKeyPress(Keystroke keystroke);
        void SendKeyPress(char c);
        void SendKeyPress(int virtualKey);
    }
}
