using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ShipRow
    {

        public ReadOnlyCollection<Stack> Stacks
        {
            get { return stacks.AsReadOnly(); }
        }

        private List<Stack> stacks;

        public int Weight
        {
            get { return stacks.Sum(stack => stack.TotalWeight); }
        }
        public int ContainerCount
        {
            get { return stacks.Sum(stack => stack.ContainerCount); }
        }

        public ShipRow(int length)
        {
            stacks = new List<Stack>();
            for (int y = 0; y < length; y++)
            {
                stacks.Add(new Stack());
            }
        }


        public bool AddContainer(Container container)
        {
            bool DidAdd = false;
            for (int stackIndex = 0; stackIndex < stacks.Count; stackIndex++)
            {
                if (CanAdd(stackIndex, container))
                {
                    if (stacks[stackIndex].AddContainer(container))
                    {
                        DidAdd = true;
                        break;
                    }
                }
            }
            return DidAdd;
        }

        private bool CanAdd(int stackIndex, Container container)
        {
            bool canAdd = true;

            if (container.valuable && stackIndex % 2 != 0)
            {
                canAdd = false;
            }
            if (container.cooled && stackIndex != 0)
            {
                canAdd = false;
            }

            //check heightlimit so valuable containers can be accessed
            if ((stackIndex + 1) % 4 == 0)
            {
                if (HeightLimit(stackIndex))
                {
                    canAdd = false;
                }
            }
            return canAdd;
        }

        private bool HeightLimit(int stackIndex)
        {
            Stack stack = stacks[stackIndex];

            if (stackIndex - 1 > 0)
            {
                Stack prevStack = stacks[stackIndex - 1];
                if (prevStack.HasValuable && prevStack.ContainerCount <= stack.ContainerCount + 1)
                {
                    return true;
                }
            }

            if (stackIndex + 1 < stacks.Count)
            {
                Stack nextStack = stacks[stackIndex + 1];
                if (nextStack.HasValuable && nextStack.ContainerCount <= stack.ContainerCount + 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
