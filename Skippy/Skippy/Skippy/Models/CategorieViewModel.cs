using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skippy.Models
{
    public class CategorieViewModel
    {
        public string titel { get; set; }
        public int id { get; set; }
        public List<ProductViewModel> products { get; set; }
        public List<ProductViewModel> productsNotInCategorie { get; set; }

       
        public CategorieViewModel()
        {

        }

    }
}
