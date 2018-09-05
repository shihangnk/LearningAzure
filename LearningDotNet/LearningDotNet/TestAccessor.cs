namespace LearningDotNet
{
    public class TestAccessor
    {
        public void test()
        {
            // can't compile because of setter is private.
            //MyEvent myevent = new MyEvent() { strField = "55" };
            MyEvent myevent1 = new MyEvent("55");
        }
    }

    class MyEvent
    {
        public string strField { get; private set; }

        public MyEvent(string arg)
        {
            strField = arg;
        }
    }
}