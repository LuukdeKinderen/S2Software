using System;
using System.Collections.Generic;
using System.Text;
using DB;

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

        }

        public Order(OrderDTO DTO)
        {
            id = DTO.Id;
            betaald = DTO.Betaald;
            klantId = DTO.KlantId;
            date = DTO.Date;
        }

    }
}
