using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Skippy.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View(CategorieContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categorie categorie)
        {
            CategorieContainer.Insert(categorie);
            return RedirectToAction("Index", CategorieContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(CategorieContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Categorie categorie)
        {
            CategorieContainer.Update(categorie);
            return RedirectToAction("Categorie", CategorieContainer.GetByID(categorie.id));
        }

        public IActionResult Delete(int id)
        {
            CategorieContainer.Delete(id);
            return RedirectToAction("Index", CategorieContainer.GetAll());
        }

        public IActionResult Categorie(int id)
        {
            return View(CategorieContainer.GetByID(id));
        }

        public IActionResult AddProduct(int categorieId, int productId)
        {
            Categorie categorie = CategorieContainer.GetByID(categorieId);
            categorie.AddProduct(productId);

            return RedirectToAction("Edit", categorie);
        }

        public IActionResult RemoveProduct(int categorieId, int productId)
        {
            Categorie categorie = CategorieContainer.GetByID(categorieId);
            categorie.RemoveProduct(productId);

            return RedirectToAction("Edit", categorie);
        }
    }
}