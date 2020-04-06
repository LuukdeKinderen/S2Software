using System;
using System.Collections.Generic;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<Dier> dieren = new List<Dier>();

            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                dieren.Add(new Dier(r.Next(2) > 0, (Formaat)(r.Next(3) * 2 + 1)));
            }

            PrintDieren("random gegenereerde dieren: ", dieren);



            Ordener ordener = new Ordener();
            ordener.OrdenDieren(dieren);            
            PrintDieren("Dieren geordend op type en groote:", dieren);

            Trein trein = new Trein();
            trein.VerdeelDieren(dieren);
            Console.WriteLine(trein.ToString());

        }



        public static void PrintDieren(string message, List<Dier> dieren)
        {
            Console.WriteLine(message);
            foreach (Dier dier in dieren)
            {
                Console.WriteLine(dier.ToString());
            }
            Console.WriteLine();
        }




    }
}
