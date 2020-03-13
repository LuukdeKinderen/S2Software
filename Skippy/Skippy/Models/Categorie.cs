using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skippy.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Naam moet tussen de 3 en 100 letters bevatten")]
        public string Naam { get; set; }

        public virtual ICollection<Categorie> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
