
namespace SleepHunter.Interop.Mouse
{
    public interface IVirtualMouse
    {
        (int X, int Y) GetCursorPosition();

        void MoveMouse(int x, int y);

        void SendButtonDown(MouseButton button, int x = 0, int y = 0);
        void SendButtonUp(MouseButton button, int x = 0, int y = 0);

        void Click(MouseButton button, int x = 0, int y = 0, bool moveMouse = true);

        void DoubleClick(MouseButton button, int x = 0, int y = 0);
    }
}
