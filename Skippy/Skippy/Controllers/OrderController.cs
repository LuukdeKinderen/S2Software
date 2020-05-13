using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Skippy.Controllers
{


    public class OrderController : Controller
    {
        OrderContainer orderContainer = new OrderContainer();
        ProductContainer productContainer = new ProductContainer();

        public IActionResult Index()
        {
            return View(orderContainer.GetAll());
        }

        public IActionResult Order(int id)
        {
            Order order = orderContainer.GetByID(id);
            return View(order);
        }

        public IActionResult Current()
        {
            int id = GetOrderId();

            Order order = orderContainer.GetByID(id);

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

        public IActionResult AddProduct(int aantal, int productId)
        {
            int orderId = GetOrderId();

            Order order = orderContainer.GetByID(orderId);
            Product product = productContainer.GetByID(productId);


            order.AddProduct(aantal, product);


            return RedirectToAction("Product", "Products", product);

        }

        public IActionResult Complete()
        {
            int orderId = GetOrderId();

            Order order = orderContainer.GetByID(orderId);
            order.Complete();
            ClearSessionOrderId();

            return RedirectToAction("Order", order);

        }

        public IActionResult Delete(int id)
        {


            Order order = orderContainer.GetByID(id);
            order.Cancel();
            ClearSessionOrderId();

            return RedirectToAction("Index", orderContainer.GetAll());
        }

        private void ClearSessionOrderId()
        {
            HttpContext.Session.Remove("order");
        }
    }
}