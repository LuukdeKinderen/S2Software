using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    class Trein
    {
        private List<Wagon> trein = new List<Wagon>();
        public Trein()
        {


        }

        public void VerdeelDieren(IList<Dier> dieren)
        {
            //Per wagon kijken of dier erbij past. 
            while (dieren.Count > 0)
            {
                trein.Add(new Wagon());
                for (int w = 0; w < trein.Count; w++)
                {
                    for (int d = 0; d < dieren.Count; d++)
                    {
                        if (trein[trein.Count - 1].AddDier(dieren[d]))
                        {
                            dieren.Remove(dieren[d]);
                            d = 0;
                        }
                    }
                }

            }
        }

        public override string ToString()
        {
            string str = "";

            str += "Dieren per Trein: \n";
            for (int t = 0; t < trein.Count; t++)
            {
                
                str += string.Format("trein {0}: \n", t);
                str += string.Format("{0}\n", trein[t].ToString());
            }

            return str;
        }
    }
}
