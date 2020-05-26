using System.Collections.Generic;
using Skippy.Factory;
using Skippy.Interface;

namespace Skippy.Logic
{
    public class CategorieContainer
    {
        public List<Categorie> GetAll()
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            List<DtoCategorie> DTOs =  DAL.GetAll();
            List<Categorie> categories = new List<Categorie>();
            foreach (DtoCategorie DTO in DTOs)
            {
                categories.Add(new Categorie(DTO));
            }
            return categories;
        }
        public Categorie GetByID(int id)
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            DtoCategorie DTO = DAL.GetById(id);
            Categorie categorie = new Categorie(DTO);
            return categorie;
        }

        public void Delete(int id)
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            DAL.Delete(id);
        }

        public void Insert(Categorie categorie)
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            DtoCategorie DTO = categorie.ToDTO();
            DAL.Insert(DTO);
        }

        public void Update(Categorie categorie)
        {
            IDalCategorie DAL = DalFactory.CreateCategorieDal();
            DtoCategorie DTO = categorie.ToDTO();
            DAL.Update(DTO);
        }
    }
}
