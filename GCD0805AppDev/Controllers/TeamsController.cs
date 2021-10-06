using GCD0805AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
    public class TeamsController : Controller
    {
        ApplicationDbContext _context;
        public TeamsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Teams
        public ActionResult Index()
        {
            var newTeam = _context.Teams.ToList();
            return View(newTeam);
        }
    }
}