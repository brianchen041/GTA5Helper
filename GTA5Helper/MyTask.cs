using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace GTA5Helper
{
    class MyTask
    {
        private Boolean sIsRun = false;

        private readonly int MAIN_SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        private readonly int MAIN_SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;

        private const int SECONDS_ONE = 1 * 1000;
        private const int SECONDS_THREE = 3 * 1000;
        private const int SECONDS_FIVE = 5 * 1000;
        private const int SECONDS_TEN = 10 * 1000;
        private const int DEFAULT_REPEAT_TIMES = 5;
        private const int THREE_HOURS_SECONDS = 3 * 3600;

        private Point mPoint1;
        private Point mPoint2;
        private Point mPoint3;
        private Point mPoint4;        
        private Boolean mIsDoFirst = true;
        private int mRepeatTimes;
        private int mLastDoTime;

        public void setPoint(Point point1, Point point2, Point point3, Point point4)
        {
            mPoint1 = point1;
            mPoint2 = point2;
            mPoint3 = point3;
            mPoint4 = point4;
        }

        public void setRepeat(int times)
        {            
            mRepeatTimes = times;           
        }

        public void setDoFirst(Boolean doFirst)
        {
            mIsDoFirst = doFirst;
        }

        public void start(object sender, DoWorkEventArgs e)
        {
            checkConfig();
            sIsRun = true;
            if (mIsDoFirst)            
                buyGoodsOnChair(mPoint1, mPoint2, mPoint3, mPoint4); 
            loop();
        }

        private void checkConfig()
        {
            //TODO: change to scale
            //Check Point
            if (mPoint1 == null) 
                mPoint1 = new Point(907, 641);
            if (mPoint2 == null)
                mPoint2 = new Point(460, 498);
            if (mPoint3 == null)
                mPoint3 = new Point(936, 789);
            if (mPoint4 == null)
                mPoint4 = new Point(1059, 627);

            //Check repeat times
            if (mRepeatTimes <= 0 || mRepeatTimes > 9)
                mRepeatTimes = DEFAULT_REPEAT_TIMES;
        }

        public void stop()
        {
            sIsRun = false;
        }

        private void closeGTA()
        {
            //TODO: Implement it !
        }

        private void shutdown()
        {
            //TODO: Implement it !
        }

        //TODO: Refactor it ...
        private void loop()
        {
            while (sIsRun)
            {
                if(mRepeatTimes <= 0)
                {
                    stop();
                    closeGTA();
                    shutdown();
                    break;
                }
                
                if (Time.getUnixTimestamp() - mLastDoTime >= THREE_HOURS_SECONDS)                
                    buyGoodsOnChair(mPoint1, mPoint2, mPoint3, mPoint4);                
                else                
                    preventIdle();
            }            
        }

        //Prevent do anything after stop
        //TODO: Need to find a better way.
        private Boolean sleep(int millisecond)
        {
            if (!sIsRun)
                return false;
            Thread.Sleep(millisecond);
            return sIsRun;
        }

        private void preventIdle()
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
        private void buyGoodsOnChair(Point point1, Point point2, Point point3, Point point4)
        {
            //State update ...
            mRepeatTimes--;
            mLastDoTime = Time.getUnixTimestamp();

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
