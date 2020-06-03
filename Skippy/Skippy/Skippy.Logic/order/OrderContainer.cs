using System.Collections.Generic;
using Skippy.Factory;
using Skippy.Interface;

namespace Skippy.Logic
{
    public class OrderContainer
    {

        public Order GetByID(int id)
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();           
            DtoOrder DTO = orderDAL.GetById(id);
            Order order = new Order(DTO);

            //When order does not excist Create a new order
            if (DTO.Id == 0)
            {
                order = GetByID(CreateNew());
            }

            return order;
        }

        public List<Order> GetAll()
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            List<DtoOrder> DTOs = orderDAL.GetAll();
            List<Order> orders = new List<Order>();
            foreach (DtoOrder DTO in DTOs)
            {
                Order order = new Order(DTO);
                orders.Add(order);
            }
            return orders;
        }

        public int CreateNew()
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            int id = orderDAL.Insert();
            return id;

        }

        public void Delete(int id)
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            orderDAL.Delete(id);
        }

    }
}
