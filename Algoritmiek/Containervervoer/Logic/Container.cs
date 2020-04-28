using System;
using System.Collections.Generic;

namespace Logic
{
    public class Container
    {
        public readonly bool valuable;
        public readonly bool cooled;
        public readonly int weight;


        public Container(bool valuable, bool cooled, int weight)
        {
            this.valuable = valuable;
            this.cooled = cooled;
            weight = weight < 4000 ? 4000 : weight;
            weight = weight > 30000 ? 30000 : weight;
            this.weight = weight;
        }

        public override string ToString()
        {
            return String.Format("Load: {0}{1}{2}{3}", weight, (valuable ? " VALUABLE" : ""), (cooled ? " COOLED" : ""), Environment.NewLine);
        }
    }
}
