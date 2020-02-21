using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            // make fibonnaci with maximum of 4 million
            List<int> fibonnaci = new List<int>() { 1, 2 };
            while (fibonnaci[fibonnaci.Count - 1] + fibonnaci[fibonnaci.Count - 2]<4000000)
            {
                fibonnaci.Add(fibonnaci[fibonnaci.Count - 1] + fibonnaci[fibonnaci.Count - 2]);
            }

            // create list of even positions
            List<bool> even = fibonnaci.Select(x => x % 2 == 0).ToList();

            // add fibonnaci to sum if fibonnaci is even
            int sum = 0;
            for (int i = 0; i < fibonnaci.Count; i++)
            {
                if (even[i])
                {
                    sum += fibonnaci[i];
                }
            }

            //display ans
            Console.WriteLine("ans = {0}", sum);
            Writefile(sum);
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
