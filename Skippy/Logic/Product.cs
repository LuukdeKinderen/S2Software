using System;

namespace Logic
{
    public class Product
        
    {
        public int id { get; private set; }
        public string titel { get; private set; }
        public string info { get; private set; }
        public double prijs { get; private set; }

        public Product(int id, string titel, string info, double prijs)
        {
            this.id = id;
            this.titel = titel;
            this.info = info;
            this.prijs = prijs;
        }


    }
}
