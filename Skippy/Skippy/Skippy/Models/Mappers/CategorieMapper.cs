using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skippy.Logic;

namespace Skippy.Models.Mappers
{
    public static class CategorieMapper
    {
        public static List<CategorieViewModel> AllCategorieViewModels()
        {
            CategorieContainer categorieContainer = new CategorieContainer();

            List<CategorieViewModel> categorieViewModels = new List<CategorieViewModel>();
            foreach (Categorie categorie in categorieContainer.GetAll())
            {
                CategorieViewModel categorieView = new CategorieViewModel()
                {
                    titel = categorie.titel,
                    id = categorie.id
                };
                categorieViewModels.Add(categorieView);
            }
            return categorieViewModels;

        }
        public static CategorieViewModel CategorieEditViewModel(Categorie categorie)
        {
            CategorieViewModel categorieView = new CategorieViewModel()
            {
                titel = categorie.titel,
                id = categorie.id,
            };

            categorieView.products = new List<ProductViewModel>();
            foreach (Product product in categorie.GetProducts())
            {
                ProductViewModel prodcutView = new ProductViewModel()
                {
                    id = product.id,
                    titel = product.titel
                };
                categorieView.products.Add(prodcutView);
            }

            categorieView.productsNotInCategorie = new List<ProductViewModel>();
            foreach (Product product in categorie.GetProductsNotInCategorie())
            {
                ProductViewModel prodcutView = new ProductViewModel()
                {
                    id = product.id,
                    titel = product.titel
                };
                categorieView.productsNotInCategorie.Add(prodcutView);
            }

            return categorieView;
        }
        public static CategorieViewModel CategorieViewModel(Categorie categorie)
        {
            CategorieViewModel categorieView = new CategorieViewModel()
            {
                titel = categorie.titel,
                id = categorie.id,
            };

            categorieView.products = new List<ProductViewModel>();
            foreach (Product product in categorie.GetProducts())
            {
                ProductViewModel prodcutView = new ProductViewModel()
                {
                    id = product.id,
                    titel = product.titel
                };
                categorieView.products.Add(prodcutView);
            }
            return categorieView;
        }
        public static Categorie Categorie(CategorieViewModel categorieView)
        {
            return new Categorie()
            {
                id = categorieView.id,
                titel = categorieView.titel
            };
        }
    }
}
