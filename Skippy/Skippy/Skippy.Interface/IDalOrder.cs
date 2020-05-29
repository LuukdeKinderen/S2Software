using System;
using System.Collections.Generic;

namespace Skippy.Interface
{
    public interface IDalOrder
    {
        public int Insert();
        public DtoOrder GetById(int id);

        public List<DtoOrder> GetAll();

        public List<DtoOrderRegel> GetOrderRegels(int orderId);

        public void AddOrderRegel(int id, DtoOrderRegel orderRegel);
        public void UpdateOrderRegel(int id, DtoOrderRegel orderRegel);
        public void DeleteOrderRegel(int id, DtoOrderRegel orderRegel);

        public void Delete(int id);
        public void SetBetaalStatus( bool status, int id);
        public void AddKlant(int id, int klantId);
    }
}

