using Skippy.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Skippy.Controllers
{
    public class CategoriesController : Controller
    {
        CategorieContainer categorieContainer = new CategorieContainer();

        public IActionResult Index()
        {
            return View(categorieContainer.GetAll());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categorie categorie)
        {
            categorieContainer.AddNew(categorie);
            return RedirectToAction("Index", categorieContainer.GetAll());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(categorieContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Categorie categorie)
        {
            categorie.Update();
            return RedirectToAction("Categorie", categorieContainer.GetByID(categorie.id));
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            categorieContainer.Delete(id);
            return RedirectToAction("Index", categorieContainer.GetAll());
        }

        public IActionResult Categorie(int id)
        {
            return View(categorieContainer.GetByID(id));
        }
        [Authorize]
        public IActionResult AddProduct(int categorieId, int productId)
        {
            Categorie categorie = categorieContainer.GetByID(categorieId);
            categorie.AddProduct(productId);

            return RedirectToAction("Edit", categorie);
        }
        [Authorize]
        public IActionResult RemoveProduct(int categorieId, int productId)
        {
            Categorie categorie = categorieContainer.GetByID(categorieId);
            categorie.RemoveProduct(productId);

            return RedirectToAction("Edit", categorie);
        }
    }
}