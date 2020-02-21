using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Opdracht1
{
    class Program

    {
        static void Main(string[] args)
        {


            int drie = 0;
            int vijf = 0;
            HashSet<int> lijst = new HashSet<int>();



            while (drie + 3 < 1000)
            {
                drie += 3;
                lijst.Add(drie);
            }

            while (vijf + 5 < 1000)
            {
                vijf += 5;
                lijst.Add(vijf);

            }
            int ans = lijst.Sum();
            Console.WriteLine("sum = {0}", ans);


            //put in a file
            Writefile(ans);



            Console.ReadKey();



        }
        static void Writefile(int ans)
        {
            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            StreamWriter sw = new StreamWriter(path + "\\Output.txt");
            sw.WriteLine("ans = {0}", ans);
            sw.Close();
            Console.WriteLine("find ans in " + path + "Output.txt");
        }
    }
}
