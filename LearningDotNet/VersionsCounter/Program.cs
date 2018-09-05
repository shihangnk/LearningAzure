using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionsCounter
{
    public class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length < 1)
            //{
            //    Console.Out.WriteLine("bad parameter");
            //    return;
            //}

            string inFile = @"c:\temp\in.txt";
            string outFile = @"c:\temp\out.txt";

            var worker = new FileReader();
            worker.work(inFile, outFile);
        }
    }
}
