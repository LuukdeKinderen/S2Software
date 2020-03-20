using System;
using System.Collections.Generic;

namespace Logic
{
    public class Container
    {
        public bool valuable { get; private set; }
        public bool cooled { get; private set; }
        public int load { get; private set; }



        public Container(Random r)
        {
            load = r.Next(4000,30001);
            valuable = r.Next(0, 5) < 1;
            cooled = r.Next(0, 5) < 1;
        }

        public override string ToString()
        {
            return " load: " + load.ToString() + (valuable? " VALUABLE" : "") + (cooled ? " COOLED" : "") +  Environment.NewLine;
        }
    }
}
