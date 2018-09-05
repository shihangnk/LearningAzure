using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace LearningDotNet
{
    class Program
    {
        private static LinkedList<string> list = new LinkedList<string>();

        static void Main(string[] args)
        {
            // don't use this to set up log4net. Otherwise there is always a redundant output.
            //BasicConfigurator.Configure();

            //new TestYield().Test();
            //new TestAsync().MyTest();
            //Console.In.ReadLine();
            //new TestString().test();
            //new TestGeneric2().test();
            //new TestSwitch().test();
            //new TestUInt().test();
            //new TestProperties().test();
            //new TestLinq().test();
            //new TestMergeSequentialCheck().test();
            //new TestDelegates().test();
            //new TestDateTime().test();
            //new TestKeyword().test();
            //new TestArrayAndList().test();
            //new TestJson().test();
            //new TestTryParse().test();
            //new TestTuple().test();
            //new TestCompareTwoCollections().test();
            new TestAutoFixgture().test();
        }
    }
}
