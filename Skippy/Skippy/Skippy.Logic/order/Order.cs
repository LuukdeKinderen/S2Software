using System;
using System.Collections.Generic;
using System.Linq;
using Skippy.Factory;
using Skippy.Interface;


namespace Skippy.Logic
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

        public Order(DtoOrder DTO)
        {
            id = DTO.Id;
            betaald = DTO.Betaald;
            klantId = DTO.KlantId;
            date = DTO.Date;
        }

        public List<OrderRegel> GetOrderRegels()
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();

            List<DtoOrderRegel> DTOs = orderDAL.GetOrderRegels(id);

            List<OrderRegel> orderRegels = new List<OrderRegel>();
            ProductContainer productContainer = new ProductContainer();
            foreach (DtoOrderRegel DTO in DTOs)
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
            DtoOrderRegel DTO = orderRegel.ToDTO();

            IDalOrder orderDAL = DalFactory.CreateOrderDal();

            if (newProduct && aantal > 0)
            {
                orderDAL.AddOrderRegel(id, DTO);
            }
            else if (!newProduct && aantal > 0)
            {
                orderDAL.UpdateOrderRegel(id, DTO);
            }
            else if (!newProduct && aantal == 0)
            {
                orderDAL.DeleteOrderRegel(id, DTO);
            }
        }

        public decimal TotaalPrijs()
        {
            return GetOrderRegels().Sum(regel => regel.Prijs());
        }

        public void Complete()
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            orderDAL.SetBetaalStatus(true, id);
        }

        public void OpRekening()
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            orderDAL.SetBetaalStatus(false, id);
        }

        public void Delete()
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            orderDAL.Delete(id);
        }

        public void AddKlant(int klantId)
        {
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            orderDAL.AddKlant(id, klantId);
        }

    }
}
