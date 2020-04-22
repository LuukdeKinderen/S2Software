using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Logic
{


    public class Ship
    {
        private List<ShipRow> shipRows;
        public ReadOnlyCollection<ShipRow> ShipRows
        {
            get { return shipRows.AsReadOnly(); }
        }
        public readonly int maxTotalWeight;
        public readonly int xLength;
        public readonly int yLength;

        private int LeftWeight
        {
            get
            {
                if (xLength % 2 != 0)
                {
                    int weight = 0;
                    List<ShipRow> rows = GetLeftRows();
                    for (int i = 0; i <rows.Count-1; i++)
                    {
                        weight += rows[i].Weight;
                    }
                    weight += rows[rows.Count - 1].Weight/2;
                    return weight;
                }
                else
                {
                    return GetLeftRows().Sum(row => row.Weight);
                }
            }
        }
        private int RightWeight
        {
            get
            {
                if (xLength % 2 != 0)
                {
                    int weight = 0;
                    List<ShipRow> rows = GetRightRows();
                    for (int i = 0; i < rows.Count - 1; i++)
                    {
                        weight += rows[i].Weight;
                    }
                    weight += rows[rows.Count - 1].Weight / 2;
                    return weight;
                }
                else
                {
                    return GetRightRows().Sum(row => row.Weight);
                }
            }
        }
        private int TotalWeight
        {
            get { return shipRows.Sum(row => row.Weight); }
        }
        private float PercentageOfMaxWeight
        {
            get
            {
                return (float)100 * TotalWeight / maxTotalWeight;
            }
        }



        public Ship(int xLength, int yLength)
        {
            this.xLength = xLength;
            this.yLength = yLength;
            shipRows = new List<ShipRow>();
            for (int x = 0; x < xLength; x++)
            {
                shipRows.Add(new ShipRow(this.yLength));
            }
            maxTotalWeight = MaxTotalWeight(xLength,yLength);
        }


        public List<Container> DistributeMaxAndReturn(List<Container> containers)
        {
            List<Container> notAdded = new List<Container>();

            foreach (Container container in containers)
            {
                if (!FindRowAndAdd(container))
                {
                    notAdded.Add(container);
                }
            }
            return notAdded;
        }

        public List<Container> DistributeMinAndReturn(List<Container> containers)
        {
            List<Container> notAdded = new List<Container>();
            foreach (Container container in containers)
            {
                if (PercentageOfMaxWeight > 50)
                {
                    notAdded.Add(container);
                }
                else if (!FindRowAndAdd(container))
                {
                    notAdded.Add(container);
                }
            }
            return notAdded;
        }

        private bool FindRowAndAdd(Container container)
        {
            bool added = false;

            if (LeftWeight > RightWeight)
            {
                foreach (ShipRow row in GetRightRows())
                {
                    if (row.AddContainer(container))
                    {
                        added = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (ShipRow row in GetLeftRows())
                {
                    if (row.AddContainer(container))
                    {
                        added = true;
                        break;
                    }
                }
            }
            return added;
        }

        private List<ShipRow> GetLeftRows()
        {
            List<ShipRow> rows = new List<ShipRow>();
            int half = xLength % 2 != 0 ? xLength / 2 + 1 : xLength / 2;
            for (int step = 0; step < half; step++)
            {
                int rowindex = step;
                rows.Add(shipRows[rowindex]);
            }
            return rows;
        }
        private List<ShipRow> GetRightRows()
        {
            List<ShipRow> rows = new List<ShipRow>();
            int half = xLength % 2 != 0 ? xLength / 2 + 1 : xLength / 2;
            for (int step = 0; step < half; step++)
            {
                int rowindex = xLength - 1 - step;
                rows.Add(shipRows[rowindex]);
            }
            return rows;
        }

        public override string ToString()
        {
            float percentageLeft = (float)100 * LeftWeight / TotalWeight;
            float percentageRight = (float)100 * RightWeight / TotalWeight;
            return string.Format
                (
                "Total Containers: {0} \nWeight left: {1} Kg , {2}% \nWeight right: {3} Kg , {4}% \nWeight total: {5} Kg , {6}% of Max({7} Kg)",
                shipRows.Sum(row => row.ContainerCount),
                LeftWeight,
                percentageLeft.ToString("00.000"),
                RightWeight,
                percentageRight.ToString("00.000"),
                TotalWeight,
                PercentageOfMaxWeight.ToString("00.000"),
                maxTotalWeight
                );
        }

        public static int MaxTotalWeight(int xLength, int yLength)
        {
            return 150000 * xLength * yLength;
        }
    }
}
