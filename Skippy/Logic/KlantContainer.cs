using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public class KlantContainer
    {
        public List<Klant> GetAll()
        {
            KlantDAL DAL = new KlantDAL();
            List<KlantDTO> DTOs = DAL.GetAll();
            List<Klant> klanten = new List<Klant>();
            foreach (KlantDTO DTO in DTOs)
            {
                klanten.Add(new Klant(DTO));
            }
            return klanten;
        }
        public Klant GetByID(int id)
        {
            KlantDAL DAL = new KlantDAL();
            KlantDTO DTO = DAL.GetById(id);
            Klant klant = new Klant(DTO);
            return klant;
        }


        public void Insert(Klant klant)
        {
            KlantDAL DAL = new KlantDAL();
            KlantDTO DTO = klant.ToDTO();
            DAL.Insert(DTO);
        }

        public void Update(Klant klant)
        {
            KlantDAL DAL = new KlantDAL();
            KlantDTO DTO = klant.ToDTO();
            DAL.Update(DTO);
        }
    }
}
