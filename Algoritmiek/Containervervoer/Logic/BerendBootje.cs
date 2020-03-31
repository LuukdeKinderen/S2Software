using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class BerendBootje
    {
        public List<Container> containterCollection { get; private set; }
        public List<Ship> shipCollection { get; private set; }
        public BerendBootje()
        {
            Random r = new Random();
            containterCollection = new List<Container>();
            for (int c = 0; c < 80; c++)
            {
                containterCollection.Add(new Container(r));
            }
        }

        public void DistribureContainers()
        {
            containterCollection.Orden();
            shipCollection = new List<Ship>() { new Ship(8, 5)};

            shipCollection[0].AddAndDistribute(containterCollection);
        }

        public void AddContainer(Container container)
        {
            containterCollection.Add(container);
        }

    }


    public static class MyExtensions
    {
        public static void Orden(this List<Container> containterList)
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
                if (!containterList[container].valuable && containterList[container + 1].valuable)
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
