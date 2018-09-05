using System;

namespace LearningDotNet
{
    public class TestAccessModifier
    {

        A obj = new A();
        // object.fun(); // not accessable
        // A.fun1();       // not accessable
    }

    class A
    {
        void fun()
        {

        }

        static void fun1()
        {
        }
    }
}