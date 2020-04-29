using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public static class ProductContainer
    {
        public static List<Product> GetProducts()
        {
            ProductDAL DAL = new ProductDAL();
            List<ProductDTO> productDTOs =  DAL.GetAll();
            List<Product> products = new List<Product>();
            foreach (ProductDTO productDTO in productDTOs)
            {
                products.Add(new Product(productDTO));
            }
            return products;
        }
        public static Product GetByID(int id)
        {
            ProductDAL DAL = new ProductDAL();
            ProductDTO productDTO = DAL.FindById(id);
            Product product = new Product(productDTO);
            return product;
        }

        public static void DeleteByID(int id)
        {
            ProductDAL DAL = new ProductDAL();
            DAL.Delete(id);
        }

        public static void Insert(Product product)
        {
            ProductDAL DAL = new ProductDAL();
            ProductDTO DTO = product.ToDTO();
            DAL.Insert(DTO);
        }

        public static void Update(Product product)
        {
            ProductDAL DAL = new ProductDAL();
            ProductDTO DTO = product.ToDTO();
            DAL.Update(DTO);
        }
    }
}
