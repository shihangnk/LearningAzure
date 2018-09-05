using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningDotNet
{
    public class TestYield
    {
        private static LinkedList<string> list = new LinkedList<string>();

        public void test()
        {
            getIEnumable();
        }

        private void getIEnumable()
        {
            foreach(string s in getStrs())
            {
                Console.Out.WriteLine(s);
            }
        }

        private IEnumerable<string> getStrs()
        {
            yield return "abc";
            yield return "def";
        }

        public void test1()
        {
            Console.Out.WriteLine("Test");

            TestYield obj = new TestYield();

            for (int i = 0; i < 100; i++)
            {
                list.AddLast("" + i);
            }

            obj.Fun();
            Console.Out.WriteLine();
            obj.FunList();
        }

        private void Fun()
        {
            DateTimeOffset startTime = DateTimeOffset.Now;
            Console.Out.WriteLine(startTime);
            IEnumerable<string> ret = getStrings();
            DateTimeOffset endTime = DateTimeOffset.Now;
            Console.Out.WriteLine(endTime);

            Console.Out.WriteLine(endTime - startTime);
            Console.Out.WriteLine(ret.Count());
            /*
                        foreach (var VARIABLE in ret)
                        {
                            Console.Out.WriteLine(VARIABLE);
                        }
            */
        }

        private IEnumerable<string> getStrings()
        {
            foreach (var str in list)
            {
                if (str.Contains("234"))
                {
                    yield return str;
                }
            }
        }

        private void FunList()
        {
            DateTimeOffset startTime = DateTimeOffset.Now;
            Console.Out.WriteLine(startTime);
            IEnumerable<string> ret = getStringList();
            DateTimeOffset endTime = DateTimeOffset.Now;
            Console.Out.WriteLine(endTime);

            Console.Out.WriteLine(endTime - startTime);
            Console.Out.WriteLine(ret.Count());
        }

        private LinkedList<string> getStringList()
        {
            LinkedList<string> ret = new LinkedList<string>();
            foreach (var str in list)
            {
                if (str.Contains("234"))
                {
                    ret.AddLast(str);
                }
            }

            return ret;
        }

    }

}