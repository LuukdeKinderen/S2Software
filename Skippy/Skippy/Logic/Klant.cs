using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public class Klant
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string factuurAdres { get; set; }
        public string bezorgAdres { get; set; }

        public Klant()
        {

        }

        public Klant(KlantDTO DTO)
        {
            id = DTO.Id;
            naam = DTO.Naam;
            factuurAdres = DTO.FactuurAdres;
            bezorgAdres = DTO.BezorgAdres;
        }

        public KlantDTO ToDTO()
        {
            return new KlantDTO
            {
                Id = id,
                Naam = naam,
                FactuurAdres = factuurAdres,
                BezorgAdres = bezorgAdres
                
            };
        }

        public List<Order> GetOrders()
        {
            KlantDAL DAL = new KlantDAL();
            List<OrderDTO> DTOs = DAL.GetOrders(id);
            List<Order> orders = new List<Order>();

            foreach (OrderDTO DTO in DTOs)
            {
                orders.Add(new Order(DTO));
            }
            return orders;
        }

        //public List<Product> GetProducts()
        //{
        //    CategorieDAL DAL = new CategorieDAL();
        //    List<ProductDTO> DTOs = DAL.GetProductsInCategorie(id);
        //    List<Product> products = new List<Product>();
        //    foreach (ProductDTO DTO in DTOs)
        //    {
        //        Product newProduct = new Product(DTO);
        //        products.Add(newProduct);
        //    }
        //    return products;
        //}

        //public List<Product> GetProductsNotInCategorie()
        //{
        //    CategorieDAL DAL = new CategorieDAL();
        //    List<ProductDTO> DTOs = DAL.GetProductsNotInCategorie(id);
        //    List<Product> products = new List<Product>();
        //    foreach (ProductDTO DTO in DTOs)
        //    {
        //        Product newProduct = new Product(DTO);
        //        products.Add(newProduct);                
        //    }
        //    return products;
        //}

        //public void AddProduct(int productId)
        //{
        //    CategorieDAL DAL = new CategorieDAL();
        //    DAL.AddProduct(id, productId);
        //}

        //public void RemoveProduct(int productId)
        //{
            
        //    CategorieDAL DAL = new CategorieDAL();
        //    DAL.RemoveProduct(id, productId);
        //}



    }
}
