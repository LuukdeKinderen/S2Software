using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skippy.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Naam moet tussen de 3 en 100 letters bevatten")]
        public string Naam { get; set; }

        [StringLength(500, ErrorMessage = "Omschrijving mag maximaal 500 tekens bevatten")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht")]
        //[Range(0.01, 10000.00, ErrorMessage = "Prijs moet tussen de 0,01 en 10.000 zijn")]
        [DataType(DataType.Currency)]
        public decimal Prijs { get; set; }
    }
}
