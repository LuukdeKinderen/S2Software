using System;
using System.Collections.Generic;
using System.Text;


namespace DB
{
    public struct ProductDTO
    {
        public int ProductId { get; set; }
        public string Titel { get; set; }
        public decimal Prijs { get; set; }
        public string Omschrijving { get; set; }
    }
}
