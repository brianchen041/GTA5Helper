using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace GTA5Helper
{
    class KeyboardSimulator
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, IntPtr dwExtraInfo);

        private const int PERSON_CLICK_DELAY = 200;
        private const byte KEYEVENT_KEYDOWN = 0x01;
        private const byte KEYEVENT_KEYUP = 0x02;

        public static void click(KeyId id)
        {
            //press down id
            keybd_event((byte)id, 0, KEYEVENT_KEYDOWN, (IntPtr)0);

            Thread.Sleep(PERSON_CLICK_DELAY);

            //press up id
            keybd_event((byte)id, 0, KEYEVENT_KEYUP, (IntPtr)0);

        }

        public static void press(KeyId id)
        {
            //press down id
            keybd_event((byte)id, 0, KEYEVENT_KEYDOWN, (IntPtr)0);

        }

        public static void release(KeyId id)
        {
            //press up id
            keybd_event((byte)id, 0, KEYEVENT_KEYUP, (IntPtr)0);
        }

    }

    public enum KeyId
    {
        A = 65,
        //fill up
        M = 0x4D,
        ENTER = 0x0D,
        ESC = 0x1B,
        UP = 0x26,
        ALT = 0x12,
        F4 = 0x73
    }
}
