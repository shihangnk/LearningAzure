using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LearningDotNet
{
    public class TestGeneric
    {
        public void test()
        {
            Promotion<ICondition> promotion = new Promotion<ICondition>();
            
            List<ICondition> list = new List<ICondition>();

            Condition1 c1 = new Condition1(3, "bbb");
            Condition2 c2 = new Condition2(5.43);

            list.Add(c1);
            list.Add(c2);

            promotion.Conditions = list;

            // convert to json
            var json = JsonConvert.SerializeObject(promotion);
            Console.WriteLine(json);

            // parse json
            parseJson(json);
        }

        public void parseJson(string json)
        {
            Console.WriteLine("parsing...");

//            List<ICondition> list = JsonConvert.DeserializeObject<>()
        }
    }

    class Promotion<T> where T: ICondition
    {
        public Guid Id;
        public List<T> Conditions;

        public Promotion()
        {
            Id = Guid.NewGuid();
        }
    }

    class Condition<T> where T : ICondition
    {
        public string Type;
        public T Value;

        public Condition(T value)
        {
            Value = value;
            Type = Value.GetType().ToString();
        }
    }

    interface ICondition
    {
    }

    class Condition1 : ICondition
    {
        public int A;
        public string B;

        public Condition1(int a, string b)
        {
            A = a;
            B = b;
        }
    }

    class Condition2 : ICondition
    {
        public double C;

        public Condition2(double c)
        {
            C = c;
        }
    }
}