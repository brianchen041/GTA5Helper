using System.Runtime.InteropServices;
using System.Threading;

namespace GTA5Helper
{
    class KeyboardSimulator
    {
        private const int PERSON_CLICK_DELAY = 200;

        public static void click(KeyId id)
        {
            //press down id
            Thread.Sleep(PERSON_CLICK_DELAY);
            //press up id
        }
    }

    public enum KeyId
    {
        A = 65,
        //fill up
    }
}
