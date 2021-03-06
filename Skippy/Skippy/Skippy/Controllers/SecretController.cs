﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Skippy.MemoryData;
using Skippy.Models;

namespace Skippy.Controllers
{
    public class SecretController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public SecretController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AppDbContext appDbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel loginModel)
        {


            IdentityUser user = await _userManager.FindByNameAsync(loginModel.login);



            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(loginModel.login, loginModel.password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel loginModel)
        {

            var user = new IdentityUser
            {
                UserName = loginModel.login
            };
            var result = await _userManager.CreateAsync(user, loginModel.password);
            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(loginModel.login, loginModel.password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }




    }
}