using Microsoft.AspNetCore.Mvc;
using SmartCityKyiv.Data;
using SmartCityKyiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCityKyiv.Controllers
{
    public class EventController : Controller
    {
        private SiteContext context;
        public EventController(SiteContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Event> events = context.Events.OrderByDescending(e => e.DateFrom);
            return View(events);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public IActionResult Create(Event Event)
        {          
            if (ModelState.IsValid)
            {
                context.Events.Add(Event);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Event);
        }

        [HttpGet]
        public IActionResult Event(int id)
        {
            var Event = context.Events.FirstOrDefault(a => a.Id == id);
            if (Event is null)
            {
                return NotFound();
            }
            return View(Event);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Event = context.Events.FirstOrDefault(a => a.Id == id);
            context.Events.Remove(Event);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var Event = context.Events.FirstOrDefault(a => a.Id == id);
            if (Event is null)
            {
                return NotFound();
            }
            return View(Event);
        }
        [HttpPost]
        public IActionResult Update(Event Event)
        {
            if (Event is null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Events.Update(Event);
                context.SaveChanges();
                return RedirectToAction(nameof(Event),new { Event.Id });
            }
            return View(Event);
        }
    }
}
