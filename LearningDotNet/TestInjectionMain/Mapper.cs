namespace TestInjectionMain
{
    public interface IMap
    {
        string Map(int a);
    }

    public class Mapper
    {
        public string Map(int a)
        {
            return "..." + a;
        }
    }
}