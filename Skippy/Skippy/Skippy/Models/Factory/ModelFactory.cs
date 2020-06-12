using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skippy.Logic;

namespace Skippy.Models
{
    public static class ModelFactory
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
            foreach (Logic.Product product in categorie.GetProducts())
            {
                ProductViewModel prodcutView = new ProductViewModel()
                {
                    id = product.id,
                    titel = product.titel
                };
                categorieView.products.Add(prodcutView);
            }

            categorieView.productsNotInCategorie = new List<ProductViewModel>();
            foreach (Logic.Product product in categorie.GetProductsNotInCategorie())
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
            foreach (Logic.Product product in categorie.GetProducts())
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

        public static List<KlantViewModel> AllKlantViewModels()
        {
            KlantContainer klantcontainer = new KlantContainer();

            List<KlantViewModel> klantViews = new List<KlantViewModel>();
            foreach (Klant klant in klantcontainer.GetAll())
            {
                KlantViewModel klantView = new KlantViewModel()
                {
                    naam = klant.naam,
                    id = klant.id
                };
                klantViews.Add(klantView);
            }
            return klantViews;
        }
        public static KlantViewModel KlantViewModel(Klant klant)
        {
            KlantViewModel klantView = new KlantViewModel()
            {
                naam = klant.naam,
                id = klant.id,
                factuurAdres = klant.factuurAdres ?? null,
                bezorgAdres = klant.bezorgAdres ?? null,
                orders = null
            };
            return klantView;
        }
        public static KlantViewModel KlantViewModelWithOrders(Klant klant)
        {
            KlantViewModel klantView = ModelFactory.KlantViewModel(klant);

            klantView.orders = new List<OrderViewModel>();
            foreach (Order order in klant.GetOrders())
            {
                OrderViewModel orderView = new OrderViewModel()
                {
                    id = order.id,
                    klantId = order.klantId,
                    klantNaam = klant.naam,
                    betaalStatus = order.betaald ? "betaald" : "nog te betalen",
                    date = order.date,
                    totaalPrijs = order.TotaalPrijs(),

                };

                klantView.orders.Add(orderView);
            }
            return klantView;
        }

        public static List<OrderViewModel> AllOrderViewModels()
        {
            OrderContainer orderContainer = new OrderContainer();

            List<OrderViewModel> orderViews = new List<OrderViewModel>();
            foreach (Order order in orderContainer.GetAll())
            {
                OrderViewModel orderView = new OrderViewModel()
                {
                    id = order.id,
                    totaalPrijs = order.TotaalPrijs(),
                    betaalStatus = order.betaald ? "betaald" : "Nog te betalen",
                    klantId = order.klantId,
                    date = order.date,
                };
                if (order.klantId.HasValue)
                {
                    orderView.klantNaam = order.GetKlant().naam;
                }
                orderViews.Add(orderView);
            }
            return orderViews;
        }
        public static OrderViewModel OrderViewModel(Order order)
        {
            OrderViewModel orderView = new OrderViewModel()
            {
                id = order.id,
                totaalPrijs = order.TotaalPrijs(),
                betaalStatus = order.betaald ? "betaald" : "nog te betalen",
                klantId = order.klantId,
                date = order.date,
            };
            if (order.klantId.HasValue)
            {
                Klant klant = order.GetKlant();
                orderView.klantNaam = klant.naam;
                orderView.klantBezorgAdres = klant.bezorgAdres ?? null;
                orderView.klantFactuurAdres = klant.factuurAdres ?? null;
            }


            orderView.orderRegels = new List<OrderRegelViewModel>();
            foreach (OrderRegel orderRegel in order.GetOrderRegels())
            {
                OrderRegelViewModel orderRegelView = new OrderRegelViewModel()
                {
                    aantal = orderRegel.aantal,
                    productTitel = orderRegel.product.titel,
                    productId = orderRegel.product.id,
                    productPrijs = orderRegel.product.prijs.ToString("0.00"),
                    totaalPrijs = orderRegel.Prijs().ToString("0.00"),
                };
                orderView.orderRegels.Add(orderRegelView);
            }

            return orderView;
        }
    }
}
