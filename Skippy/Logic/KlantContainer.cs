using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public static class KlantContainer
    {
        public static List<Klant> GetAll()
        {
            KlantDAL DAL = new KlantDAL();
            List<KlantDTO> DTOs =  DAL.GetAll();
            List<Klant> klanten = new List<Klant>();
            foreach (KlantDTO DTO in DTOs)
            {
                klanten.Add(new Klant(DTO));
            }
            return klanten;
        }
        public static Klant GetByID(int id)
        {
            KlantDAL DAL = new KlantDAL();
            KlantDTO DTO = DAL.GetById(id);
            Klant klant = new Klant(DTO);
            return klant;
        }


        public static void Insert(Klant klant)
        {
            KlantDAL DAL = new KlantDAL();
            KlantDTO DTO = klant.ToDTO();
            DAL.Insert(DTO);
        }

        public static void Update(Klant klant)
        {
            KlantDAL DAL = new KlantDAL();
            KlantDTO DTO = klant.ToDTO();
            DAL.Update(DTO);
        }
    }
}
