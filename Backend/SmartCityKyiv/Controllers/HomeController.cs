using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartCityKyiv.Data;
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
        private SiteContext context;

        public HomeController(SiteContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            var articles = context.Articles.OrderByDescending(a => a.PublicationDate).Take(3).ToList();
            var events = context.Events.OrderByDescending(e => e.DateFrom).Take(3).ToList();

            var viewModel = new MainPageViewModel()
            {
                Articles = articles,
                Events = events
            };

            return View(viewModel);
            //TO DO - change mock to database data

            //var mock = new MainPageViewModel()
            //{
            //    Articles = new List<Article>()
            //    {
            //        new Article
            //        {
            //            Title = "Заголовок 1",
            //            Text = "lisdhaygdsaugdauyfsdygasdsuydkausdksakdf"
            //        },
            //        new Article
            //        {
            //            Title = "Заголовок 2",
            //            Text = "lisdhaygdsaugdauyfsdygasdsuydkausdksakdf"
            //        },
            //        new Article
            //        {
            //            Title = "Заголовок 3",
            //            Text = "lisdhaygdsaugdauyfsdygasdsuydkausdksakdf"
            //        }
            //    },
            //    Events = new List<Event>()
            //    {
            //        new Event
            //        {
            //            Name ="Захід 1",
            //            Description = "ішврфдвнпфігнпвфніавлшгіфнавіфнав"
            //        },
            //        new Event
            //        {
            //            Name ="Захід 2",
            //            Description = "ішврфдвнпфігнпвфніавлшгіфнавіфнав"
            //        },
            //        new Event
            //        {
            //            Name ="Захід 3",
            //            Description = "ішврфдвнпфігнпвфніавлшгіфнавіфнав"
            //        }
            //    }
            //};


        }

        public IActionResult Covid()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult War()
        {
            return View();
        }

       
    }
}
