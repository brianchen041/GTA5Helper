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
        const int SECONDS_THREE = 3 * 1000;
        const int SECONDS_TEN = 10 * 1000;

        public static void loop(object sender, DoWorkEventArgs e)
        {
            while (sIsRun)
            {
                preventIdle();
            }            
        }

        //Prevent do anything after stop
        //TODO: Need to find a better way.
        private static Boolean sleep(int millisecond)
        {
            if (!sIsRun)
                return false;
            Thread.Sleep(millisecond);
            return sIsRun;
        }

        private static void preventIdle()
        {
            //Move to main screen center
            Point centerPoint = new Point(MAIN_SCREEN_WIDTH / 2, MAIN_SCREEN_HEIGHT / 2);            
            MouseSimulator.TeleportTo(centerPoint);
            MouseSimulator.MoveTo(centerPoint.X, (centerPoint.Y - 1));
            if(sleep(SECONDS_ONE))
                MouseSimulator.MoveTo(centerPoint);
            sleep(SECONDS_TEN);            
        }

        private static void buyGoodsOnChair(Point point1, Point point2, Point point3, Point point4)
        {
            //Be a CEO and Open the Web.
            SendKeys.SendWait("{Enter}");
            if (sleep(SECONDS_THREE))
                MouseSimulator.LeftClick(point1);            
            if (sleep(SECONDS_THREE)) 
                MouseSimulator.LeftClick(point2);            
            if (sleep(SECONDS_THREE))
                MouseSimulator.LeftClick(point3);            
            if (sleep(SECONDS_THREE)) 
                MouseSimulator.LeftClick(point4);
            //TODO: implement leave to chair.            
        }
    }    
}
