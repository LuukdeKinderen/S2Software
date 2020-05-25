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
        CategorieContainer categorieContainer = new CategorieContainer();

        public IActionResult Index()
        {
            return View(categorieContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categorie categorie)
        {
            categorieContainer.Insert(categorie);
            return RedirectToAction("Index", categorieContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(categorieContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Categorie categorie)
        {
            categorieContainer.Update(categorie);
            return RedirectToAction("Categorie", categorieContainer.GetByID(categorie.id));
        }

        public IActionResult Delete(int id)
        {
            categorieContainer.Delete(id);
            return RedirectToAction("Index", categorieContainer.GetAll());
        }

        public IActionResult Categorie(int id)
        {
            return View(categorieContainer.GetByID(id));
        }

        public IActionResult AddProduct(int categorieId, int productId)
        {
            Categorie categorie = categorieContainer.GetByID(categorieId);
            categorie.AddProduct(productId);

            return RedirectToAction("Edit", categorie);
        }

        public IActionResult RemoveProduct(int categorieId, int productId)
        {
            Categorie categorie = categorieContainer.GetByID(categorieId);
            categorie.RemoveProduct(productId);

            return RedirectToAction("Edit", categorie);
        }
    }
}