using System;

namespace GTA5Helper
{
    class Time
    {
        //TODO: Check overflow ?
        public static int getUnixTimestamp()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
