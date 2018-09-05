using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VersionsCounter
{
    public class FileReader
    {

        private List<DeviceInfo> list;

        public void work(string inFileName, string outFileName)
        {
            list = new List<DeviceInfo>();
            read(inFileName);
            write(outFileName);
        }

        private void read(string inFileName)
        { 
            Console.Out.WriteLine(inFileName);

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(inFileName);
            while ((line = file.ReadLine()) != null)
            {
//                System.Console.WriteLine(line);
                DeviceInfo newItem = JsonConvert.DeserializeObject<DeviceInfo>(line);
                if (newItem == null)
                {
                    System.Console.WriteLine(line);
                    newItem = new DeviceInfo
                    {
                        Client = new StringItem {Fields = new string[]{".."}},
                        DeviceId = new IntItem{Fields = new int[]{-2}},
                        LocationId = new IntItem { Fields = new int[] { -2 } },
                        UserId = new IntItem { Fields = new int[] { -2 }} 
                    };
                }
                if (newItem.DeviceId == null )
                {
                    System.Console.WriteLine(line);
                    newItem.DeviceId = new IntItem { Fields = new []{-1}};
                }

                if (newItem.Client == null)
                {
                    System.Console.WriteLine(line);
                    newItem.Client = new StringItem { Fields = new[] { "NotSure" } };
                }

                int i = 0;
                for (; i < list.Count; i++)
                {
                    var item = list.ElementAt(i);
                    if (newItem.DeviceId.Fields[0] == item.DeviceId.Fields[0] && newItem.LocationId.Fields[0]==item.LocationId.Fields[0])
                    {
                        item.Count++;
                        if (newItem.Client.Fields[0].CompareTo(item.Client.Fields[0]) >= 0)
                        {
                            item.Client.Fields[0] = newItem.Client.Fields[0];
                        }
                        break;
                    }
                }

                if (i == list.Count)
                {
                    newItem.Count = 1;
                    list.Add(newItem);
                }
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
        }

        private void write(string outFileName)
        {
            list = list.OrderByDescending(o => o.Client.Fields[0]).ToList();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outFileName))
            {
                file.WriteLine("Version  DeviceId  LocationId   Count");
                foreach (DeviceInfo line in list)
                {
                    file.WriteLine(""+line.Client.Fields[0]+"   "+ line.DeviceId.Fields[0]+"  "+line.LocationId.Fields[0]+"  "+line.Count);
                }
            }
        }
    }
}
