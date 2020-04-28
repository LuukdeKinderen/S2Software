using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using System.Diagnostics;

namespace Skippy.Controllers
{
    public class ProductsController : Controller
    {

        public IActionResult Index()
        {
            return View(ProductContainer.GetProducts());
        }
        public IActionResult Product(int id)
        {
            Product product = ProductContainer.GetByID(id);
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
            ProductContainer.Insert(product);
            return View("Product", ProductContainer.GetByID(product.id));
        }

        public IActionResult Edit(Product product)
        {
            return View(product);
        }

        public IActionResult SaveEdit(Product product)
        {
            return View("Product", product);
        }


        public IActionResult Delete(int id)
        {
            ProductContainer.DeleteByID(id);
            return View("Index", ProductContainer.GetProducts());
        }
    }
}