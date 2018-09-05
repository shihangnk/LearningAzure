using System;

namespace LearningDotNet
{
    public class TestKeyword
    {
        public void test()
        {
            int @int = 3;

            Console.Out.WriteLine("@int is "+@int);

            @int = 6;

            Console.Out.WriteLine("@int is " + @int);
        }
    }
}