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
    public class NewsController : Controller
    {
        private SiteContext context;
        public NewsController(SiteContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Article> articles = context.Articles.OrderByDescending(a => a.PublicationDate);
            return View(articles);
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
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                article.PublicationDate = DateTime.Now;
                context.Articles.Add(article);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }
       
        [HttpGet]
        public IActionResult Article(int id)
        {
            Article article = context.Articles.FirstOrDefault(a => a.Id == id);
            if (article is null)
            {
                return NotFound();
            }
            return View(article);
        }

        [HttpGet]
        [Authorize(Roles = "moderator")]
        public IActionResult Delete(int id)
        {          
            Article article = context.Articles.FirstOrDefault(a => a.Id == id);           
            context.Articles.Remove(article);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "moderator")]
        public IActionResult Update(int id)
        {       
            Article article = context.Articles.FirstOrDefault(a => a.Id == id);
            if (article is null)
            {
                return NotFound();
            }
            return View(article);
        }
        [HttpPost]
        [Authorize(Roles = "moderator")]
        public IActionResult Update(Article article)
        {          
            if (article is null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Articles.Update(article);
                context.SaveChanges();
                return RedirectToAction(nameof(Article), new { article.Id });
            }
            return View(article);
        }

    }
}
