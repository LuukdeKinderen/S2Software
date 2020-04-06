using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public class ProductContainer
    {
        public List<Product> GetProducts()
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
        public Product GetByID(int id)
        {
            ProductDAL DAL = new ProductDAL();
            ProductDTO productDTO = DAL.FindById(id);
            Product product = new Product(productDTO);
            return product;
        }
    }
}
