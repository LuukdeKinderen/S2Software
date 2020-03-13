using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    class Wagon
    {
        private List<Dier> dieren = new List<Dier>();
        public Wagon()
        {

        }

        public bool AddDier(Dier dier)
        {
            
            if (Waarde() + (int)dier.formaat > 10)
            {
                return false;
            }
            foreach(Dier d in dieren)
            {
                if (!bijElkaar(d, dier))
                {
                    return false;
                }
            }
            dieren.Add(dier);
            return true;
        }

        private int Waarde()
        {
            int waarde = 0;
            foreach (Dier dier in dieren)
            {
                waarde += (int)dier.formaat;
            }
            return waarde;
        }

        bool bijElkaar(Dier dierEen, Dier dierTwee)
        {
            if (dierEen.vleesEter && dierEen.formaat >= dierTwee.formaat)
            {
                return false;
            }
            if (dierTwee.vleesEter && dierTwee.formaat >= dierEen.formaat)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {

            string str = "";
            foreach(Dier dier in dieren)
            {
                str += dier.ToString();
            }

            str += "Beladingswaarde: " + Waarde().ToString() + "\n\n\n\n\n";
            return str;
        }
    }
}
