using System.Collections.Generic;
using Skippy.Interface;
using Skippy.Factory;

namespace Skippy.Logic
{
    public class KlantContainer
    {
        public List<Klant> GetAll()
        {
            IDalKlant DAL = DalFactory.CreateKlantDal();
            List<DtoKlant> DTOs = DAL.GetAll();
            List<Klant> klanten = new List<Klant>();
            foreach (DtoKlant DTO in DTOs)
            {
                klanten.Add(new Klant(DTO));
            }
            return klanten;
        }
        public Klant GetByID(int id)
        {
            IDalKlant DAL = DalFactory.CreateKlantDal();
            DtoKlant DTO = DAL.GetById(id);
            Klant klant = new Klant(DTO);
            return klant;
        }


        public void Insert(Klant klant)
        {
            IDalKlant DAL = DalFactory.CreateKlantDal();
            DtoKlant DTO = klant.ToDTO();
            DAL.Insert(DTO);
        }

        public void Update(Klant klant)
        {
            IDalKlant DAL = DalFactory.CreateKlantDal();
            DtoKlant DTO = klant.ToDTO();
            DAL.Update(DTO);
        }
    }
}
