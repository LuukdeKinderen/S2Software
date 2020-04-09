using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{
    public class BerendBootje
    {
        public List<Container> containerCollection { get; private set; }
        public List<Container> containerCollectionSorted
        {
            get
            {
                List<Container> containers = new List<Container>(containerCollection);
                MyExtensions.Sort(containers);
                return containers;
            }
        }
        public List<Ship> shipCollection { get; private set; }

        private readonly int shipYLength;
        private readonly int shipXLength;
        public BerendBootje(int shipXLength, int shipYLength)
        {
            shipXLength = shipXLength % 2 == 0 ? shipXLength : shipXLength + 1;
            this.shipXLength = shipXLength;
            this.shipYLength = shipYLength;
        }

        public void AddRandomContianers(int number)
        {
            Random r = new Random();
            containerCollection = new List<Container>();
            for (int c = 0; c < number; c++)
            {
                Container container = new Container(r);
                containerCollection.Add(container);
            }
        }

        public void AddContainer(Container container)
        {
            containerCollection.Add(container);
        }

        public void DistribureContainers()
        {
            List<Container> containers = new List<Container>(containerCollectionSorted);
            shipCollection = new List<Ship>();

            int shipCapacity = new Ship(shipXLength, shipYLength).maxTotalWeight;

            while (containers.Count > 0)
            {
                int containersWeight = 0;
                foreach (Container container in containers)
                {
                    containersWeight += container.weight;
                }
                if (containersWeight > shipCapacity / 2)
                {
                    Ship newShip = new Ship(shipXLength, shipYLength);
                    containers = newShip.AddContainers(containers, true);
                    shipCollection.Add(newShip);
                }
                else
                {
                    foreach (Ship ship in shipCollection)
                    {
                        containers = ship.AddContainers(containers, false);
                    }
                }
            }
        }
    }
}
