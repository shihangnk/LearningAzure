using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDotNet
{
    public class TestTuple
    {
        public void test()
        {
            //test1();
            //test2();
            test3();
        }

        void test1()
        {
            // Create a 7-tuple.
            var population = new Tuple<string, int, int, int, int, int, int>(
                "New York", 7891957, 7781984,
                7894862, 7071639, 7322564, 8008278);
            // Display the first and last elements.
            Console.WriteLine("Population of {0} in 2000: {1:N0}",
                population.Item1, population.Item7);
        }

        void test2()
        {
            var population = Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278);
            // Display the first and last elements.
            Console.WriteLine("Population of {0} in 2000: {1:N0}",
                population.Item1, population.Item7);
        }

        Tuple<string, string, int> getTuple()
        {
            return Tuple.Create("aa", "bb", 3);
        }

        void test3()
        {
            var tuple = getTuple();
            Console.Out.WriteLine(tuple.Item1 +"|"+tuple.Item2+"|"+tuple.Item3);
        }
    }
}
