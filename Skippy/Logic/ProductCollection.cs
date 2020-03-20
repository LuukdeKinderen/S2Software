using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ProductCollection
    {
        private List<Product> products = new List<Product>();
        public ProductCollection()
        {
            products.Add(new Product(1, "Gemengd graan", "Snoep voor de kip", 9.95));
            products.Add(new Product(5, "Legkorrel", "Basiskorrel voor de kip, de kip mag hier ombeperkt van krijgen", 10.2));
            products.Add(new Product(7, "Caro Croc 22/8", "Low energy hondenbrok kip en rijst", 31.5));
            products.Add(new Product(8, "Caro Corc 16/10", "Senior sensitive hondenbrok lam en rijst", 32.9));
            products.Add(new Product(42, "Huismerk Krokant", "Luchtige krokante brok", 21.95));
            products.Add(new Product(43, "Huismerk geperst", "Geperste harde brok", 22.95));
            products.Add(new Product(99, "Beyers kweek", "Duivenvoer kweek mengeling", 20.95));
        }

        public Product GetProduct(int id)
        {
            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    return product;
                }
            }
            return null;
        }
        public enum Sort
        {
            Id,
            Alphabetic
        }
        public List<Product> GetCollection(Sort sort)
        {
            switch (sort)
            {
                case Sort.Id:
                    products.Sort(new IdSort());
                    return products;
                case Sort.Alphabetic:
                    products.Sort(new AlphabetSort());
                    return products;
                default:
                    return products;
            }
        }
        private class AlphabetSort : Comparer<Product>
        {
            // Compares by Length, Height, and Width.
            public override int Compare(Product x, Product y)
            {
                return x.titel.CompareTo(y.titel);
            }
        }
        private class IdSort : Comparer<Product>
        {
            // Compares by Length, Height, and Width.
            public override int Compare(Product x, Product y)
            {
                return x.id.CompareTo(y.id);
            }
        }

    }
}
