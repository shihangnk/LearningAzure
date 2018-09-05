using System;

namespace LearningDotNet
{
    public delegate void SimpleDelegate();

    public class TestDelegates
    {
        public void test()
        {
            SimpleDelegate myDelegate = new SimpleDelegate(MyFun);
            myDelegate();
        }

        public void MyFun()
        {
            Console.Out.WriteLine("this is my fun");
        }
    }
}