using Skippy.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Skippy.Models;
using System.Collections.Generic;

namespace Skippy.Controllers
{
    public class CategoriesController : Controller
    {
        CategorieContainer categorieContainer = new CategorieContainer();


        public IActionResult Index()
        {
            return View(ModelFactory.AllCategorieViewModels());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategorieViewModel categorieModel)
        {
            Categorie newCategorie = new Categorie()
            {
                titel = categorieModel.titel
            };
            categorieContainer.AddNew(newCategorie);

            return RedirectToAction("Index", ModelFactory.AllCategorieViewModels());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categorie categorie = categorieContainer.GetByID(id);

            CategorieViewModel categorieViewModel = ModelFactory.CategorieEditViewModel(categorie);

            return View(categorieViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategorieViewModel categorieModel)
        {
            Categorie categorie = new Categorie()
            {
                id = categorieModel.id,
                titel = categorieModel.titel
            };
            categorie.Update();
            categorie = categorieContainer.GetByID(categorie.id);
            categorieModel = ModelFactory.CategorieEditViewModel(categorie);
            return RedirectToAction("Categorie", categorieModel);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            categorieContainer.Delete(id);

            return RedirectToAction("Index", ModelFactory.AllCategorieViewModels());
        }

        public IActionResult Categorie(int id)
        {
            Categorie categorie = categorieContainer.GetByID(id);

            CategorieViewModel categorieViewModel = ModelFactory.CategorieViewModel(categorie);

            return View(categorieViewModel);
        }

        [Authorize]
        public IActionResult AddProduct(int categorieId, int productId)
        {
            Categorie categorie = categorieContainer.GetByID(categorieId);
            categorie.AddProduct(productId);

            CategorieViewModel categorieViewModel = ModelFactory.CategorieEditViewModel(categorie);

            return RedirectToAction("Edit", categorieViewModel);
        }
        [Authorize]
        public IActionResult RemoveProduct(int categorieId, int productId)
        {
            Categorie categorie = categorieContainer.GetByID(categorieId);
            categorie.RemoveProduct(productId);

            CategorieViewModel categorieViewModel = ModelFactory.CategorieEditViewModel(categorie);

            return RedirectToAction("Edit", categorieViewModel);
        }

    }
}