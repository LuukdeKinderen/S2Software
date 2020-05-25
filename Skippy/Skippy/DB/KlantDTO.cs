using System;
using System.Collections.Generic;
using System.Text;


namespace DB
{
    public struct KlantDTO
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string FactuurAdres { get; set; }
        public string BezorgAdres { get; set; }

        public override string ToString()
        {
            return String.Format("id: {0}, naam: {1}, factuurAdres: {2}, bezorgAdres: {3}" ,Id,Naam,FactuurAdres,BezorgAdres);
        }
    }


}
