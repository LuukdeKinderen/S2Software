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
        public int? klantId { get; set; }
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
            if (DTO.KlantId.HasValue)
            {
                klantId = DTO.KlantId.Value;
            }
            date = DTO.Date;
        }

        public DtoOrder ToDTO()
        {
            return new DtoOrder
            {
                Id = id,
                Betaald = betaald,
                KlantId = klantId,
                Date = date
            };
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

            if (klantId.HasValue)
            {
                KlantContainer klantContainer = new KlantContainer();
                Klant klant = klantContainer.GetByID(klantId.Value);
                return klant;
            }
            else
            {
                return null;
            }
        }

        public void EditOrderRegel(OrderRegel orderRegel)
        {

            bool newProduct = true;
            foreach (OrderRegel regel in GetOrderRegels())
            {
                if (regel.product.id == orderRegel.product.id)
                {
                    newProduct = false;
                }
            }


            
            DtoOrderRegel DTO = orderRegel.ToDTO();

            IDalOrder orderDAL = DalFactory.CreateOrderDal();

            if (newProduct && orderRegel.aantal > 0)
            {
                orderDAL.AddOrderRegel(id, DTO);
            }
            else if (!newProduct && orderRegel.aantal > 0)
            {
                orderDAL.UpdateOrderRegel(id, DTO);
            }
            else if (!newProduct && orderRegel.aantal == 0)
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
            betaald = true;
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            orderDAL.Update(this.ToDTO());
        }

        public void OpRekening()
        {
            if (klantId >= 0)
            {
                betaald = false;
                IDalOrder orderDAL = DalFactory.CreateOrderDal();
                orderDAL.Update(this.ToDTO());
            }
        }


        public void AddKlant(int klantId)
        {
            this.klantId = klantId;
            IDalOrder orderDAL = DalFactory.CreateOrderDal();
            orderDAL.Update(this.ToDTO());
        }

    }
}
