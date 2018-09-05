using System;

namespace LearningDotNet
{
    public class TestString
    {
        public void test()
        {
            TestString obj = new TestString();
            obj.fun();
//            obj.testInterpolation();
        }

        private void fun()
        {
            Console.Out.WriteLine("" + new Time(18, 1, 0).ToString());
        }

        private void testInterpolation()
        {
            string s1 = "aaa";

            Console.Out.WriteLine($"this is {s1}");

            string s2 = null;
            Console.Out.WriteLine($"this is s2 [{s2}]");
            Console.Out.WriteLine($"this is s2 [" + s2 + "]");
        }
    }


    class Time
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public Time(uint h, uint m, uint s)
        {
            if (h > 23 || m > 59 || s > 59)
            {
                throw new ArgumentException("Invalid time specified");
            }
            Hours = (int)h; Minutes = (int)m; Seconds = (int)s;
        }

        public Time(DateTime dt)
        {
            Hours = dt.Hour;
            Minutes = dt.Minute;
            Seconds = dt.Second;
        }

        public override string ToString()
        {
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
    }
}