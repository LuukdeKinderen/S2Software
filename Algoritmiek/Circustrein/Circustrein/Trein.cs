using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    public class Trein
    {
        private List<Wagon> trein;
        public IReadOnlyList<Wagon> treinWagons { get {return trein.AsReadOnly(); } }

        private List<Dier> dieren;
        public Trein()
        {
            trein = new List<Wagon>();            
        }

        public void AddDieren(List<Dier> dieren)
        {
            this.dieren = new List<Dier>(dieren);
        }

        public void VerdeelDieren()
        {
            //Orden Dieren
            Ordener ordener = new Ordener();
            dieren = ordener.OrdenDieren(dieren);

            //Per wagon kijken of dier erbij past. 
            while (dieren.Count > 0)
            {
                trein.Add(new Wagon());
                for (int d = 0; d < dieren.Count; d++)
                {
                    Wagon lastWagon = trein[trein.Count - 1];
                    Dier dier = dieren[d];
                    if (lastWagon.TryAndAddDier(dier))
                    {
                        dieren.Remove(dier);
                        d = -1;
                    }
                }
            }
        }

        public override string ToString()
        {
            string str = "";

            str += "Dieren per Wagon: \n";
            for (int t = 0; t < trein.Count; t++)
            {

                str += string.Format("wagon {0}: \n", t);
                str += string.Format("{0}\n", trein[t].ToString());
            }

            return str;
        }
    }
}
