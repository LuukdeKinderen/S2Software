using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Skippy.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login(string returnUrl)
        {
            string decodedUrl = "";
            if (!string.IsNullOrEmpty(returnUrl))
                decodedUrl = HttpUtility.UrlDecode(returnUrl);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Luuk de Kinderen"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "myIdentity");

            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(userPrincipal);

            //if (Url.IsLocalUrl(decodedUrl))
            //{
            //    return Redirect(decodedUrl);
            //}
            //else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}