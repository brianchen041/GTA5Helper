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
        const int SECONDS_FIVE = 5 * 1000;
        const int SECONDS_TEN = 10 * 1000;

        public static void loop(object sender, DoWorkEventArgs e)
        {
            //++++
            Point p1 = new Point(907, 641);
            Point p2 = new Point(460, 498);
            Point p3 = new Point(936, 789);
            Point p4 = new Point(1059, 627);
            buyGoodsOnChair(p1, p2, p3, p4);
            //----

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

        //TODO: Refactor it ...
        private static void buyGoodsOnChair(Point point1, Point point2, Point point3, Point point4)
        {
            if (sleep(SECONDS_THREE))
                //Be a CEO and Open the Web.                
                SendKeys.SendWait("{Enter}");
            //KeyboardSimulator.click(KeyId.A);
            //Web operate
            if (sleep(SECONDS_FIVE))
                MouseSimulator.LeftClick(point1);            
            if (sleep(SECONDS_THREE)) 
                MouseSimulator.LeftClick(point2);            
            if (sleep(SECONDS_THREE))
                MouseSimulator.LeftClick(point3);            
            if (sleep(SECONDS_THREE)) 
                MouseSimulator.LeftClick(point4);
            //Close Web
            if (sleep(SECONDS_THREE))
                SendKeys.SendWait("{Esc}");
            if (sleep(SECONDS_THREE))
                SendKeys.SendWait("{Esc}");
            //Close CEO
            if (sleep(SECONDS_THREE))
                SendKeys.SendWait("{M}");
            if (sleep(SECONDS_THREE))
                SendKeys.SendWait("{Enter}");
            if (sleep(SECONDS_THREE))
                SendKeys.SendWait("{Up}");
            if (sleep(SECONDS_THREE))
                SendKeys.SendWait("{Enter}");
            if (sleep(SECONDS_THREE))
                SendKeys.SendWait("{Enter}");
            sleep(SECONDS_FIVE);
        }
    }    
}
