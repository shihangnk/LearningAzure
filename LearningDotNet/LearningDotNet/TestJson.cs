using System;
using Newtonsoft.Json;

namespace LearningDotNet
{
    public class TestJson
    {
        public void test()
        {
            Videogame vg = new Videogame
            {
                id = 5,
//                Name = "Red Alert",
                ReleaseDate = DateTime.Now
            };

            string json = JsonConvert.SerializeObject(vg, Formatting.Indented);
            Console.WriteLine(json);
        }
    }

    class Videogame : BaseClass
    {
        //[JsonProperty("name")]
        //public string Name { get; set; }

        //[JsonProperty]
        //public string Name { get; set; }
        private string Name = "this is name";

        public DateTime ReleaseDate { get; set; }
    }

    class BaseClass
    {
        [JsonProperty(Order = -2)]
        public int id { get; set; }

        public int lastone { get; set; }
    }

}