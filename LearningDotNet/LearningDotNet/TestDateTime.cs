using System;
using System.Globalization;

namespace LearningDotNet
{
    public class TestDateTime
    {
        public void test()
        {
            //test1();
            test2();
        }

        public void test1()
        { 
            Console.Out.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));

            DateTime startDate = DateTime.ParseExact("2009-10-12", "yyyy-MM-dd", null);
            Console.Out.WriteLine(startDate.ToString("yyyy-MM-dd"));

            Console.Out.WriteLine(DateTime.MaxValue);
            Console.Out.WriteLine(DateTime.MinValue);

            // Assume the current culture is en-US.
            // Create a DateTime for the first of May, 2003.
            DateTime dt = new DateTime(2018, 5, 31);
            Console.WriteLine("Is Thursday the day of the week for {0:d}?: {1}",
                dt, dt.DayOfWeek == DayOfWeek.Thursday);
            Console.WriteLine("The day of the week for {0:d} is {1}.", dt, dt.DayOfWeek);

            Console.WriteLine(".............................");
            // Return day of 1/13/2009.
            DateTime dateGregorian = new DateTime(2009, 1, 13);
            Console.WriteLine(dateGregorian.Day);
            // Displays 13 (Gregorian day).

            // Create date of 1/13/2009 using Hijri calendar.
            HijriCalendar hijri = new HijriCalendar();
            DateTime dateHijri = new DateTime(1430, 1, 17, hijri);
            // Return day of date created using Hijri calendar.
            Console.WriteLine(dateHijri.Day);
            // Displays 13 (Gregorian day).

            // Display day of date in Hijri calendar.
            Console.WriteLine(hijri.GetDayOfMonth(dateHijri));
            // Displays 17 (Hijri day).
        }

        public void test2()
        {
            DateTime d1 = new DateTime(1999, 12, 31, 1, 2,3);
            DateTime d2 = new DateTime(1999, 1, 31, 1, 2, 3);

            Console.Out.WriteLine("d1.equals(d2) "+d1.Equals(d2));
            Console.Out.WriteLine("d1==d2 "+(d1==d2));

            
        }
    }
}