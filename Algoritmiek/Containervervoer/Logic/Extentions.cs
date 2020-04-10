using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Logic
{
    public static class MyExtensions
    {
        public static void Sort(this List<Container> containterList)
        {
            List<Container> list = new List<Container>(containterList);

            list = list.OrderBy(x => -x.weight).ToList();
            list = list.OrderBy(x => !x.cooled).ToList();
            list = list.OrderBy(x => !x.valuable).ToList();

            containterList.Clear();
            containterList.AddRange(list);
        }
        public static void SortForStack(this List<Container> containterList)
        {
            List<Container> list = new List<Container>(containterList);

            list = list.OrderBy(x => -x.weight).ToList();
            list = list.OrderBy(x => !x.valuable).ToList();

            containterList.Clear();
            containterList.AddRange(list);
        }

        public static string ExtendedToString(this ReadOnlyCollection<Container> containterList)
        {
            string str = "";
            int valuableCooled = 0;
            int valuable = 0;
            int cooled = 0;
            foreach (Container container in containterList)
            {
                if (container.valuable && container.cooled)
                {
                    valuableCooled++;
                }
                else if (container.valuable)
                {
                    valuable++;
                }
                else if (container.cooled)
                {
                    cooled++;
                }
            }
            str += string.Format("Valuable and Cooled: {0}\n", valuableCooled);
            str += string.Format("Only Valuable: {0}\n", valuable);
            str += string.Format("Only Cooled: {0}\n", cooled);
            str += string.Format("Regular: {0}\n", containterList.Count - valuableCooled - valuable - cooled);
            str += string.Format("Total: {0}\n", containterList.Count);
            return str;
        }

    }
}
