using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    public struct CategorieDTO
    {
        public int Id { get; set; }
        public string Titel { get; set; }

        public override string ToString()
        {
            return String.Format("id: {0}, titel: {1}", Id, Titel);
        }
    }
}
