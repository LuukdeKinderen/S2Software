using System;
using System.Collections.Generic;
using System.Linq;
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
            ProductContainer productContainer = new ProductContainer();
            foreach (OrderRegelDTO DTO in DTOs)
            {
                int aantal = DTO.Aantal;

                Product product = productContainer.GetByID(DTO.ProductId);

                OrderRegel orderRegel = new OrderRegel(aantal, product);
                orderRegels.Add(orderRegel);
            }


            return orderRegels;
        }

        public Klant GetKlant()
        {
            if (klantId >= 0)
            {
                KlantContainer klantContainer = new KlantContainer();
                Klant klant = klantContainer.GetByID(klantId);
                return klant;
            }
            else
            {
                return null;
            }
        }

        public void AddProduct(int aantal, Product product)
        {

            bool newProduct = true;
            foreach (OrderRegel regel in GetOrderRegels())
            {
                if (regel.product.id == product.id)
                {
                    newProduct = false;
                }
            }


            OrderRegel orderRegel = new OrderRegel(aantal, product);
            OrderRegelDTO DTO = orderRegel.ToDTO();


            OrderDAL DAL = new OrderDAL();
            if (newProduct && aantal > 0)
            {
                DAL.AddOrderRegel(id, DTO);
            }
            else if (!newProduct && aantal > 0)
            {
                DAL.UpdateOrderRegel(id, DTO);
            }
            else if (!newProduct && aantal == 0)
            {
                DAL.DeleteOrderRegel(id, DTO);
            }
        }

        public decimal TotaalPrijs()
        {
            return GetOrderRegels().Sum(regel => regel.Prijs());
        }

        public void Complete()
        {
            OrderDAL DAL = new OrderDAL();
            DAL.Complete(id);
        }

        public void OpRekening()
        {
            OrderDAL DAL = new OrderDAL();
            DAL.OpRekening(id);
        }

        public void Delete()
        {
            OrderDAL DAL = new OrderDAL();
            DAL.Delete(id);
        }

        public void AddKlant(int klantId)
        {
            OrderDAL DAL = new OrderDAL();
            DAL.AddKlant(id , klantId);
        }

    }
}
