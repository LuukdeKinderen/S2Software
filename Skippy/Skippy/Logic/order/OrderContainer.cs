using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic
{
    public class OrderContainer
    {

        public Order GetByID(int id)
        {
            OrderDAL DAL = new OrderDAL();
            OrderDTO DTO = DAL.GetById(id);
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
            OrderDAL DAL = new OrderDAL();
            List<OrderDTO> DTOs = DAL.GetAll();
            List<Order> orders = new List<Order>();
            foreach (OrderDTO DTO in DTOs)
            {
                Order order = new Order(DTO);
                orders.Add(order);
            }

            return orders;
        }

        public int CreateNew()
        {

            OrderDAL DAL = new OrderDAL();
            int id = DAL.Insert();
            return id;

        }

    }
}
