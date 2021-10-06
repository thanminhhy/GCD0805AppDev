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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Team team)
        { 
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            var newTeam = new Team()
            {
                Name = team.Name
            };
            _context.Teams.Add(newTeam);
            _context.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var teamInDb = _context.Teams.SingleOrDefault(t => t.Id == id);
            if(teamInDb == null)
            {
                return HttpNotFound();
            }
            _context.Teams.Remove(teamInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Teams");
        }
    }
}