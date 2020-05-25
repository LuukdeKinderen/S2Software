using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return View(order);
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
