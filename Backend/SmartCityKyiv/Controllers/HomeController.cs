using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartCityKyiv.Models;
using SmartCityKyiv.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var viewModel = new MainPageViewModel()
            {
                Articles = new List<Article>()
                {
                    new Article
                    {
                        Title = "Заголовок 1",
                        Text = "lisdhaygdsaugdauyfsdygasdsuydkausdksakdf"
                    },
                    new Article
                    {
                        Title = "Заголовок 2",
                        Text = "lisdhaygdsaugdauyfsdygasdsuydkausdksakdf"
                    },
                    new Article
                    {
                        Title = "Заголовок 3",
                        Text = "lisdhaygdsaugdauyfsdygasdsuydkausdksakdf"
                    }
                },
                Events = new List<Event>()
                {
                    new Event
                    {
                        Name ="Захід 1",
                        Description = "ішврфдвнпфігнпвфніавлшгіфнавіфнав"
                    },
                    new Event
                    {
                        Name ="Захід 2",
                        Description = "ішврфдвнпфігнпвфніавлшгіфнавіфнав"
                    },
                    new Event
                    {
                        Name ="Захід 3",
                        Description = "ішврфдвнпфігнпвфніавлшгіфнавіфнав"
                    }
                }
            };

            return View(viewModel);
        }

    }
}
