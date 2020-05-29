using System.Collections.Generic;
using Skippy.Interface;
using Skippy.Factory;

namespace Skippy.Logic
{
    public class Klant
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string factuurAdres { get; set; }
        public string bezorgAdres { get; set; }

        public Klant()
        {

        }

        public Klant(DtoKlant DTO)
        {
            id = DTO.Id;
            naam = DTO.Naam;
            factuurAdres = DTO.FactuurAdres;
            bezorgAdres = DTO.BezorgAdres;
        }

        public DtoKlant ToDTO()
        {
            return new DtoKlant
            {
                Id = id,
                Naam = naam,
                FactuurAdres = factuurAdres,
                BezorgAdres = bezorgAdres
                
            };
        }

        public List<Order> GetOrders()
        {
            IDalKlant DAL = DalFactory.CreateKlantDal();
            List<DtoOrder> DTOs = DAL.GetOrders(id);
            List<Order> orders = new List<Order>();

            foreach (DtoOrder DTO in DTOs)
            {
                orders.Add(new Order(DTO));
            }
            return orders;
        }

        public void Update()
        {
            IDalKlant DAL = DalFactory.CreateKlantDal();
            DAL.Update(this.ToDTO());
        }

    }
}
