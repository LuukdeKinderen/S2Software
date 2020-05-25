using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Skippy.Controllers
{
    public class KlantController : Controller
    {
        KlantContainer klantContainer = new KlantContainer();

        public IActionResult Index()
        {
            return View(klantContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Klant klant)
        {
            klantContainer.Insert(klant);
            return RedirectToAction("Index", klantContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(klantContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Klant klant)
        {
            klantContainer.Update(klant);
            int id = klant.id;
            return RedirectToAction("Klant", klantContainer.GetByID(id));
        }

        public IActionResult Klant(int id)
        {
            return View(klantContainer.GetByID(id));
        }
    }
}