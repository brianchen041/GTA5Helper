using System;
using System.ComponentModel;
using System.Threading;

namespace GTA5Helper
{
    class MyTask
    {
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
            MouseSimulator.TeleportTo(960, 540);
            MouseSimulator.MoveTo(960, (540 - 1));            
            Thread.Sleep(SECONDS_ONE);
            MouseSimulator.MoveTo(960, 540);
            Thread.Sleep(SECONDS_TEN);
        }
    }    
}
