using System;
using System.Collections.Generic;
using System.Text;
using DB;
using Logic.order;

namespace Logic
{
    public class Order
    {
        public int id { get; set; }
        public bool betaald { get; set; }
        public int klantId { get; set; }
        public DateTime date { get; set; }


        public Order()
        {
            betaald = false;
            date = DateTime.Now;
        }

        public Order(OrderDTO DTO)
        {
            id = DTO.Id;
            betaald = DTO.Betaald;
            klantId = DTO.KlantId;
            date = DTO.Date;
        }

        public List<OrderRegel> GetOrderRegels()
        {

            OrderDAL Dal = new OrderDAL();
            List<OrderRegelDTO> DTOs = Dal.GetOrderRegels(id);

            List<OrderRegel> orderRegels = new List<OrderRegel>();
            foreach (OrderRegelDTO DTO in DTOs)
            {
                int aantal = DTO.Aantal;

                Product product = ProductContainer.GetByID(DTO.ProductId);

                OrderRegel orderRegel = new OrderRegel(aantal, product);
                orderRegels.Add(orderRegel);
            }


            return orderRegels;
        }

        public Klant GetKlant()
        {
            if (klantId >= 0)
            {
                Klant klant = KlantContainer.GetByID(klantId);
                return klant;
            }
            else
            {
                return null;
            }
        }

        public void AddOrderRegel(int aantal, Product product)
        {
            OrderRegel orderRegel = new OrderRegel(aantal, product);
            OrderRegelDTO DTO = orderRegel.ToDTO();

            OrderDAL DAL = new OrderDAL();
            DAL.AddOrderRegel(id, DTO);
        }
    }
}
