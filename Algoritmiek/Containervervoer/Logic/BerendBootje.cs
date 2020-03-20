using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{
    public class BerendBootje
    {
        public List<Container> containers { get; private set; }
        public List<Ship> ships { get; private set; }
        public BerendBootje()
        {
            Random r = new Random();
            containers = new List<Container>();
            for (int c = 0; c < 10; c++)
            {
                containers.Add(new Container(r));
            }


            ships = new List<Ship>();
            for (int i = 0; i < 2; i++)
            {
                ships.Add(new Ship(ShipFormat.small));
            }
        }

        public void ordenContainers()
        {


        }


        public override string ToString()
        {
            string str = "";
            foreach (Container container in containers)
            {
                str += container.ToString();
            }
            return str;
        }

        public List<List<string>[,]> ShipStringList(/*List<Ship> ships*/)
        {
            List<List<string>[,]> constStr = new List<List<string>[,]>(3);
            for (int s = 0; s < ships.Count; s++)
            {
                constStr.Add(ships[s].GetStringList());
                //constStr.Add(new List<string>[2, 4]);
                //for (int c = 0; c < constStr[s].GetLength(0); c++)
                //{
                //    for (int r = 0; r < constStr[s].GetLength(1); r++)
                //    {
                //        constStr[s][c, r] = new List<string>();
                //        for (int i = 0; i < 6; i++)
                //        {
                //            Container cnt = new Container(rnd);
                //            constStr[s][c, r].Add(cnt.ToString());
                //        }
                //    }

                //}
            }
            return constStr;
        }
    }
}
