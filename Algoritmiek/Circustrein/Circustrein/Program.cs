using System;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = 0;
            bool correct = false;
            while (!correct)
            {
                Console.WriteLine("Hoeveel random dieren wil je verdelen?");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int inputAmount))
                {
                    amount = inputAmount;
                    correct = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Vul een geldig getal in");
                }
            }


            List<Dier> dieren = DierFactory.randomDieren(amount);
            Printer.PrintDieren("random gegenereerde dieren: ", dieren);



            Ordener ordener = new Ordener();
            dieren = ordener.OrdenDieren(dieren);
            Printer.PrintDieren("Dieren geordend op type en groote:", dieren);


            Trein trein = new Trein();
            trein.AddDieren(dieren);
            trein.VerdeelDieren();
            Console.WriteLine(trein.ToString());
        }








    }
}
