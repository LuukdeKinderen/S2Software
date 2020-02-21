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
            if(waarde + dier.GetPuntIndex() > 10)
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


        bool bijElkaar(Dier dierEen, Dier dierTwee)
        {
            if (dierEen.vleesEter && dierEen.GetFormaatIndex() >= dierTwee.GetFormaatIndex())
            {
                return false;
            }
            if (dierTwee.vleesEter && dierTwee.GetFormaatIndex() >= dierEen.GetFormaatIndex())
            {
                return false;
            }
            return true;
        }




    }
}
