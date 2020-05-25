using System;
using System.Collections.Generic;
using System.Text;


namespace DB
{
    public struct OrderRegelDTO
    {
        public int Aantal { get; set; }
        public int ProductId { get; set; }


        public override string ToString()
        {
            return String.Format("Product id: {0}, aantal: {1}", ProductId,  Aantal);
        }
    }


}
