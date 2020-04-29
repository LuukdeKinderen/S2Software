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
            return View(CategorieContainer.GetCategories());
        }

        public IActionResult Categorie(int id)
        {
            return View(CategorieContainer.GetByID(id));
        }
    }
}