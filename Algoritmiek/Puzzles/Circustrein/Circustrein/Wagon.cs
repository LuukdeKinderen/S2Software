using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    class Wagon
    {
        List<Dier> dieren = new List<Dier>();
        int waarde = 0;
        public Wagon()
        {

        }

        public bool AddDier(Dier dier)
        {
            if (waarde + dier.GetPuntIndex() > 10)
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
            waarde += dier.GetPuntIndex();
            dieren.Add(dier);
            return true;
        }


        bool bijElkaar(Dier dierEen, Dier dierTwee)
        {
            if (dierEen.vleesEter && dierEen.GetPuntIndex() >= dierTwee.GetPuntIndex())
            {
                return false;
            }
            if (dierTwee.vleesEter && dierTwee.GetPuntIndex() >= dierEen.GetPuntIndex())
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

            str += "Beladingswaarde: " + waarde.ToString() + "\n\n\n\n\n";
            return str;
        }
    }
}
