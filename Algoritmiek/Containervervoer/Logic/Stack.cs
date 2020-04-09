using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Logic
{
    public class Stack
    {

        private List<Container> containers;
        public ReadOnlyCollection<Container> Containers
        {
            get { return containers.AsReadOnly(); }
        }
        public readonly int x;
        public readonly int y;
        public int Count
        {
            get
            {
                return Containers.Count;
            }
        }
        public bool HasValuable
        {
            get
            {
                foreach (Container container in containers)
                {
                    if (container.valuable)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public int Weight
        {
            get
            {
                int weight = 0;
                foreach (Container container in containers)
                {
                    weight += container.weight;
                }
                return weight;
            }
        }
        private int BottomLoad
        {
            get
            {
                if (containers.Count > 0)
                {
                    return Weight - containers[Count - 1].weight;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Stack(int x, int y)
        {
            containers = new List<Container>();
            this.x = x;
            this.y = y;
        }

        public bool AddContainer(Container container)
        {

            if (HasValuable && container.valuable)
            {
                return false;
            }
            if (container.valuable && y % 2 != 0)
            {
                return false;
            }
            if (container.cooled && y != 0)
            {
                return false;
            }
            containers.Add(container);
            containers.SortForStack();
            if (BottomLoad <= 120000)
            {
                return true;
            }
            else
            {
                containers.Remove(container);
                return false;
            }

        }

        public override string ToString()
        {
            return String.Format("Position: ({0},{1})\nHeight: {2}\nWeight: {3}\nBottomLoad: {4}", x, y, Count, Weight, BottomLoad);
        }
    }
}
