using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public int ContainerCount
        {
            get { return Containers.Count; }
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
        public int TotalWeight
        {
            get
            {
                return containers.Sum(container => container.weight);
            }
        }
        private int BottomLoad
        {
            get
            {
                if (containers.Count > 0)
                {
                    return TotalWeight - containers[ContainerCount - 1].weight;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Stack()
        {
            containers = new List<Container>();
        }

        public bool AddContainer(Container container)
        {
            if (HasValuable && container.valuable)
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
            return String.Format("Height: {0}\nWeight: {1}\nBottomLoad: {2}", ContainerCount, TotalWeight, BottomLoad);
        }
    }
}
