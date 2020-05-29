using System;

namespace Skippy.Interface
{
    public struct DtoOrder
    {
        public int Id { get; set; }
        public bool Betaald { get; set; }
        public int KlantId { get; set; }
        public DateTime Date { get; set; }
        
    }
}
