using System;
using DB;

namespace Logic
{
    public class Product

    {
        public int id { get; set; }
        public string titel { get; set; }
        public string omschrijving { get; set; }
        public decimal prijs { get; set; }

        public Product(ProductDTO product)
        {
            id = product.Id;
            titel = product.Titel;
            omschrijving = product.Omschrijving;
            prijs = product.Prijs;
        }
        public Product()
        {

        }


        public ProductDTO ToDTO()
        {
            return new ProductDTO
            {
                Titel = titel,
                Id = id,
                Omschrijving = omschrijving ?? "",
                Prijs = prijs
            };
        }
    }
}
