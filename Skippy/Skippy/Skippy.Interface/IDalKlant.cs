using System.Collections.Generic;

namespace Skippy.Interface
{
    public interface IDalKlant
    {
        public void Insert(DtoKlant klant);

        public List<DtoKlant> GetAll();

        public DtoKlant GetById(int id);

        public void Update(DtoKlant product);

        public List<DtoOrder> GetOrders(int klantId);
    }
}
