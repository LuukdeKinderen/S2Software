using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skippy.Models
{
    public class KlantViewModel
    {
        public string naam { get; set; }
        public int id { get; set; }
        public string bezorgAdres { get; set; }
        public string factuurAdres { get; set; }
        public List<OrderViewModel> orders { get; set; }


        public KlantViewModel()
        {

        }

    }
}
