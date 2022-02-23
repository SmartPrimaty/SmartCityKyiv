using Microsoft.AspNetCore.Mvc;
using SmartCityKyiv.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Controllers
{
    public class AccountController : Controller
    {
        private SiteContext context;

        public AccountController(SiteContext context)
        {
            this.context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
