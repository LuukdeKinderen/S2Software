using System;
using Logic;

namespace Containervervoer
{
    class Program
    {
        static void Main(string[] args)
        {
            BerendBootje bb = new BerendBootje();

            foreach (Container cont in bb.containterCollection)
            {
                Console.WriteLine(cont.ToString());
            }
            bb.containterCollection.Orden();
            Console.WriteLine("___ordened___");
            foreach (Container cont in bb.containterCollection)
            {
                Console.WriteLine(cont.ToString());
            }

        }
    }
}
