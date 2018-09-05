using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDotNet
{
    class TestSwitch
    {
        public const string aaa = "aaa";

        public void test()
        {
            testSwitch("test");
            testSwitch(null);
            testSwitch("bbb");
        }

        private void testSwitch(string value)
        {
            switch (value)
            {
                case "aaa":
                    Console.Out.WriteLine("this is aaa");
                    break;
                case "bbb":
                    Console.Out.WriteLine("this is bbb");
                    break;
                default:
                    Console.Out.WriteLine("this is default");
                    break;
            }

        }

        private void testSwitchConstant(string value)
        {
            switch (value)
            {
                case aaa:
                    Console.Out.WriteLine("this is aaa");
                    break;
                case "bbb":
                    Console.Out.WriteLine("this is bbb");
                    break;
                default:
                    Console.Out.WriteLine("this is default");
                    break;
            }

        }


    }
}
