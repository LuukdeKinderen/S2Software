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
            ProductCollection products = new ProductCollection();
            return View(products.GetCollection(ProductCollection.Sort.Id));
        }
        public IActionResult Product(int id)
        {
            ProductCollection products = new ProductCollection();
            Product prod = products.GetProduct(id);
            if (prod != null)
            {
                return View(prod);
            }
            else return new ContentResult { Content = "error" };
        }
    }
}