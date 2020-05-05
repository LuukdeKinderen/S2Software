using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public static class CategorieContainer
    {
        public static List<Categorie> GetAll()
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
        public static Categorie GetByID(int id)
        {
            CategorieDAL DAL = new CategorieDAL();
            CategorieDTO DTO = DAL.GetById(id);
            Categorie categorie = new Categorie(DTO);
            return categorie;
        }

        public static void Delete(int id)
        {
            CategorieDAL DAL = new CategorieDAL();
            DAL.Delete(id);
        }

        public static void Insert(Categorie categorie)
        {
            CategorieDAL DAL = new CategorieDAL();
            CategorieDTO DTO = categorie.ToDTO();
            DAL.Insert(DTO);
        }

        public static void Update(Categorie categorie)
        {
            CategorieDAL DAL = new CategorieDAL();
            CategorieDTO DTO = categorie.ToDTO();
            DAL.Update(DTO);
        }
    }
}
