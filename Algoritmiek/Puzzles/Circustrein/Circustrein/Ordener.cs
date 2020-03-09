using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    class Ordener
    {
        public Ordener()
        {

        }

        public void OrdenDieren(IList<Dier> dieren)
        {
            // Schijding vlees en niet vleeseters
            SorteerVlees(dieren);

            // orden op grote als dieren hetzelfde hetzelfde type zijn.
            SorteerFormaat(dieren);

        }

        private void SorteerVlees(IList<Dier> dieren)
        {
            for (int d = 0; d < dieren.Count; d++)
            {
                if (d + 1 < dieren.Count)
                {
                    if (!dieren[d].vleesEter && dieren[d + 1].vleesEter)
                    {
                        Swap<Dier>(dieren, d, d + 1);
                        d = -1;
                    }
                }
            }
        }

        private void SorteerFormaat(IList<Dier> dieren)
        {
            for (int d = 0; d < dieren.Count; d++)
            {
                if (d + 1 < dieren.Count)
                {
                    if (dieren[d].formaat < dieren[d + 1].formaat && dieren[d].vleesEter == dieren[d + 1].vleesEter)
                    {
                        Swap<Dier>(dieren, d, d + 1);
                        d = -1;
                    }
                }
            }
        }
        private void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
