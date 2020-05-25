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


        public Categorie()
        {

        }

        public Categorie(CategorieDTO categorieDTO)
        {
            id = categorieDTO.Id;
            titel = categorieDTO.Titel;
        }
        public CategorieDTO ToDTO()
        {
            return new CategorieDTO
            {
                Titel = titel,
                Id = id
            };
        }

        public List<Product> GetProducts()
        {
            CategorieDAL DAL = new CategorieDAL();
            List<ProductDTO> DTOs = DAL.GetProductsInCategorie(id);
            List<Product> products = new List<Product>();
            foreach (ProductDTO DTO in DTOs)
            {
                Product newProduct = new Product(DTO);
                products.Add(newProduct);
            }
            return products;
        }

        public List<Product> GetProductsNotInCategorie()
        {
            CategorieDAL DAL = new CategorieDAL();
            List<ProductDTO> DTOs = DAL.GetProductsNotInCategorie(id);
            List<Product> products = new List<Product>();
            foreach (ProductDTO DTO in DTOs)
            {
                Product newProduct = new Product(DTO);
                products.Add(newProduct);                
            }
            return products;
        }

        public void AddProduct(int productId)
        {
            CategorieDAL DAL = new CategorieDAL();
            DAL.AddProduct(id, productId);
        }

        public void RemoveProduct(int productId)
        {
            
            CategorieDAL DAL = new CategorieDAL();
            DAL.RemoveProduct(id, productId);
        }



    }
}
