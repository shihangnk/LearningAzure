using System;

namespace TestAutoFixture.model
{
    public class MyClass
    {
        public IMyInterface _interface;

        public void Map()
        {
            Console.Out.WriteLine("this is in map.. "+_interface.GetIntValue());
        }
    }
}