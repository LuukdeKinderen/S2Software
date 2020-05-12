using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skippy.Models;

namespace Skippy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        private int GetOrder()
        {
            int? orderId = HttpContext.Session.GetInt32("order");
            if (orderId.HasValue)
            {
                int newid = orderId.Value + 1;
                HttpContext.Session.SetInt32("order", newid);
            }
            else
            {
                HttpContext.Session.SetInt32("order", 0);
            }
            return HttpContext.Session.GetInt32("order").Value;
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
