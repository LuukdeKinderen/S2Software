using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skippy.Logic;

namespace Skippy.Models.Mappers
{
    public static class ProductMapper
    {
        public static List<ProductViewModel> AllProductViewModels()
        {
            ProductContainer productContainer = new ProductContainer();

            List<ProductViewModel> productViews = new List<ProductViewModel>();
            foreach (Product product in productContainer.GetAll())
            {
                productViews.Add(ProductViewModel(product));
            }
            return productViews;
        }

        public static ProductViewModel ProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                id = product.id,
                omschrijving = product.omschrijving,
                prijs = product.prijs,
                titel = product.titel
            };
        }

        public static Product Product(ProductViewModel productView)
        {
            return new Product()
            {
                id = productView.id,
                omschrijving = productView.omschrijving,
                prijs = productView.prijs,
                titel = productView.titel
            };
        }
    }
}
