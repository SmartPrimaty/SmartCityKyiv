using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SmartCityKyiv.Data;
using SmartCityKyiv.Models;
using SmartCityKyiv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SmartCityKyiv.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SmartCityKyiv.Controllers
{
    public class AccountController : Controller
    {
        private SiteContext context;

        public AccountController(SiteContext context)
        {
            this.context = context;
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hashPassword = Utilities.CreateHashString(model.Password);
                User user = context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == hashPassword);
                if (user != null)
                {
                    user.Role = context.Roles.FirstOrDefault(r => r.Id == user.RoleId);
                    Authenticate(user); // authentication

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неправильний логін та (або) пароль");
            }
            return View(model);
        }

        [HttpGet("/register")]
        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/register")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    // adding user to DB
                    var hashPassword = Utilities.CreateHashString(model.Password);
                    context.Users.Add(new User()
                    {
                        Email = model.Email,
                        Password = hashPassword,
                        FullName = model.FullName,
                        RoleId = 2
                    });
                    context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Email зайнятий");
            }
            return View(model);
        }

        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)

            };
            // creating ClaimsIdentity object
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // setting authenticational cookies
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        
    }
}
