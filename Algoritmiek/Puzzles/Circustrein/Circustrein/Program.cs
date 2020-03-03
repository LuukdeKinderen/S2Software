using System;
using System.Collections.Generic;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Dier> dieren = new List<Dier>() { new Dier(false, Formaat.groot), new Dier(false, Formaat.middel), new Dier(false, Formaat.middel), new Dier(false, Formaat.klein), new Dier(false, Formaat.klein), new Dier(false, Formaat.klein), new Dier(false, Formaat.groot), new Dier(false, Formaat.groot) };
            List<Wagon> trein = new List<Wagon>() { new Wagon() };


            while (dieren.Count != 0)
            {
                for (int w = 0; w < trein.Count; w++)
                {
                    for (int d = 0; d < dieren.Count; d++)
                    {
                        if (trein[w].AddDier(dieren[d]))
                        {
                            dieren.Remove(dieren[d]);
                            d = 0;
                            //break;
                        }
                    }
                }
                trein.Add(new Wagon());
                // voeg de beste dieren toe per wagon
            }

            foreach(Wagon wagon in trein)
            {
                Console.WriteLine(wagon.ToString());
            }
            Console.WriteLine("test");

        }




    }
}
