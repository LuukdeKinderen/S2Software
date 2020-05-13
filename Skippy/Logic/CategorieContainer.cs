using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public class CategorieContainer
    {
        public List<Categorie> GetAll()
        {
            CategorieDAL DAL = new CategorieDAL();
            List<CategorieDTO> DTOs =  DAL.GetAll();
            List<Categorie> categories = new List<Categorie>();
            foreach (CategorieDTO DTO in DTOs)
            {
                categories.Add(new Categorie(DTO));
            }
            return categories;
        }
        public Categorie GetByID(int id)
        {
            CategorieDAL DAL = new CategorieDAL();
            CategorieDTO DTO = DAL.GetById(id);
            Categorie categorie = new Categorie(DTO);
            return categorie;
        }

        public void Delete(int id)
        {
            CategorieDAL DAL = new CategorieDAL();
            DAL.Delete(id);
        }

        public void Insert(Categorie categorie)
        {
            CategorieDAL DAL = new CategorieDAL();
            CategorieDTO DTO = categorie.ToDTO();
            DAL.Insert(DTO);
        }

        public void Update(Categorie categorie)
        {
            CategorieDAL DAL = new CategorieDAL();
            CategorieDTO DTO = categorie.ToDTO();
            DAL.Update(DTO);
        }
    }
}
