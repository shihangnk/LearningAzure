using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace LearningDotNet
{
    public class TestAutoFixgture
    {
        public void test()
        {
            var fixture = new Fixture();
            var runCount = 10;
            Console.WriteLine("Same instance bool");
            for (int i = 0; i < runCount; i++)
            {
                Console.WriteLine(""+i+"   "+fixture.Create<bool>());
            }

            Console.WriteLine("New Instance bool");
            for (int i = 0; i < runCount; i++)
            {
                // always the same (true)
                Console.WriteLine("" + i + "   " + new Fixture().Create<bool>());
            }

            Console.WriteLine("Same Instance Ints");
            for (int i = 0; i < runCount; i++)
            {
                Console.WriteLine("" + i + "   " + fixture.Create<int>());
            }

            Console.WriteLine("New Instance Ints");
            for (int i = 0; i < runCount; i++)
            {
                // always the same
                Console.WriteLine("" + i + "   " + new Fixture().Create<int>());
            }

            Console.WriteLine("Same Instance Enum");
            for (int i = 0; i < runCount; i++)
            {
                Console.WriteLine("" + i + "   " + fixture.Create<MyEnum>());
            }

            Console.WriteLine("New Instance Enum");
            for (int i = 0; i < runCount; i++)
            {
                // always the same
                Console.WriteLine("" + i + "   " + new Fixture().Create<MyEnum>());
            }

            Console.WriteLine("Same Instance InnerClass");
            for (int i = 0; i < runCount; i++)
            {
                var obj = fixture.Create<A1>();
                Console.WriteLine("" + i + "   " + obj.i+"  "+obj.e+"  "+obj.a2.e);
            }

        }
    }

    enum MyEnum
    {
        enum1, enum2, enum3
    }

    class A1
    {
        public int i;
        public MyEnum e;
        public A2 a2;
    }

    class A2
    {
        public int i;
        public MyEnum e;
    }
}
