using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Stack
    {
        public List<Container> stack { get; private set; }

        public Stack(Random r)
        {
            stack = new List<Container>();
            for (int i = 0; i < 4; i++)
            {
                stack.Add(new Container(r));
            }
        }

        public bool AddContaintainer(Container container)
        {
            if (stack[stack.Count - 1].valuable)
            {
                return false;
            }

            int load = container.load;
            for (int c = 1; c < stack.Count; c++)
            {
                load += stack[c].load;
            }

            if(load > 120000)
            {
                return false;
            }


            stack.Add(container);
            return true;
        }

        public int Weight()
        {
            int weight = 0;
            foreach (Container container in stack)
            {
                weight += container.load;
            }
            return weight;
        }

        public List<string> GetStringList()
        {
            List<string> stackStrList = new List<string>();
            foreach(Container container in stack)
            {
                stackStrList.Add(container.ToString());
            }
            return stackStrList;
        }
    }
}
