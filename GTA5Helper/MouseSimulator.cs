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
        private static readonly double SCALE_MUTIPLE_WIDTH = (double)65535 / (WIDTH-1);
        private static readonly double SCALE_MUTIPLE_HEIGHT = (double)65535 / (HEIGHT-1);

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

        public static void LeftClick(int x, int y)
        {
            uint scaleX = (uint)(x * SCALE_MUTIPLE_WIDTH);
            uint scaleY = (uint)(y * SCALE_MUTIPLE_HEIGHT);
            mouse_event((uint)(MouseEventFlags.LEFTDOWN | MouseEventFlags.ABSOLUTE), scaleX, scaleY, 0, 0);
            mouse_event((uint)(MouseEventFlags.LEFTUP | MouseEventFlags.ABSOLUTE), scaleX, scaleY, 0, 0);
        }

        public static void RightClick(int x, int y)
        {
            uint scaleX = (uint)(x * SCALE_MUTIPLE_WIDTH);
            uint scaleY = (uint)(y * SCALE_MUTIPLE_HEIGHT);
            mouse_event((uint)(MouseEventFlags.RIGHTDOWN | MouseEventFlags.ABSOLUTE), scaleX, scaleY, 0, 0);
            mouse_event((uint)(MouseEventFlags.RIGHTUP | MouseEventFlags.ABSOLUTE), scaleX, scaleY, 0, 0);
        }

        public static void MoveTo(int x, int y)
        {
            uint scaleX = (uint)(x * SCALE_MUTIPLE_WIDTH);
            uint scaleY = (uint)(y * SCALE_MUTIPLE_HEIGHT);
            mouse_event((uint)(MouseEventFlags.MOVE | MouseEventFlags.ABSOLUTE), scaleX, scaleY, 0, 0);            
        }

        public static void TeleportTo(int x, int y)
        {
            SetCursorPos(x, y);
        }
    }
}
