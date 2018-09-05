using System;
using System.Globalization;
using System.Net;

namespace LearningDotNet
{
    public class TestTryParse
    {
        public void test()
        {
            test1();
            Console.Out.WriteLine("------------------------------------------------------");
            test2();
            Console.Out.WriteLine("------------------------------------------------------");
            test3();
            Console.Out.WriteLine("------------------------------------------------------");
            test4();
        }
        public void test1()
        {
            String[] values = { null, "160519", "9432.0", "16,667","   -322   ", "+4302", "(100);", "01FA" };
            foreach (var value in values)
            {
                int number;

                bool result = Int32.TryParse(value, out number);
                if (result)
                {
                    Console.WriteLine("Converted '{0}' to {1}.", value, number);
                }
                else
                {
                    //            if (value == null) value = ""; 
                    Console.WriteLine("Attempted conversion of '{0}' failed.", value == null ? "<null>" : value);
                }
            }
        }

        public void test2()
        {
            string value = "123";

            bool result = int.TryParse(value, out int number);
            Console.Out.WriteLine(" result "+result);
            if (!Int32.TryParse(value, out number)) throw new Exception("Provide an int forDays");

            Console.Out.WriteLine("forDays " + number);
        }

        public void test3()
        {
            string value = " 2016-09-10  ";

            bool result = DateTime.TryParse(value, out DateTime number);
            Console.Out.WriteLine(" result " + result);

            Console.Out.WriteLine("forDays " + number);

            value = "2018-09-10";
            result = DateTime.TryParseExact(value, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime date);
            Console.Out.WriteLine(" result " + result);

            Console.Out.WriteLine("date " + date);

        }

        public void test4()
        {
            string[] dateStrings = {"05/01/2009 14:57:32.8", "2009-05-01 14:57:32.8",
                "2009-05-01T14:57:32.8375298-04:00", "5/01/2008",
                "5/01/2008 14:57:32.80 -07:00",
                "1 May 2008 2:57:32.8 PM", "16-05-2009 1:00:32 PM",
                "Fri, 15 May 2009 20:10:57 GMT" };
            DateTime dateValue;

            Console.WriteLine("Attempting to parse strings using {0} culture.", CultureInfo.CurrentCulture.Name);
            foreach (string dateString in dateStrings)
            {
                if (DateTime.TryParse(dateString, out dateValue))
                    Console.WriteLine("  Converted '{0}' to {1} ({2}).", dateString,
                        dateValue, dateValue.Kind);
                else
                    Console.WriteLine("  Unable to parse '{0}'.", dateString);
            }
        }

    }
}