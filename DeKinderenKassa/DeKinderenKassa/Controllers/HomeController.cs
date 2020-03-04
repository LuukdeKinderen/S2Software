using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeKinderenKassa.Models;

namespace DeKinderenKassa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page test.";
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            return View();
        }
    }
}