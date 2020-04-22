using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
   public class ContainerConstructor
    {
        public static Container CreateContainer(bool valuable, bool cooled, int weight)
        {
            return new Container(valuable, cooled, weight);
        }

        public static List<Container> CreateRanomContainers(int number)
        {
            Random r = new Random();
            List<Container> containers = new List<Container>();
            for (int c = 0; c < number; c++)
            {
                Container container = new Container(r);
                containers.Add(container);
            }
            return containers;
        }
    }
}
