using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GTA5Helper
{
    class MouseSimulator
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private static readonly int WIDTH = Screen.PrimaryScreen.Bounds.Width;
        private static readonly int HEIGHT = Screen.PrimaryScreen.Bounds.Height;
        private static readonly double SCALE_MUTIPLE_WIDTH = (double)65535 / (WIDTH - 1);
        private static readonly double SCALE_MUTIPLE_HEIGHT = (double)65535 / (HEIGHT - 1);

        enum MouseEventFlags
        {
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            MOVE = 0x0001,
            ABSOLUTE = 0x8000,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,            
        }

        public static void LeftClick()
        {            
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        public static void LeftClick(int x, int y)
        {
            TeleportTo(x, y);
            LeftClick();
        }

        public static void LeftClick(Point point)
        {
            LeftClick(point.X, point.Y);
        }

        public static void RightClick()
        {
            mouse_event((uint)MouseEventFlags.RIGHTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.RIGHTUP, 0, 0, 0, 0);
        }

        public static void RightClick(int x, int y)
        {
            TeleportTo(x, y);
            RightClick();
        }

        public static void RightClick(Point point)
        {
            RightClick(point.X, point.Y);
        }

        public static void MiddleClick()
        {
            mouse_event((uint)MouseEventFlags.MIDDLEDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.MIDDLEUP, 0, 0, 0, 0);
        }

        public static void MiddleClick(int x, int y)
        {
            TeleportTo(x, y);
            MiddleClick();
        }

        public static void MiddleClick(Point point)
        {
            MiddleClick(point.X, point.Y);
        }

        public static void MoveTo(int x, int y)
        {
            uint scaleX = (uint)(x * SCALE_MUTIPLE_WIDTH);
            uint scaleY = (uint)(y * SCALE_MUTIPLE_HEIGHT);
            mouse_event((uint)(MouseEventFlags.MOVE | MouseEventFlags.ABSOLUTE), scaleX, scaleY, 0, 0);            
        }

        public static void MoveTo(Point point)
        {
            MoveTo(point.X, point.Y);
        }

        public static void TeleportTo(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void TeleportTo(Point point)
        {
            TeleportTo(point.X, point.Y);
        }
    }
}
