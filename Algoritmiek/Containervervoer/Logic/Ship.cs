using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{


    public class Ship
    {

        private Stack[] stacks;
        public readonly int maxTotalWeight;
        public readonly int xLength;
        public readonly int yLength;

        private int LeftWeight
        {
            get
            {
                int weight = 0;
                for (int y = 0; y < yLength; y++)
                {
                    for (int left = 0; left < xLength / 2; left++)
                    {
                        weight += GetStack(left, y).Weight;
                    }
                }
                return weight;
            }
        }
        private int RightWeight
        {
            get
            {
                int weight = 0;
                for (int y = 0; y < yLength; y++)
                {
                    for (int right = xLength / 2; right < xLength; right++)
                    {
                        weight += GetStack(right, y).Weight;
                    }
                }
                return weight;
            }
        }
        private int TotalWeight
        {
            get
            {
                int weight = 0;
                foreach (Stack stack in stacks)
                {
                    weight += stack.Weight;
                }
                return weight;
            }
        }
        private float PercentageOfMaxWeight
        {
            get
            {
                return (float)100 * TotalWeight / maxTotalWeight;
            }
        }

        public bool LeftIsHeaviest
        {
            get
            {
                return LeftWeight > RightWeight;
            }
        }
        private int ContainerCount
        {
            get
            {
                int count = 0;
                foreach (Stack stack in stacks)
                {
                    count += stack.Count;
                }
                return count;
            }
        }

        public Ship(int xLenght, int yLenght)
        {
            this.xLength = xLenght;
            this.yLength = yLenght;
            stacks = new Stack[xLenght * yLenght];
            for (int x = 0; x < xLenght; x++)
            {
                for (int y = 0; y < yLenght; y++)
                {
                    stacks[xLenght * y + x] = new Stack(x, y);
                }
            }
            maxTotalWeight = 150000 * stacks.Length;
        }



        public Stack GetStack(int x, int y)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.x == x && stack.y == y)
                {
                    return stack;
                }
            }
            return null;
        }

        public List<Container> AddContainers(List<Container> containerCollection, bool minimumLoad)
        {
            List<Container> notAdded = new List<Container>();
            while (containerCollection.Count > 0)
            {
                if(PercentageOfMaxWeight > 50 && minimumLoad)
                {
                    break;
                }
                Container container = containerCollection[0];
                bool AddToNextShip = true;
                for (int y = 0; y < yLength; y++)
                {
                    for (int xStep = 0; xStep < xLength / 2; xStep++)
                    {
                        int x = LeftIsHeaviest ? xLength - 1 - xStep : xStep;
                        Stack stack = GetStack(x, y);
                        bool didNotReachHeightLimit = true;
                        if ((y + 1) % 4 == 0 && y != 0 && y != yLength - 1)
                        {
                            Stack prevStack = GetStack(x, y - 1);
                            Stack nextStack = GetStack(x, y + 1);
                            if (nextStack != null)
                            {
                                if (nextStack.HasValuable && nextStack.Count <= stack.Count + 1)
                                {
                                    didNotReachHeightLimit = false;
                                }
                            }
                            if (prevStack != null)
                            {
                                if (prevStack.HasValuable && prevStack.Count <= stack.Count + 1)
                                {
                                    didNotReachHeightLimit = false;
                                }
                            }
                        }
                        if (AddToNextShip && didNotReachHeightLimit)
                        {
                            if (stack.AddContainer(container))
                            {
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
            foreach(Container container in containerCollection)
            {
                notAdded.Add(container);
            }
            return notAdded;
        }


        public override string ToString()
        {

            float percentageLeft = (float)100 * LeftWeight / TotalWeight;
            float percentageRight = (float)100 * RightWeight / TotalWeight;
            return string.Format
                (
                "Total Containers: {0} \nWeight left: {1}Kg , {2}% \nWeight right: {3} Kg , {4}% \nWeight total: {5} Kg , {6}% of Max({7} Kg)",
                ContainerCount,
                LeftWeight,
                percentageLeft.ToString("00.000"),
                RightWeight,
                percentageRight.ToString("00.000"),
                TotalWeight,
                PercentageOfMaxWeight.ToString("00.000"),
                maxTotalWeight
                );
        }
    }
}
