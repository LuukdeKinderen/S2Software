using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skippy.Logic;

namespace Skippy.Models.Mappers
{
    public static class OrderMapper
    {
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

        public static Order Order(OrderViewModel orderView)
        {
            return new Order()
            {
                id = orderView.id,
                date = orderView.date,
                betaald = orderView.betaalStatus == "betaald",
                klantId = orderView.klantId
            };
        }

    }
}
