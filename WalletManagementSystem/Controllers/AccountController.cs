using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WalletManagementBL;
using WalletManagementEntity;

namespace WalletManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountBL _accountBL;
        public AccountController(AccountBL account)
        {
            _accountBL = account;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Register(User userModel)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            var res = await _accountBL.Register(userModel);

            if (res != 0)
            {

                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,userModel.Email),
                    new Claim(ClaimTypes.Role,userModel.UserId.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticate = true;
            }

            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                TempData["UserId"] = userModel.UserId;
                return RedirectToAction("Index", "Card");
            }
            else
                return View();

        }

        public async Task<IActionResult> Login(User userModel)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;

            var res = await _accountBL.Login(userModel);

            if (res!=0)
            {

                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,userModel.Email),
                    new Claim(ClaimTypes.Role,"User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticate = true;
            }

            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                TempData["UserId"] = userModel.UserId;
                return RedirectToAction("Index", "Card");
            }
            else
                return View();
        }
    }
}
