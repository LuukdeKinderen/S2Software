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

        /// <summary>
        /// Paces a container on this stack
        /// </summary>
        /// <param name="container">the container you want to place</param>
        /// <param name="top">Do you want to place the container on top</param>
        public void AddContainer(Container container, bool top)
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

        /// <summary>
        /// Returns true when the load of the bottom conainer is not overwriten.
        /// </summary>
        /// <param name="container">the container you want to place</param>
        /// <param name="top">Do you want to place the container on top</param>
        public bool CanAddContainer(Container container, bool top)
        {
            return top ? BottomLoad() + container.weight <= 120000 : Weight() <= 120000;
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

        private int BottomLoad()
        {
            if (containers.Count > 0)
            {
                return Weight() - containers[Containers.Count - 1].weight;
            }
            else
            {
                return 0;
            }
        }
        public int Height()
        {
            return containers.Count;
        }

        public override string ToString()
        {
            return String.Format("Height: {0}, Weight: {1}, BottomLoad: {2}", containers.Count, Weight(), BottomLoad());
        }
    }
}
