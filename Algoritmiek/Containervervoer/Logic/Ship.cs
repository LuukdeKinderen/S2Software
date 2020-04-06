using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{


    public class Ship
    {

        public Stack[] stacks { get; private set; }
        private readonly int maxTotalWeight;
        public readonly int xLength;
        public readonly int yLength;
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


        private int LeftWeight()
        {
            int weight = 0;
            for (int y = 0; y < yLength; y++)
            {
                for (int left = 0; left < xLength / 2; left++)
                {
                    weight += GetStack(left, y).Weight();
                }
            }
            return weight;
        }
        private int RightWeight()
        {
            int weight = 0;
            for (int y = 0; y < yLength; y++)
            {
                for (int right = xLength / 2; right < xLength; right++)
                {
                    weight += GetStack(right, y).Weight();
                }
            }
            return weight;
        }
        private int TotalWeight()
        {
            int weight = 0;
            foreach (Stack stack in stacks)
            {
                weight += stack.Weight();
            }
            return weight;
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


        public override string ToString()
        {

            float percentageLeft = (float)100 * LeftWeight() / TotalWeight();
            float percentageRight = (float)100 * RightWeight() / TotalWeight();
            float percentageOfMax = (float)100 * TotalWeight() / maxTotalWeight;
            return string.Format("Total Containers: {0} \nWeight left: {1}Kg , {2}% \nWeight right: {3} Kg , {4}% \nWeight total: {5} Kg , {6}% of Max({7} Kg)", ContainerCount, LeftWeight(), percentageLeft.ToString("00.000"), RightWeight(), percentageRight.ToString("00.000"), TotalWeight(), percentageOfMax.ToString("00.000"), maxTotalWeight);
        }
    }
}
