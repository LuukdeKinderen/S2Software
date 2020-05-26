using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using System.Diagnostics;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productContainer.Insert(product);
            return RedirectToAction("Index", productContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(productContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productContainer.Update(product);
            return RedirectToAction("Product", productContainer.GetByID(product.id));
        }

        public IActionResult Delete(int id)
        {
            productContainer.Delete(id);
            return RedirectToAction("Index", productContainer.GetAll());
        }
    }
}