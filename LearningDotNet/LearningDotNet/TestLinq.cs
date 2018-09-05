using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningDotNet
{
    public class TestLinq
    {
        public void test()
        {
            List<TL_1> list = new List<TL_1>();
            list.Add(new TL_1(1));
            list.Add(new TL_1(2));
            list.Add(new TL_1(3));

            {
                IEnumerable<TL_2> output = list.Select(new Mapper().Map);
                foreach (var item in output)
                {
                    Console.Out.WriteLine(item.s);
                }
            }

            {
                TL_2[] output2 = list.Select(new Mapper().Map).ToArray();
                Console.Out.WriteLine("the lenght is " + output2.Length);
                foreach (var item in output2)
                {
                    Console.Out.WriteLine(item.s);
                }
            }

            {
                Console.Out.WriteLine("---------------------");
                list = new List<TL_1>();
                TL_2[] output3 = list.Select(new Mapper().Map).ToArray();
                Console.Out.WriteLine("the lenght is " + output3.Length);
            }
        }
    }



    class TL_1
    {
        public int i;

        public TL_1(int v)
        {
            i = v;
        }
    }

    class TL_2
    {
        public string s;
    }

    class Mapper
    {
        public TL_2 Map(TL_1 obj1)
        {
            return new TL_2
            {
                s = "[" + obj1.i + "]"
            };
        }
    }
}