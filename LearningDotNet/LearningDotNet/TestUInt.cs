using System;

namespace LearningDotNet
{
    public class TestUInt
    {
        public void test()
        {
            int h = -8;
            int m = 5;
            int s = 6;

            if ((uint)h > 23 || m > 59 || s > 59)
            {
                Console.Out.WriteLine("Invalid time specified");
            }
            else
            {
                Console.Out.WriteLine("good");
            }
        }
    }
}