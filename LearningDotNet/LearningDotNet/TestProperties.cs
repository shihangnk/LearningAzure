using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDotNet
{
    public class TestProperties
    {
        public void test()
        {
            TP_A obj = new TP_A();

            obj.Prop1 = 3;

            Console.Out.WriteLine(obj.Prop1);
        }
    }

    class TP_A
    {
        public int Prop1 { get; set; }
    }
}
