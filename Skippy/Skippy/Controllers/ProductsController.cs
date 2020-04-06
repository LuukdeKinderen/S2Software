using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;

namespace Skippy.Controllers
{
    public class ProductsController : Controller
    {

        public IActionResult Index()
        {
            ProductContainer container = new ProductContainer();
            return View(container.GetProducts());
        }
        public IActionResult Product(int id)
        {
            ProductContainer container = new ProductContainer();
            Product product = container.GetByID(id);
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
           
            product.Update();
            return View("Product",product);
        }
    }
}