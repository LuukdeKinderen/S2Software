using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public static class OrderContainer
    {
        //public static List<Categorie> GetAll()
        //{
        //    CategorieDAL DAL = new CategorieDAL();
        //    List<CategorieDTO> DTOs =  DAL.GetAll();
        //    List<Categorie> categories = new List<Categorie>();
        //    foreach (CategorieDTO DTO in DTOs)
        //    {
        //        categories.Add(new Categorie(DTO));
        //    }
        //    return categories;
        //}
        public static Order GetByID(int id)
        {
            OrderDAL DAL = new OrderDAL();
            OrderDTO DTO = DAL.GetById(id);
            Order order = new Order(DTO);
            return order;
        }

        //public static void Delete(int id)
        //{
        //    CategorieDAL DAL = new CategorieDAL();
        //    DAL.Delete(id);
        //}

        //public static void Insert(Categorie categorie)
        //{
        //    CategorieDAL DAL = new CategorieDAL();
        //    CategorieDTO DTO = categorie.ToDTO();
        //    DAL.Insert(DTO);
        //}

        //public static void Update(Categorie categorie)
        //{
        //    CategorieDAL DAL = new CategorieDAL();
        //    CategorieDTO DTO = categorie.ToDTO();
        //    DAL.Update(DTO);
        //}
    }
}
