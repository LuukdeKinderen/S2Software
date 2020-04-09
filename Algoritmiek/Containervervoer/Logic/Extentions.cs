using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public static class MyExtensions
    {
        public static void Sort(this List<Container> containterList)
        {
            for (int container = 0; container < containterList.Count - 1; container++)
            {
                if (containterList[container].weight < containterList[container + 1].weight)
                {
                    containterList.Swap(container, container + 1);
                    container = -1;
                }
            }
            for (int container = 0; container < containterList.Count - 1; container++)
            {
                if (!containterList[container].cooled && containterList[container + 1].cooled)
                {
                    containterList.Swap(container, container + 1);
                    container = -1;
                }
            }
            for (int container = 0; container < containterList.Count - 1; container++)
            {
                if (!containterList[container].valuable && containterList[container + 1].valuable)
                {
                    containterList.Swap(container, container + 1);
                    container = -1;
                }
            }


        }
        public static void SortForStack(this List<Container> containterList)
        {
            for (int container = 0; container < containterList.Count - 1; container++)
            {
                if (containterList[container].weight > containterList[container + 1].weight)
                {
                    containterList.Swap(container, container + 1);
                    container = -1;
                }
            }
            for (int container = 0; container < containterList.Count - 1; container++)
            {
                if (!containterList[container].valuable && containterList[container + 1].valuable)
                {
                    containterList.Swap(container, container + 1);
                    container = -1;
                }
            }


        }

        public static string ExtendedToString(this List<Container> containterList)
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
            str += string.Format("Valuable: {0}\n", valuable);
            str += string.Format("Cooled: {0}\n", cooled);
            str += string.Format("Regular: {0}\n", containterList.Count - valuableCooled - valuable - cooled);
            str += string.Format("Total: {0}\n", containterList.Count);
            return str;
        }

        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
