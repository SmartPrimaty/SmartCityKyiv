using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Parking()
        {
            ViewData["MapTitle"] = "Карта паркування";
            ViewData["SourceMap"] = "https://www.google.com/maps/d/u/0/embed?mid=1BfXk9Uxac9ejfl_TdhvIEJGw5gR6AqSQ&ehbc=2E312F";
            return View("Index");
        }

        public IActionResult Batteries()
        {
            ViewData["MapTitle"] = "Карта пунктів утилізації батарейок майданчиків";
            ViewData["SourceMap"] = "https://www.google.com/maps/d/u/0/embed?mid=1dq2KpclRFQBRVXsFB6pL2mxxXG7gRh_c&ehbc=2E312F";
            return View("Index");
        }

        public IActionResult Trash()
        {
            ViewData["MapTitle"] = "Карта пунктів сортування сміття";
            ViewData["SourceMap"] = "https://www.google.com/maps/d/u/0/embed?mid=1wKWRHPHDGdnaVeUYPb_6ffYjTP3Bs9Qw&ehbc=2E312F";
            return View("Index");
        }

        public IActionResult Sport()
        {
            ViewData["MapTitle"] = "Карта спортивних майданчиків";
            ViewData["SourceMap"] = "https://www.google.com/maps/d/u/0/embed?mid=1JT8hZp4ksMxNT00HyXwQs0D5mPOPh6z1&ehbc=2E312F";
            return View("Index");
        }

        public IActionResult Parks()
        {
            ViewData["MapTitle"] = "Карта парків та рекреаційних зон";
            ViewData["SourceMap"] = "https://www.google.com/maps/d/u/0/embed?mid=1u_2GY4vlBUgggVWZn0hJGwhkfrGFfRSz&ehbc=2E312F";
            return View("Index");
        }
    }
}
