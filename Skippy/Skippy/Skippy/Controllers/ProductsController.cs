using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Skippy.Models;

namespace Skippy.Controllers
{
    public class ProductsController : Controller
    {
        ProductContainer productContainer = new ProductContainer();

        public IActionResult Index()
        {
            List<ProductViewModel> productViews = new List<ProductViewModel>();
            foreach (Product product in productContainer.GetAll())
            {
                productViews.Add(new ProductViewModel(product));
            }

            return View(productViews);
        }
        public IActionResult Product(int id)
        {
            Product product = productContainer.GetByID(id);
            ProductViewModel productView = new ProductViewModel(product);
            return View(productView);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productModel)
        {
            Product newProduct = new Product()
            {
                titel = productModel.titel,
                omschrijving = productModel.omschrijving,
                prijs = productModel.prijs
            };
            productContainer.AddNew(newProduct);

            List<ProductViewModel> productViews = new List<ProductViewModel>();
            foreach (Product product in productContainer.GetAll())
            {
                productViews.Add(new ProductViewModel(product));
            }

            return RedirectToAction("Index", productViews);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = productContainer.GetByID(id);
            ProductViewModel productView = new ProductViewModel(product);
            return View(productView);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productModel)
        {
            Product product = new Product()
            {
                titel = productModel.titel,
                omschrijving = productModel.omschrijving,
                prijs = productModel.prijs,
                id = productModel.id
            };
            product.Update();

            product = productContainer.GetByID(product.id);
            productModel = new ProductViewModel(product);

            return RedirectToAction("Product", productModel);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            productContainer.Delete(id);

            List<ProductViewModel> productViews = new List<ProductViewModel>();
            foreach (Product product in productContainer.GetAll())
            {
                productViews.Add(new ProductViewModel(product));
            }
            return RedirectToAction("Index", productViews);
        }
    }
}