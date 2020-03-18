using System;

namespace Logic
{
    public class Product
        
    {
        public string titel { get; private set; }
        public string info { get; private set; }
        public double prijs { get; private set; }
        public Product()
        {
            titel = "kippenvoer";
            info = "testinfo";
            prijs= 10.20;
        }


        //https://docs.microsoft.com/en-us/visualstudio/data-tools/create-a-sql-database-by-using-a-designer?view=vs-2019
    }
}
