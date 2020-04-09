using System;
using System.Collections.Generic;

namespace Logic
{
    public class Container
    {
        public bool valuable { get; private set; }
        public bool cooled { get; private set; }
        public int weight { get; private set; }



        public Container(Random r)
        {
            weight = r.Next(4000, 30001);
            valuable = r.Next(0, 15) < 1;
            cooled = r.Next(0, 25) < 1;
        }

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
            return " load: " + weight.ToString() + (valuable ? " VALUABLE" : "") + (cooled ? " COOLED" : "") + Environment.NewLine;
        }
    }
}
