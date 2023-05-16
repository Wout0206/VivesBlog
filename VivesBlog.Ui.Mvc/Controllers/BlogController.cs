using Microsoft.AspNetCore.Mvc;
using System;
using VivesBlog.Ui.Mvc.Core;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly VivesBlogDbContext _dbContext;

        public BlogController(VivesBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var articles = _dbContext.Articles.ToList();
            return View(articles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }
            article.CreatedDate = DateTime.UtcNow;

            _dbContext.Articles.Add(article);

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var article = _dbContext.Articles
                .FirstOrDefault(a => a.Id == id);

            if (!ModelState.IsValid)
            {
                return View(article);
            }
            if (article is null)
            {
                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }
            var dbArticle = _dbContext.Articles.FirstOrDefault(a => a.Id == id);

            if (dbArticle is null)
            {
                return RedirectToAction("Index");
            }

            dbArticle.Title = article.Title;
            dbArticle.Author = article.Author;
            dbArticle.Description = article.Description;
            dbArticle.Content = article.Content;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}