using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    public static class Printer
    {
        public static void PrintDieren(string message, List<Dier> dieren)
        {
            Console.WriteLine(message);
            foreach (Dier dier in dieren)
            {
                Console.WriteLine(dier);
            }
            Console.WriteLine();
        }
    }
}
