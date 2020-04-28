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

        public static List<Container> CreateRandomContainers(int number)
        {
            Random r = new Random();
            List<Container> containers = new List<Container>();
            for (int c = 0; c < number; c++)
            {
                Container container = CreateRandom(r);
                containers.Add(container);
            }
            return containers;
        }

        public static Container CreateRandom(Random r)
        {
            int weight = r.Next(4000, 30001);
            bool valuable = r.Next(0, 15) < 1;
            bool cooled = r.Next(0, 25) < 1;

            return new Container(valuable, cooled, weight);
        }

    }
}
