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
                containersSorted.SortForShip();
                return containersSorted.AsReadOnly();
            }
        }
        public ReadOnlyCollection<Container> containersFailedToDistribute;

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
                return shipYLength > 0 && shipXLength > 0;
            }
        }

        public BerendBootje()
        {
            containers = new List<Container>();
            ships = new List<Ship>();
        }

        public void SetShipFormat(int shipXLength, int shipYLength)
        {
            this.shipXLength = shipXLength;
            this.shipYLength = shipYLength;
        }

        public void AddRandomContianers(int number)
        {
           containers.AddRange(ContainerConstructor.CreateRanomContainers(number));
        }

        public void AddContainer(bool valuable, bool cooled, int weight)
        {
            containers.Add(ContainerConstructor.CreateContainer(valuable, cooled, weight));
        }

        public void ClearContainers()
        {
            containers.Clear();
        }

        public void DistributeContainers()
        {
            List<Container> containersToDistibute = new List<Container>(containerCollectionSorted);
            ships.Clear();
            containersFailedToDistribute = new List<Container>().AsReadOnly();
            int shipCapacity = Ship.MaxTotalWeight(shipXLength, shipYLength);

            while (containersToDistibute.Count > 0)
            {
                int containersWeight = containersToDistibute.Sum(e => e.weight);

                if (containersWeight > shipCapacity / 2)
                {
                    Ship newShip = new Ship(shipXLength, shipYLength);
                    containersToDistibute = newShip.DistributeMinAndReturn(containersToDistibute);
                    ships.Add(newShip);
                }
                else
                {
                    foreach (Ship ship in ships)
                    {
                        containersToDistibute = ship.DistributeMaxAndReturn(containersToDistibute);
                    }
                    if (containersToDistibute.Count != 0)
                    {
                        containersFailedToDistribute = new List<Container>(containersToDistibute).AsReadOnly();

                        containersToDistibute.Clear();
                    }
                }
            }
        }

        
    }
}
