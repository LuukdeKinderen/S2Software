using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public class Categorie
    {
        public int id { get; set; }
        public string titel { get; set; }

        public List<Product> Products { get; private set; }

        public Categorie()
        {

        }

        public Categorie(CategorieDTO categorieDTO)
        {
            id = categorieDTO.Id;
            titel = categorieDTO.Titel;

            Products = GetProducts();
        }
        public CategorieDTO ToDTO()
        {
            return new CategorieDTO
            {
                Titel = titel,
                Id = id
            };
        }

        private List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            CategorieDAL categorieDAL = new CategorieDAL();
            ProductDAL productDAL = new ProductDAL();

            List<int> productIds = categorieDAL.GetProductIds(id);

            foreach (int id in productIds)
            {
                ProductDTO DTO = productDAL.FindById(id);
                Product product = new Product(DTO);
                products.Add(product);
            }

            return products;
        }






    }
}
