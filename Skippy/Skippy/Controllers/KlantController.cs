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
        public IActionResult Index()
        {
            return View(KlantContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Klant klant)
        {
            KlantContainer.Insert(klant);
            return RedirectToAction("Index", KlantContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(KlantContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Klant klant)
        {
            KlantContainer.Update(klant);
            int id = klant.id;
            return RedirectToAction("Klant", KlantContainer.GetByID(id));
        }

        

        public IActionResult Klant(int id)
        {
            return View(KlantContainer.GetByID(id));
        }

        //public IActionResult AddProduct(int categorieId, int productId)
        //{
        //    Categorie categorie = CategorieContainer.GetByID(categorieId);
        //    categorie.AddProduct(productId);

        //    return RedirectToAction("Edit", categorie);
        //}

        //public IActionResult RemoveProduct(int categorieId, int productId)
        //{
        //    Categorie categorie = CategorieContainer.GetByID(categorieId);
        //    categorie.RemoveProduct(productId);

        //    return RedirectToAction("Edit", categorie);
        //}
    }
}