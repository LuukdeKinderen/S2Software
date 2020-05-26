using System;
using System.Collections.Generic;
using System.Text;

namespace Skippy.Interface
{
    public interface IDalCategorie
    {
        public void Insert(DtoCategorie categorie);

        public List<DtoCategorie> GetAll();

        public DtoCategorie GetById(int id);

        public void Delete(int id);

        public void Update(DtoCategorie categorie);


        public List<DtoProduct> GetProductsNotInCategorie(int categorieId);
        public List<DtoProduct> GetProductsInCategorie(int categorieId);

        public void AddProduct(int categorieId, int productId);

        public void RemoveProduct(int categorieId, int productId);

    }
}
