using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skippy.Logic;

namespace Skippy.Models.Mappers
{
    public static class KlantMapper
    {

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
            KlantViewModel klantView = KlantViewModel(klant);

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
        public static Klant Klant(KlantViewModel klantView)
        {
            return new Klant()
            {
                id = klantView.id,
                naam = klantView.naam,
                bezorgAdres = klantView.bezorgAdres,
                factuurAdres = klantView.factuurAdres
            };
        }

    }
}
