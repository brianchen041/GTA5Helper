using System;
using System.ComponentModel;
using System.Threading;

namespace GTA5Helper
{
    class MyTask
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            MOWSEEVENTF_ABSOLOTE = 0x8000
        }

        const uint ABS_MOVE_FLAG = (uint)(MouseEventFlags.MOVE | MouseEventFlags.MOWSEEVENTF_ABSOLOTE);


        public static Boolean sIsRun = false;

        const int SECONDS_ONE = 1 * 1000;
        const int SECONDS_TEN = 10 * 1000;

        public static void loop(object sender, DoWorkEventArgs e)
        {
            while (sIsRun)
            {
                preventIdle();
            }            
        }

        private static void preventIdle()
        {
            // TODO: Find a better way.
            int x = 65536 / 2;            
            int y = 65536 / 2;
            SetCursorPos(960, 540);
            mouse_event(ABS_MOVE_FLAG, (uint)x, (uint)(y-66), 0, 0);            
            Thread.Sleep(SECONDS_ONE);
            mouse_event(ABS_MOVE_FLAG, (uint)x, (uint)y, 0, 0);
            Thread.Sleep(SECONDS_TEN);
        }
    }    
}
