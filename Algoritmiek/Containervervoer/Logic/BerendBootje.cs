using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{
    public class BerendBootje
    {
        public List<Container> containerCollection { get; private set; }
        public List<Ship> shipCollection { get; private set; }
        public BerendBootje()
        {
            Random r = new Random();
            containerCollection = new List<Container>();
            for (int c = 0; c < 500; c++)
            {
                Container cont = new Container(r);

                containerCollection.Add(cont);
            }
        }

        public void DistribureContainers()
        {

            containerCollection.Orden();
            shipCollection = new List<Ship>();
            int bootcount = 0;
            while (containerCollection.Count > 0)
            {
                bootcount++;
                if (bootcount > 3)
                {
                    break;
                }
                shipCollection.Add(new Ship(4, 8));
                containerCollection = AddContainers(shipCollection[shipCollection.Count - 1]);
            }

        }
        List<Container> AddContainers(Ship ship)
        {
            List<Container> notAdded = new List<Container>();
            while (containerCollection.Count > 0)
            {
                Container container = containerCollection[0];
                bool AddToNextShip = true;
                if (container.cooled && container.valuable)
                {
                    //fill only first row with cooled and valuable
                    int y = 0;
                    for (int x = 0; x < ship.xLength; x++)
                    {
                        if (!ship.GetStack(x, y).hasValuable())
                        {
                            if (ship.GetStack(x, y).CanAddContainer(container, true) && AddToNextShip)
                            {
                                ship.GetStack(x, y).AddContainer(container, true);
                                AddToNextShip = false;
                                containerCollection.Remove(container);
                            }
                        }
                    }
                    if (AddToNextShip)
                    {
                        notAdded.Add(container);
                        containerCollection.Remove(container);
                    }
                }
                else if (container.valuable)
                {
                    //fill each even row with valuable
                    for (int y = 0; y < ship.yLength; y += 2)
                    {
                        for (int x = 0; x < ship.xLength; x++)
                        {
                            if (!ship.GetStack(x, y).hasValuable())
                            {
                                if (ship.GetStack(x, y).CanAddContainer(container, true) && AddToNextShip)
                                {
                                    ship.GetStack(x, y).AddContainer(container, true);
                                    AddToNextShip = false;
                                    containerCollection.Remove(container);
                                }
                            }
                        }
                    }
                    //fill last row with valuable
                    for (int x = 0; x < ship.xLength; x++)
                    {
                        if (!ship.GetStack(x, ship.yLength - 1).hasValuable())
                        {
                            if (ship.GetStack(x, ship.yLength - 1).CanAddContainer(container, true) && AddToNextShip)
                            {
                                ship.GetStack(x, ship.yLength - 1).AddContainer(container, true);
                                AddToNextShip = false;
                                containerCollection.Remove(container);
                            }
                        }
                    }
                    if (AddToNextShip)
                    {
                        notAdded.Add(container);
                        containerCollection.Remove(container);
                    }
                }
                else if (container.cooled)
                {
                    //fill only first row with cooled
                    int y = 0;
                    for (int x = 0; x < ship.xLength; x++)
                    {
                        if (ship.GetStack(x, y).CanAddContainer(container, false) && AddToNextShip)
                        {
                            ship.GetStack(x, y).AddContainer(container, false);
                            AddToNextShip = false;
                            containerCollection.Remove(container);
                        }
                    }
                    if (AddToNextShip)
                    {
                        notAdded.Add(container);
                        containerCollection.Remove(container);
                    }
                }
                else
                {
                    for (int y = 1; y < ship.yLength; y += 2)
                    {
                        for (int x = 0; x < ship.xLength; x++)
                        {
                            if (ship.GetStack(x, y).CanAddContainer(container, false))
                            {
                                if (ship.GetStack(x, y + 1) != null)
                                {
                                    if (ship.GetStack(x, y + 1).hasValuable())
                                    {
                                        bool height = ship.GetStack(x, y).Height() + 1 < ship.GetStack(x, y + 1).Height();
                                        while (!height)
                                        {
                                            Container lightContainer = containerCollection[containerCollection.Count - 1];
                                            if (ship.GetStack(x, y + 1).CanAddContainer(lightContainer, false))
                                            {
                                                ship.GetStack(x, y + 1).AddContainer(lightContainer, false);
                                                containerCollection.Remove(lightContainer);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                            height = ship.GetStack(x, y).Height() + 1 < ship.GetStack(x, y + 1).Height();
                                        }
                                        if (height)
                                        {
                                            ship.GetStack(x, y).AddContainer(container, false);
                                            AddToNextShip = false;
                                            containerCollection.Remove(container);
                                        }
                                    }
                                    else
                                    {
                                        ship.GetStack(x, y).AddContainer(container, false);
                                        AddToNextShip = false;
                                        containerCollection.Remove(container);
                                    }
                                }
                                else
                                {
                                    ship.GetStack(x, y).AddContainer(container, false);
                                    AddToNextShip = false;
                                    containerCollection.Remove(container);
                                }
                            }
                        }
                    }
                    if (AddToNextShip)
                    {
                        notAdded.Add(container);
                        containerCollection.Remove(container);
                    }
                }
            }
            return notAdded;
        }


        public void AddContainer(Container container)
        {
            containerCollection.Add(container);
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
