using Skippy.Factory;
using Skippy.Interface;

namespace Skippy.Logic
{
    public class Product

    {
        public int id { get; set; }
        public string titel { get; set; }
        public string omschrijving { get; set; }
        public decimal prijs { get; set; }

        public Product(DtoProduct product)
        {
            id = product.Id;
            titel = product.Titel;
            omschrijving = product.Omschrijving;
            prijs = product.Prijs;
        }
        public Product()
        {

        }


        public DtoProduct ToDTO()
        {
            return new DtoProduct
            {
                Titel = titel,
                Id = id,
                Omschrijving = omschrijving ?? "",
                Prijs = prijs
            };
        }

        public void Update()
        {
            IDalProduct DAL = DalFactory.CreateProductDal();
            DAL.Update(this.ToDTO());
        }
    }
}
