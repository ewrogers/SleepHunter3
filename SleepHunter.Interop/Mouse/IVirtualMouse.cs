
namespace SleepHunter.Interop.Mouse
{
    public interface IVirtualMouse
    {
        MousePoint GetCursorPosition();

        void MoveMouse(int x, int y);
        void MoveMouse(MousePoint point);

        void SendButtonDown(MouseButton button, int x = 0, int y = 0);
        void SendButtonDown(MouseButton button, MousePoint point);

        void SendButtonUp(MouseButton button, int x = 0, int y = 0);
        void SendButtonUp(MouseButton button, MousePoint point);

        void Click(MouseButton button, int x = 0, int y = 0);
        void Click(MouseButton button, MousePoint point);

        void DoubleClick(MouseButton button, int x = 0, int y = 0);
        void DoubleClick(MouseButton button, MousePoint point);
    }
}
