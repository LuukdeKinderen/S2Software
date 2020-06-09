using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Circustrein
{
    public class Ordener
    {
        public Ordener()
        {

        }

        public List<Dier> OrdenDieren(List<Dier> dieren)
        {
            return dieren
                .OrderByDescending(d => d.vleesEter)
                .ThenByDescending(d => d.formaat)
                .ToList();
        }
    }
}
