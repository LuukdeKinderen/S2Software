using System;
using System.Collections.Generic;
using System.Text;


namespace DB
{
    public struct ProductDTO
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public decimal Prijs { get; set; }
        public string Omschrijving { get; set; }

        public override string ToString()
        {
            return String.Format("id: {0}, titel: {1}, Prijs: {2}, Omsch: {3}" ,Id,Titel,Prijs,Omschrijving);
        }
    }


}
