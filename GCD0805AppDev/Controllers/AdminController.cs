using GCD0805AppDev.Utils;
using GCD0805AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateManager()
        {
            return View();
        }
    }
}