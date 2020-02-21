using System;
using System.IO;

namespace Opdracht3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
