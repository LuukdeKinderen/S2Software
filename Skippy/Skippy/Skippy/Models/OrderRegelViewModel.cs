using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skippy.Models
{
    public class OrderRegelViewModel
    {
        public int aantal { get; set; }
        public int productId { get; set; }
        public string productTitel { get; set; }
        public string productPrijs { get; set; }
        public string totaalPrijs { get; set; }

        public OrderRegelViewModel()
        {

        }

    }
}
