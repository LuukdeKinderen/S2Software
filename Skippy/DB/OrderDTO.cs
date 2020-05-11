using System;
using System.Collections.Generic;
using System.Text;


namespace DB
{
    public struct OrderDTO
    {
        public int Id { get; set; }
        public bool Betaald { get; set; }
        public int KlantId { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return String.Format("id: {0}, date: {3}, betaal status: {1}, klant id: {2}" ,Id,Betaald,KlantId , Date);
        }
    }


}
