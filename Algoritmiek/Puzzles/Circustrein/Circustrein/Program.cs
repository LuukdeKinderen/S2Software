using System;
using System.Collections.Generic;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Dier> dieren = new List<Dier>() { new Dier(false, Formaat.groot), new Dier(false, Formaat.groot), new Dier(false, Formaat.groot) };
            List<Wagon> trein = new List<Wagon>() { new Wagon()};


            while(dieren.Count!= 0)
            {
                // voeg de beste dieren toe per wagon
            }

        }

        


    }
}
