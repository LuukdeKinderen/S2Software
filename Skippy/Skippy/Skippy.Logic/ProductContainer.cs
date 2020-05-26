using System.Collections.Generic;
using Skippy.Interface;
using Skippy.Factory;

namespace Skippy.Logic
{
    public class ProductContainer
    {
        public List<Product> GetAll()
        {
            IDalProduct DAL = DalFactory.CreateProductDal();
            List<DtoProduct> DtoProducts =  DAL.GetAll();
            List<Product> products = new List<Product>();
            foreach (DtoProduct DtoProduct in DtoProducts)
            {
                products.Add(new Product(DtoProduct));
            }
            return products;
        }
        public Product GetByID(int id)
        {
            IDalProduct DAL = DalFactory.CreateProductDal();
            DtoProduct DtoProduct = DAL.GetById(id);
            Product product = new Product(DtoProduct);
            return product;
        }

        public void Delete(int id)
        {
            IDalProduct DAL = DalFactory.CreateProductDal();
            DAL.Delete(id);
        }

        public void Insert(Product product)
        {
            IDalProduct DAL = DalFactory.CreateProductDal();
            DtoProduct DTO = product.ToDTO();
            DAL.Insert(DTO);
        }

        public void Update(Product product)
        {
            IDalProduct DAL = DalFactory.CreateProductDal();
            DtoProduct DTO = product.ToDTO();
            DAL.Update(DTO);
        }
    }
}
