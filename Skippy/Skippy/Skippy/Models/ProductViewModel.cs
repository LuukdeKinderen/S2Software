using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skippy.Models
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string titel { get; set; }
        public string omschrijving { get; set; }
        public decimal prijs { get; set; }

        public ProductViewModel(Logic.Product product)
        {
            id = product.id;
            titel = product.titel;
            omschrijving = product.omschrijving;
            prijs = product.prijs;
        }
        public ProductViewModel()
        {

        }
    }
}
