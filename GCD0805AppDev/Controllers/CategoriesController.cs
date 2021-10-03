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
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
    }
}