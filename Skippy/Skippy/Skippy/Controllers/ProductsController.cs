using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skippy.Logic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Skippy.Models;
using Skippy.Models.Mappers;

namespace Skippy.Controllers
{
    public class ProductsController : Controller
    {
        ProductContainer productContainer = new ProductContainer();

        public IActionResult Index()
        {
            List<ProductViewModel> productViews = ProductMapper.AllProductViewModels();

            return View(productViews);
        }
        public IActionResult Product(int id)
        {
            Product product = productContainer.GetByID(id);
            ProductViewModel productView = ProductMapper.ProductViewModel(product);
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
            Product newProduct = ProductMapper.Product(productModel);

            productContainer.AddNew(newProduct);

            List<ProductViewModel> productViews = ProductMapper.AllProductViewModels();

            return RedirectToAction("Index", productViews);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = productContainer.GetByID(id);
            ProductViewModel productView = ProductMapper.ProductViewModel(product);
            return View(productView);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productModel)
        {
            Product product = ProductMapper.Product(productModel);

            product.Update();

            product = productContainer.GetByID(product.id);
            productModel = ProductMapper.ProductViewModel(product);

            return RedirectToAction("Product", productModel);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            productContainer.Delete(id);

            List<ProductViewModel> productViews = ProductMapper.AllProductViewModels();

            return RedirectToAction("Index", productViews);
        }
    }
}