using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public class ProductContainer
    {
        public List<Product> GetAll()
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
            ProductDTO productDTO = DAL.GetById(id);
            Product product = new Product(productDTO);
            return product;
        }

        public void Delete(int id)
        {
            ProductDAL DAL = new ProductDAL();
            DAL.Delete(id);
        }

        public void Insert(Product product)
        {
            ProductDAL DAL = new ProductDAL();
            ProductDTO DTO = product.ToDTO();
            DAL.Insert(DTO);
        }

        public void Update(Product product)
        {
            ProductDAL DAL = new ProductDAL();
            ProductDTO DTO = product.ToDTO();
            DAL.Update(DTO);
        }
    }
}
