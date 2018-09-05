using System;
using System.Collections.Generic;

namespace LearningDotNet
{
    public class TestArrayAndList
    {
        public void test()
        {
            int[] array = { 1, 3, 5};

            if (((IList<int>) array).Contains(7))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }


        }
    }
}