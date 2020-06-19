using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Circustrein
{
    public class Wagon
    {
        private List<Dier> dieren = new List<Dier>();
        public IReadOnlyList<Dier> wagonDieren { get { return dieren.AsReadOnly(); } }

        public readonly int maxWaarde;
        public int Waarde { get { return dieren.Sum(dier => (int)dier.formaat); } }

        public Wagon()
        {
            maxWaarde = 10;
        }

        public bool TryAndAddDier(Dier dier)
        {
            if (WaardeLimiet(dier))
            {
                return false;
            }

            foreach (Dier d in dieren)
            {
                if (!bijElkaar(d, dier))
                {
                    return false;
                }
            }

            dieren.Add(dier);
            return true;
        }

        private bool WaardeLimiet(Dier dier)
        {
            return Waarde + (int)dier.formaat > maxWaarde;
        }

        private bool bijElkaar(Dier dierEen, Dier dierTwee)
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
            foreach (Dier dier in dieren)
            {
                str += dier.ToString();
            }

            str += "Beladingswaarde: " + Waarde.ToString() + "\n\n\n";
            return str;
        }
    }
}
