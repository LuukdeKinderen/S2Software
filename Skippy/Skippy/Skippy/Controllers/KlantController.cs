using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using Skippy.Models;
using Skippy.Models.Mappers;

namespace Skippy.Controllers
{
    public class KlantController : Controller
    {
        KlantContainer klantContainer = new KlantContainer();

        public IActionResult Index()
        {
            List<KlantViewModel> klantViewModels = KlantMapper.AllKlantViewModels();
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
            Klant newKlant = KlantMapper.Klant(klantModel);

            klantContainer.AddNew(newKlant);


            List<KlantViewModel> klantViewModels = KlantMapper.AllKlantViewModels();
            return RedirectToAction("Index", klantViewModels);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Klant klant = klantContainer.GetByID(id);
            KlantViewModel klantModel = KlantMapper.KlantViewModel(klant);
            return View(klantModel);
        }

        [HttpPost]
        public IActionResult Edit(KlantViewModel klantModel)
        {
            Klant klant = KlantMapper.Klant(klantModel);

            klant.Update();

            klant = klantContainer.GetByID(klant.id);
            klantModel = KlantMapper.KlantViewModelWithOrders(klant);

            return RedirectToAction("Klant", klantModel);
        }

        public IActionResult Klant(int id)
        {
            Klant klant = klantContainer.GetByID(id);
            KlantViewModel klantModel = KlantMapper.KlantViewModelWithOrders(klant);
            return View(klantModel);
        }
    }
}