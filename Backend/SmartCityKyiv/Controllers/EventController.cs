using Microsoft.AspNetCore.Authorization;
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
            List<Event> newEvents = new List<Event>();
            List<Event> oldEvents = new List<Event>();
            foreach(Event _event in context.Events)
            {
                if(_event.DateFrom.Value.Date<DateTime.Now.Date &&(!_event.DateTo.HasValue|| _event.DateTo.Value.Date<DateTime.Now.Date))
                {
                    oldEvents.Add(_event);
                }
                else
                {
                    newEvents.Add(_event);
                }
            }
            List<Event> events = new List<Event>();
            events.AddRange(newEvents.OrderBy(e => e.DateFrom));
            events.AddRange(oldEvents.OrderByDescending(e => e.DateFrom));
            return View(events);
        }
        //Get
        [Authorize(Roles = "moderator")]
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [Authorize(Roles = "moderator")]
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
        [Authorize(Roles = "moderator")]
        public IActionResult Delete(int id)
        {
            var Event = context.Events.FirstOrDefault(a => a.Id == id);
            context.Events.Remove(Event);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "moderator")]
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
        [Authorize(Roles = "moderator")]
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
