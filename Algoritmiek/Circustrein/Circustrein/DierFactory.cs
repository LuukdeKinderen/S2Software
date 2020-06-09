using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    public static class DierFactory
    {

        public static List<Dier> randomDieren(int amount)
        {
            Random r = new Random();
            List<Dier> dieren = new List<Dier>();
            for (int i = 0; i < amount; i++)
            {
                Dier newDier = new Dier(r);
                dieren.Add(newDier);
            }
            return dieren;
        }
    }
}
