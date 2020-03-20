using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public enum ShipFormat
    {
        small = 4,
        medium = 6,
        large = 8

    }

    public class Ship
    {

        public Stack[,] stacks { get; private set; }
        private readonly int maxTotalWeight;
        public Ship(ShipFormat format)
        {
            stacks = new Stack[(int)format/2,(int)format];
            Random rnd = new Random();
            for (int c = 0; c < stacks.GetLength(0); c++)
            {
                for (int r = 0; r < stacks.GetLength(1); r++)
                {
                    stacks[c, r] = new Stack(rnd);
                }
            }
            maxTotalWeight = 150000 * (int)format;
        }

        public bool AddContainer(Container container)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.AddContaintainer(container))
                {
                    return true;
                }
            }
            return false;
        }


        private enum Part
        {
            total,
            firsHalf,
            secondHalf
        }
        //private int Weight(Part part)
        //{
        //    int weight = 0;
        //    switch (part)
        //    {
        //        case Part.total:
        //            foreach (Stack stack in stacks)
        //            {
        //                weight += stack.Weight();
        //            }
        //            break;
        //        case Part.firsHalf:
        //            for (int s = 0; s < stacks.Count / 2; s++)
        //            {
        //                weight += stacks[s].Weight();
        //            }
        //            break;
        //        case Part.secondHalf:
        //            for (int s = stacks.Count / 2; s < stacks.Count; s++)
        //            {
        //                weight += stacks[s].Weight();
        //            }
        //            break;
        //    }
        //    return weight;
        //}

        public List<string>[,] GetStringList()
        {
            List<string>[,] shipStringList = new List<string>[stacks.GetLength(0), stacks.GetLength(1)];
            for (int c = 0; c < shipStringList.GetLength(0); c++)
            {
                for (int r = 0; r < shipStringList.GetLength(1); r++)
                {
                    shipStringList[c,r] = stacks[c, r].GetStringList();
                }
            }
            return shipStringList;
        }

        //private bool capsizeDanger()
        //{
        //    if (Weight(Part.total) < maxTotalWeight / 2)
        //    {
        //        return true;
        //    }
        //    if(Weight(Part.firsHalf) < maxTotalWeight *0.4 || Weight(Part.firsHalf) > maxTotalWeight * 0.6)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}
