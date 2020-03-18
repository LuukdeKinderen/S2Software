using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;

namespace Skippy.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>() { new Product(), new Product() };
            
            return View(products);
        }
        public IActionResult Product(int? id)
        {
            List<Product> products = new List<Product>() { new Product(), new Product() };
            if (id != null && id > -1 && id < products.Count)
            {
                return View(products[(int)id]);
            }
            else return new ContentResult { Content = "error" };
        }
    }
}