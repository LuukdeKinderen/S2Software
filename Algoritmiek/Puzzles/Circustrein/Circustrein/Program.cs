using System;
using System.Collections.Generic;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<Dier> dieren = new List<Dier>();
            List<Wagon> trein = new List<Wagon>();

            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                dieren.Add(new Dier(r.Next(2) > 0, (Formaat)r.Next(3)));
            }

            Console.WriteLine("random gegenereerde dieren: ");
            foreach (Dier dier in dieren)
            {
                Console.WriteLine(dier.ToString());
            }
            Console.WriteLine();


            // Schijding vlees en niet vleeseters
            for (int d = 0; d < dieren.Count; d++)
            {
                if (d + 1 < dieren.Count)
                {
                    if (!dieren[d].vleesEter && dieren[d + 1].vleesEter)
                    {
                        Swap<Dier>(dieren, d, d + 1);
                        d = -1;
                    }
                }
            }

            // orden op grote als dieren hetzelfde hetzelfde type zijn.
            for (int d = 0; d < dieren.Count; d++)
            {
                if (d + 1 < dieren.Count)
                {
                    if (dieren[d].GetPuntIndex() < dieren[d + 1].GetPuntIndex() && dieren[d].vleesEter == dieren[d + 1].vleesEter)
                    {
                        Swap<Dier>(dieren, d, d + 1);
                        d = -1;
                    }
                }
            }

            Console.WriteLine("Dieren geordend op type en groote: ");
            foreach (Dier dier in dieren)
            {
                Console.WriteLine(dier.ToString());
            }
            Console.WriteLine();

            //Per wagon kijken of dier erbij past. 
            while (dieren.Count > 0)
            {
                trein.Add(new Wagon());
                for (int w = 0; w < trein.Count; w++)
                {
                    for (int d = 0; d < dieren.Count; d++)
                    {
                        if (trein[trein.Count-1].AddDier(dieren[d]))
                        {
                            dieren.Remove(dieren[d]);
                            d = 0;
                        }
                    }
                }

            }

            Console.WriteLine("Dieren per Trein: ");
            for (int t = 0; t < trein.Count; t++)
            {
                Console.WriteLine("trein {0}: ", t);
                Console.WriteLine(trein[t].ToString());
            }


        }

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }




    }
}
