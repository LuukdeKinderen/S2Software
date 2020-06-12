using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using Skippy.Models;

namespace Skippy.Controllers
{
    public class KlantController : Controller
    {
        KlantContainer klantContainer = new KlantContainer();

        public IActionResult Index()
        {
            List<KlantViewModel> klantViewModels = ModelFactory.AllKlantViewModels();
            return View(klantViewModels);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(KlantViewModel klantModel)
        {
            Klant newKlant = new Klant()
            {
                bezorgAdres = klantModel.bezorgAdres,
                factuurAdres = klantModel.factuurAdres,
                naam = klantModel.naam,
            };
            klantContainer.AddNew(newKlant);


            List<KlantViewModel> klantViewModels = ModelFactory.AllKlantViewModels();
            return RedirectToAction("Index", klantViewModels);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Klant klant = klantContainer.GetByID(id);
            KlantViewModel klantModel = ModelFactory.KlantViewModel(klant);
            return View(klantModel);
        }

        [HttpPost]
        public IActionResult Edit(KlantViewModel klantModel)
        {
            Klant klant = new Klant()
            {
                bezorgAdres = klantModel.bezorgAdres,
                factuurAdres = klantModel.factuurAdres,
                naam = klantModel.naam,
                id = klantModel.id
            };
            klant.Update();

            klant = klantContainer.GetByID(klant.id);
            klantModel = ModelFactory.KlantViewModelWithOrders(klant);

            return RedirectToAction("Klant", klantModel);
        }

        public IActionResult Klant(int id)
        {
            Klant klant = klantContainer.GetByID(id);
            KlantViewModel klantModel = ModelFactory.KlantViewModelWithOrders(klant);
            return View(klantModel);
        }
    }
}