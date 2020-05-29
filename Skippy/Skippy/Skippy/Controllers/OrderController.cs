using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Skippy.Controllers
{


    public class OrderController : Controller
    {
        OrderContainer orderContainer = new OrderContainer();
        ProductContainer productContainer = new ProductContainer();
        CategorieContainer categorieContainer = new CategorieContainer();

        public IActionResult Index()
        {
            return View(orderContainer.GetAll());
        }

        public IActionResult Order(int id)
        {
            Order order = orderContainer.GetByID(id);
            return View(order);
        }

        public IActionResult EditOrder(int id)
        {
            SetSessionOrderId(id);
            List<Categorie> categories = categorieContainer.GetAll();

            return RedirectToAction("Index", "Categories", categories);
        }

        public IActionResult AddProduct(int aantal, int productId)
        {
            int orderId = GetSessionOrderId();

            Order order = orderContainer.GetByID(orderId);
            Product product = productContainer.GetByID(productId);
            OrderRegel orderRegel = new OrderRegel(aantal, product);

            order.EditOrderRegel(orderRegel);

            return RedirectToAction("Product", "Products", product);
        }

        public IActionResult AddKlant(int klantId)
        {
            int orderId = GetSessionOrderId();

            Order order = orderContainer.GetByID(orderId);
            order.AddKlant(klantId);


            List<Categorie> categories = categorieContainer.GetAll();

            return RedirectToAction("Index", "Categories", categories);
        }

        public IActionResult OpRekening(int id)
        {
            Order order = orderContainer.GetByID(id);
            order.OpRekening();
            ClearSessionOrderId();

            return RedirectToAction("Order", order);
        }


        public IActionResult Complete(int id)
        {
            Order order = orderContainer.GetByID(id);
            order.Complete();
            ClearSessionOrderId();

            return RedirectToAction("Order", order);
        }

        public IActionResult Delete(int id)
        {
            orderContainer.Delete(id);
            ClearSessionOrderId();

            return RedirectToAction("Index", orderContainer.GetAll());
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