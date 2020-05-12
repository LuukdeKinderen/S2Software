﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using System.Diagnostics;

namespace Skippy.Controllers
{
    public class OrderController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View(ProductContainer.GetAll());
        //}
        public IActionResult Order(int id)
        {
            Order order = OrderContainer.GetByID(id);
            return View(order);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ProductContainer.Insert(product);
            return RedirectToAction("Index", ProductContainer.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(ProductContainer.GetByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductContainer.Update(product);
            return RedirectToAction("Product", ProductContainer.GetByID(product.id));
        }




        public IActionResult Delete(int id)
        {
            ProductContainer.Delete(id);
            return RedirectToAction("Index", ProductContainer.GetAll());
        }
    }
}