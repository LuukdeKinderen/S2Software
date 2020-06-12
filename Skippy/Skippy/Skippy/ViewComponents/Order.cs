using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skippy.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skippy.Models;

namespace Skippy.ViewComponents
{
    [ViewComponent]
    public class Order : ViewComponent
    {
        OrderContainer orderContainer = new OrderContainer();
        public IViewComponentResult Invoke()
        {
            int id = GetOrderId();
            Logic.Order order = orderContainer.GetByID(id);
            OrderViewModel orderView = ModelFactory.OrderViewModel(order);
            return View(orderView);
        }

        private int GetOrderId()
        {
            int? orderId = HttpContext.Session.GetInt32("order");
            if (!orderId.HasValue)
            {
                int id = orderContainer.CreateNew();
                HttpContext.Session.SetInt32("order", id);
            }
            return HttpContext.Session.GetInt32("order").Value;
        }
    }
}
