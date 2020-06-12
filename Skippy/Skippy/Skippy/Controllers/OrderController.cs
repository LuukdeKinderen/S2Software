using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Skippy.Models;

namespace Skippy.Controllers
{


    public class OrderController : Controller
    {
        OrderContainer orderContainer = new OrderContainer();
        ProductContainer productContainer = new ProductContainer();
        CategorieContainer categorieContainer = new CategorieContainer();

        public IActionResult Index()
        {

            List<OrderViewModel> orderViews = ModelFactory.AllOrderViewModels();
            return View(orderViews);
        }

        public IActionResult Order(int id)
        {
            Order order = orderContainer.GetByID(id);
            OrderViewModel orderModel = ModelFactory.OrderViewModel(order);
            return View(orderModel);
        }

        public IActionResult EditOrder(int id)
        {
            SetSessionOrderId(id);

            return RedirectToAction("Index", "Categories", ModelFactory.AllCategorieViewModels());
        }

        public IActionResult AddProduct(int aantal, int productId)
        {
            int orderId = GetSessionOrderId();

            Order order = orderContainer.GetByID(orderId);
            Product product = productContainer.GetByID(productId);
            OrderRegel orderRegel = new OrderRegel(aantal, product);

            order.EditOrderRegel(orderRegel);

            ProductViewModel productView = new ProductViewModel(product);

            return RedirectToAction("Product", "Products", productView);
        }

        public IActionResult AddKlant(int klantId)
        {
            int orderId = GetSessionOrderId();

            Order order = orderContainer.GetByID(orderId);
            order.AddKlant(klantId);


            return RedirectToAction("Index", "Categories", ModelFactory.AllCategorieViewModels());
        }

        public IActionResult OpRekening(int id)
        {
            Order order = orderContainer.GetByID(id);
            order.OpRekening();
            ClearSessionOrderId();

            OrderViewModel orderView = ModelFactory.OrderViewModel(order);

            return RedirectToAction("Order", orderView);
        }


        public IActionResult Complete(int id)
        {
            Order order = orderContainer.GetByID(id);
            order.Complete();
            ClearSessionOrderId();

            OrderViewModel orderView = ModelFactory.OrderViewModel(order);

            return RedirectToAction("Order", orderView);
        }

        public IActionResult Delete(int id)
        {
            orderContainer.Delete(id);

            ClearSessionOrderId();

            return RedirectToAction("Index", ModelFactory.AllOrderViewModels());
        }


        private void SetSessionOrderId(int id)
        {
            HttpContext.Session.SetInt32("order", id);
        }

        private void ClearSessionOrderId()
        {
            HttpContext.Session.Remove("order");
        }

        private int GetSessionOrderId()
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