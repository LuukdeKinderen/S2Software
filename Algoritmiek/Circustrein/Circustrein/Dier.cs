using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    public enum Formaat
    {
        klein= 1,
        middel=3,
        groot=5
    }
    public class Dier
    {
        public bool vleesEter{ private set; get; }
        public Formaat formaat { private set; get; }


        public Dier(bool vleesEter, Formaat formaat)
        {
            this.vleesEter = vleesEter;
            this.formaat = formaat;
        }

        public Dier(Random r)
        {
            vleesEter = r.Next(2) > 0;
            formaat = (Formaat)(r.Next(3) * 2 + 1);
        }



        public override string ToString()
        {
            string eter = vleesEter ? "vleesEter" : "PlantentEter";
            string dier = "| " + eter + " " + formaat.ToString() + " |";
            int strl = dier.Length-2;
            dier = "+\n" + dier + "\n+";
            while (strl > 0)
            {
                dier = "-" + dier + "-";
                strl--;

            }
            dier = "+" + dier + "+\n";

            return dier;
        }
    }
}
