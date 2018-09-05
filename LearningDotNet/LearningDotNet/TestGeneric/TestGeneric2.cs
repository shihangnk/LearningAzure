using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LearningDotNet
{
    public class TestGeneric2
    {
        public void test()
        {
            MyClass myObj = new MyClass();
            myObj.i = 200;
            List<Element<IMyInterface>> list = new List<Element<IMyInterface>>();

            C1 c1 = new C1("bbb");
            c1.C1List = new List<string>();
            c1.C1List.Add("element 1");
            c1.C1List.Add("element 2");

            list.Add(new Element<IMyInterface>(c1));
            list.Add(new Element<IMyInterface>(new C2(5.43)));

            myObj.list = list;

            // convert to json
            var json = JsonConvert.SerializeObject(myObj);
            Console.WriteLine(json);

//            string json = "{\"list\":[{\"Value\":{\"StrValue\":\"bbb\"}},{\"Value\":{\"DoubleValue\":5.43}}]}";

            // parse json
            parseJson(json);
        }

        public void parseJson(string json)
        {
            Console.WriteLine("parsing...");
            // How to parse the json back to MyClass?
            
            MyClass myObject = JsonConvert.DeserializeObject<MyClass>(json);
            Console.WriteLine("size "+ myObject.list.Count);
            Console.WriteLine(JsonConvert.SerializeObject(myObject));
        }
    }

    interface IMyInterface{}

    class C1 : IMyInterface
    {
        public string StrValue;
        public List<string> C1List;
        public C1()
        {
        }

        public C1(string s)
        {
            StrValue = s;
        }
    }

    class C2 : IMyInterface
    {
        public double DoubleValue;  // different member type than C1

        public C2()
        {
        }

        public C2(double v)
        {
            DoubleValue = v;
        }
    }

    class Element<T> where T : IMyInterface
    {
        [JsonConverter(typeof(MyConverter2))]
        public T Value;

        public Element(T value)
        {
            Value = value;
        }
    }

    class MyClass
    {
        public int i;
        public List<Element<IMyInterface>> list;
    }

    class MyConverter : JsonConverter<IMyInterface>
    {
        public override void WriteJson(JsonWriter writer, IMyInterface value, JsonSerializer serializer)
        {
            Console.Out.WriteLine("This in writeJson()");

            // we can write json in two different ways
            // way 1: custom write
/*
            writer.WriteStartObject();
            if (value is C1)
            {
                C1 c1 = (C1) value;
                writer.WritePropertyName("StrValue");
                serializer.Serialize(writer, c1.StrValue);
            }else if (value is C2)
            {
                C2 c2 = (C2) value;
                writer.WritePropertyName("DoubleValue");
                serializer.Serialize(writer, c2.DoubleValue);
            }
            writer.WriteEndObject();
*/

            // way 2: auto write
            serializer.Serialize(writer, value);
        }

        public override bool CanWrite
        {
            // we don't have to implement WriteJson() method if it is false.
            get { return true; }
        }

        public override IMyInterface ReadJson(JsonReader reader, Type objectType, IMyInterface existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            if (jObject["StrValue"] != null)
            {
                C1 c1 = new C1(jObject["StrValue"].Value<string>());
                return c1;
            }else if (jObject["DoubleValue"] != null)
            {
                C2 c2 = new C2(jObject["DoubleValue"].Value<double>());
                return c2;
            }
            else
            {
                Console.Out.WriteLine("Failed to find out the field");
            }

            return null;
        }
    }

    class MyConverter2 : JsonCreationConverter<IMyInterface>
    {
        protected override IMyInterface Create(Type objectType, JObject jObject)
        {
            if (FieldExists("StrValue", jObject))
            {
                return new C1();
            }
            else if (FieldExists("DoubleValue", jObject))
            {
                return new C2();
            }
            return null;
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }


    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Console.Out.WriteLine("this is JsonCreationConverter.ReadJson()");

            if (reader.TokenType == JsonToken.Null)
                return null;

            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, jObject);
            using (JsonTextReader newReader = new JsonTextReader(new StringReader(writer.ToString())))
            {
                newReader.Culture = reader.Culture;
                newReader.DateParseHandling = reader.DateParseHandling;
                newReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
                newReader.FloatParseHandling = reader.FloatParseHandling;
                serializer.Populate(newReader, target);
            }

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Console.Out.WriteLine("this is JsonCreationConverter.WriteJson()");
            serializer.Serialize(writer, value);
        }
    }
}