using System;
using System.Collections.Generic;
using System.Text;
using DB;

namespace Logic.order
{
    public class OrderRegel
    {
        public readonly int aantal; 
        public readonly Product product;

        public OrderRegel(int aantal, Product product)
        {
            this.aantal = aantal;
            this.product = product;
        }

        public OrderRegelDTO ToDTO()
        {
            return new OrderRegelDTO
            {
                ProductId = product.id,
                Aantal = aantal
            };
        }
    }
}
