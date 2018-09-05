using System;

namespace LearningDotNet
{
    public class TestMergeSequentialCheck
    {
        public void test()
        {
            TMSC_1 obj = new TMSC_1();

            if (true)
            {
                obj = null;
            }

            if (obj?.a == null)
            {
                Console.Out.WriteLine("is null");
            }

            obj = new TMSC_1();
            if (obj?.a == null)
            {
                Console.Out.WriteLine("is null");
            }

            Console.Out.WriteLine("......................");

            Console.Out.WriteLine(""+ (obj?.a));

        }


    }

    public class TMSC_1
    {
        public string a;
    }
}