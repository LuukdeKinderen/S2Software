using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skippy.Logic;

namespace Skippy.Models
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public string betaalStatus { get; set; }
        public DateTime date { get; set; }
        public int? klantId { get; set; }
        public string klantNaam { get;set; }
        public string klantBezorgAdres { get; set; }
        public string klantFactuurAdres { get; set; }

        public List<OrderRegelViewModel> orderRegels { get; set; }
        public decimal totaalPrijs { get; set; }

        public OrderViewModel()
        {

        }

    }
}
