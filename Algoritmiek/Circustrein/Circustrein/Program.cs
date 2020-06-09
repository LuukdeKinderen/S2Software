using System;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Dier> dieren = DierFactory.randomDieren(10);
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
