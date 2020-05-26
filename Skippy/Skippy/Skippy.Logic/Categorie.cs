using System.Collections.Generic;
using Skippy.Factory;
using Skippy.Interface;

namespace Skippy.Logic
{
    public class Categorie
    {
        public int id { get; set; }
        public string titel { get; set; }


        public Categorie()
        {

        }

        public Categorie(DtoCategorie categorieDTO)
        {
            id = categorieDTO.Id;
            titel = categorieDTO.Titel;
        }
        public DtoCategorie ToDTO()
        {
            return new DtoCategorie
            {
                Titel = titel,
                Id = id
            };
        }

        public List<Product> GetProducts()
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            List<DtoProduct> DTOs = DAL.GetProductsInCategorie(id);
            List<Product> products = new List<Product>();
            foreach (DtoProduct DTO in DTOs)
            {
                Product newProduct = new Product(DTO);
                products.Add(newProduct);
            }
            return products;
        }

        public List<Product> GetProductsNotInCategorie()
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            List<DtoProduct> DTOs = DAL.GetProductsNotInCategorie(id);
            List<Product> products = new List<Product>();
            foreach (DtoProduct DTO in DTOs)
            {
                Product newProduct = new Product(DTO);
                products.Add(newProduct);                
            }
            return products;
        }

        public void AddProduct(int productId)
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            DAL.AddProduct(id, productId);
        }

        public void RemoveProduct(int productId)
        {

            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            DAL.RemoveProduct(id, productId);
        }



    }
}
