using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace GTA5Helper
{
    class MyTask
    {
        public static Boolean sIsRun = false;

        private static readonly int MAIN_SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        private static readonly int MAIN_SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;        

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
            //Move to main screen center
            MouseSimulator.TeleportTo(MAIN_SCREEN_WIDTH / 2, MAIN_SCREEN_HEIGHT / 2);
            MouseSimulator.MoveTo(MAIN_SCREEN_WIDTH / 2, (MAIN_SCREEN_HEIGHT / 2 - 1));
            Thread.Sleep(SECONDS_ONE);
            MouseSimulator.MoveTo(MAIN_SCREEN_WIDTH / 2, MAIN_SCREEN_HEIGHT / 2);
            Thread.Sleep(SECONDS_TEN);
        }
    }    
}
