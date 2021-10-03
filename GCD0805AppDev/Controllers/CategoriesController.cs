using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCD0805AppDev.Models;

namespace GCD0805AppDev.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Categories
        [HttpGet]
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var newCategory = new Category()
            {
                Description = category.Description,
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (categoryInDb == null)
            {
                return HttpNotFound();
            }
            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }
    }
}