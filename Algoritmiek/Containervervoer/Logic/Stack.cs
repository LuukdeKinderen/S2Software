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

        public Stack(int x, int y)
        {
            containers = new List<Container>();
            this.x = x;
            this.y = y;
        }

        public void AddContainer(Container container, bool? top)
        {
            if (top == true)
            {
                containers.Insert(0, container);
            }
            else
            {
                containers.Add(container);
            }
        }

        public bool hasValuable()
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

        public int Weight()
        {
            int weight = 0;

            foreach (Container container in containers)
            {
                weight += container.weight;
            }
            return weight;
        }

        public int Height()
        {
            return containers.Count;
        }

        public override string ToString()
        {
            return String.Format("Height: {0} Weight: {1}", containers.Count, Weight());
        }
    }
}
