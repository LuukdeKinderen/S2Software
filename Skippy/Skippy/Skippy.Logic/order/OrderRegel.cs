using Skippy.Interface;

namespace Skippy.Logic
{
    public class OrderRegel
    {
        public readonly int aantal; 
        public readonly Product product;

        public OrderRegel(int aantal, Product product)
        {
            this.aantal = aantal;
            this.product = product;
        }

        public DtoOrderRegel ToDTO()
        {
            return new DtoOrderRegel
            {
                ProductId = product.id,
                Aantal = aantal
            };
        }

        public decimal Prijs()
        {
            return aantal * product.prijs;
        }
    }
}
