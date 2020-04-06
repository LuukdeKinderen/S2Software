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
            for (int c = 0; c < 400; c++)
            {
                Container cont = new Container(r);

                containerCollection.Add(cont);
            }
        }

        public void DistribureContainers()
        {

            containerCollection.Orden();
            shipCollection = new List<Ship>();
            while (containerCollection.Count > 0)
            {

                shipCollection.Add(new Ship(8,4));
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
                    for (int xStep = 0; xStep < ship.xLength / 2; xStep++)
                    {
                        int xLeft = xStep;
                        int xRight = ship.xLength - 1 - xStep;
                        if (!ship.GetStack(xLeft, y).hasValuable())
                        {
                            AddToNextShip = AddContainer(ship.GetStack(xLeft, y), container, true, AddToNextShip);
                        }
                        if (!ship.GetStack(xRight, y).hasValuable())
                        {
                            AddToNextShip = AddContainer(ship.GetStack(xRight, y), container, true, AddToNextShip);
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
                        for (int xStep = 0; xStep < ship.xLength / 2; xStep++)
                        {
                            int xLeft = xStep;
                            int xRight = ship.xLength - 1 - xStep;
                            if (!ship.GetStack(xLeft, y).hasValuable())
                            {
                                AddToNextShip = AddContainer(ship.GetStack(xLeft, y), container, true, AddToNextShip);
                            }
                            if (!ship.GetStack(xRight, y).hasValuable())
                            {
                                AddToNextShip = AddContainer(ship.GetStack(xRight, y), container, true, AddToNextShip);
                            }
                        }
                    }
                    //fill last row with valuable
                    for (int xStep = 0; xStep < ship.xLength / 2; xStep++)
                    {
                        int xLeft = xStep;
                        int xRight = ship.xLength - 1 - xStep;
                        if (!ship.GetStack(xLeft, ship.yLength - 1).hasValuable())
                        {
                            AddToNextShip = AddContainer(ship.GetStack(xLeft, ship.yLength - 1), container, true, AddToNextShip);
                        }
                        if (!ship.GetStack(xRight, ship.yLength - 1).hasValuable())
                        {
                            AddToNextShip = AddContainer(ship.GetStack(xRight, ship.yLength - 1), container, true, AddToNextShip);
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
                    for (int xStep = 0; xStep < ship.xLength / 2; xStep++)
                    {
                        int xLeft = xStep;
                        int xRight = ship.xLength - 1 - xStep;
                        AddToNextShip = AddContainer(ship.GetStack(xLeft, y), container, false, AddToNextShip);
                        AddToNextShip = AddContainer(ship.GetStack(xRight, y), container, false, AddToNextShip);
                    }
                    if (AddToNextShip)
                    {
                        notAdded.Add(container);
                        containerCollection.Remove(container);
                    }
                }
                else
                {
                    //fill uneven rows with normal containers.
                    for (int y = 1; y < ship.yLength; y += 2)
                    {
                        for (int xStep = 0; xStep < ship.xLength / 2; xStep++)
                        {
                            int xLeft = xStep;
                            int xRight = ship.xLength - 1 - xStep;
                            if (ship.GetStack(xLeft, y).CanAddContainer(container, false))
                            {
                                if (ship.GetStack(xLeft, y + 1) != null)
                                {
                                    if (ship.GetStack(xLeft, y + 1).hasValuable())
                                    {
                                        bool height = ship.GetStack(xLeft, y).Count + 1 < ship.GetStack(xLeft, y + 1).Count;
                                        while (!height)
                                        {
                                            Container lightContainer = containerCollection[containerCollection.Count - 1];
                                            if (ship.GetStack(xLeft, y + 1).CanAddContainer(lightContainer, false))
                                            {
                                                ship.GetStack(xLeft, y + 1).AddContainer(lightContainer, false);
                                                containerCollection.Remove(lightContainer);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                            height = ship.GetStack(xLeft, y).Count + 1 < ship.GetStack(xLeft, y + 1).Count;
                                        }
                                        if (height && AddToNextShip)
                                        {
                                            ship.GetStack(xLeft, y).AddContainer(container, false);
                                            AddToNextShip = false;
                                            containerCollection.Remove(container);
                                        }
                                    }
                                    else if (AddToNextShip)
                                    {
                                        ship.GetStack(xLeft, y).AddContainer(container, false);
                                        AddToNextShip = false;
                                        containerCollection.Remove(container);
                                    }
                                }
                                else if (AddToNextShip)
                                {
                                    ship.GetStack(xLeft, y).AddContainer(container, false);
                                    AddToNextShip = false;
                                    containerCollection.Remove(container);
                                }
                            }
                            if (ship.GetStack(xRight, y).CanAddContainer(container, false))
                            {
                                if (ship.GetStack(xRight, y + 1) != null)
                                {
                                    if (ship.GetStack(xRight, y + 1).hasValuable())
                                    {
                                        bool height = ship.GetStack(xRight, y).Count + 1 < ship.GetStack(xRight, y + 1).Count;
                                        while (!height)
                                        {
                                            Container lightContainer = containerCollection[containerCollection.Count - 1];
                                            if (ship.GetStack(xRight, y + 1).CanAddContainer(lightContainer, false))
                                            {
                                                ship.GetStack(xRight, y + 1).AddContainer(lightContainer, false);
                                                containerCollection.Remove(lightContainer);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                            height = ship.GetStack(xRight, y).Count + 1 < ship.GetStack(xRight, y + 1).Count;
                                        }
                                        if (height && AddToNextShip)
                                        {
                                            ship.GetStack(xRight, y).AddContainer(container, false);
                                            AddToNextShip = false;
                                            containerCollection.Remove(container);
                                        }
                                    }
                                    else if (AddToNextShip)
                                    {
                                        ship.GetStack(xRight, y).AddContainer(container, false);
                                        AddToNextShip = false;
                                        containerCollection.Remove(container);
                                    }
                                }
                                else if (AddToNextShip)
                                {
                                    ship.GetStack(xRight, y).AddContainer(container, false);
                                    AddToNextShip = false;
                                    containerCollection.Remove(container);
                                }
                            }
                        }
                    }
                    //fill even rows with normal containers
                    for (int y = 0; y < ship.yLength; y += 2)
                    {
                        for (int xStep = 0; xStep < ship.xLength / 2; xStep++)
                        {
                            int xLeft = xStep;
                            int xRight = ship.xLength - 1 - xStep;
                            AddToNextShip = AddContainer(ship.GetStack(xLeft, y), container, false, AddToNextShip);
                            AddToNextShip = AddContainer(ship.GetStack(xRight, y), container, false, AddToNextShip);
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

        private bool AddContainer(Stack stack, Container container, bool top, bool AddToNextShip)
        {
            if (stack.CanAddContainer(container, top) && AddToNextShip)
            {
                stack.AddContainer(container, top);
                AddToNextShip = false;
                containerCollection.Remove(container);
                return AddToNextShip;
            }
            return AddToNextShip;
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
