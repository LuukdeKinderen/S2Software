using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Logic
{
    public class BerendBootje
    {
        private List<Container> containers;

        public ReadOnlyCollection<Container> containerCollection
        {
            get
            {
                return containers.AsReadOnly();
            }
        }
        public ReadOnlyCollection<Container> containerCollectionSorted
        {
            get
            {
                List<Container> containersSorted = new List<Container>(containers);
                MyExtensions.Sort(containersSorted);
                return containersSorted.AsReadOnly();
            }
        }

        private List<Ship> ships;
        public ReadOnlyCollection<Ship> shipCollection
        {
            get
            {
                return ships.AsReadOnly();
            }
        }

        private int shipYLength = 0;
        private int shipXLength = 0;

        public bool HasShipFormat
        {
            get
            {
                return shipYLength != 0 && shipXLength != 0;
            }
        }

        public BerendBootje()
        {
            containers = new List<Container>();
        }




        public void SetShipFormat(int shipXLength, int shipYLength)
        {
            shipXLength = shipXLength % 2 == 0 ? shipXLength : shipXLength + 1;
            this.shipXLength = shipXLength;
            this.shipYLength = shipYLength;
        }

        public void AddRandomContianers(int number)
        {
            Random r = new Random();
            for (int c = 0; c < number; c++)
            {
                Container container = new Container(r);
                containers.Add(container);
            }
        }

        public void AddContainer(bool valuable, bool cooled, int weight)
        {
            Container container = new Container(valuable, cooled, weight);
            containers.Add(container);
        }

        public void ClearContainers()
        {
            containers.Clear();
        }

        public void DistributeContainers()
        {
            List<Container> containersToDistibute = new List<Container>(containerCollectionSorted);
            ships = new List<Ship>();

            int shipCapacity = new Ship(shipXLength, shipYLength).maxTotalWeight;

            while (containersToDistibute.Count > 0)
            {
                int containersWeight = containersToDistibute.Sum(e => e.weight);
                //foreach (Container container in containersToDistibute)
                //{
                //    containersWeight += container.weight;
                //}
                if (containersWeight > shipCapacity / 2)
                {
                    Ship newShip = new Ship(shipXLength, shipYLength);
                    containersToDistibute = newShip.AddContainers(containersToDistibute, true);
                    ships.Add(newShip);
                }
                else
                {
                    foreach (Ship ship in ships)
                    {
                        containersToDistibute = ship.AddContainers(containersToDistibute, false);
                    }
                    if (containersToDistibute.Count != 0)
                    {
                        foreach (Container container in containersToDistibute)
                        {
                            Debug.WriteLine(container);
                        }

                        containersToDistibute.Clear();
                    }
                }
            }
        }
    }
}
