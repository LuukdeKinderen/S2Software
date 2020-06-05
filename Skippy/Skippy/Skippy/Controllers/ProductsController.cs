using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Skippy.Controllers
{
    public class ProductsController : Controller
    {
        ProductContainer productContainer = new ProductContainer();

        public IActionResult Index()
        {
            return View(productContainer.GetAll());
        }
        public IActionResult Product(int id)
        {
            Product product = productContainer.GetByID(id);
            return View(product);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productContainer.AddNew(product);
            return RedirectToAction("Index", productContainer.GetAll());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(productContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            product.Update();
            return RedirectToAction("Product", productContainer.GetByID(product.id));
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            productContainer.Delete(id);
            return RedirectToAction("Index", productContainer.GetAll());
        }
    }
}