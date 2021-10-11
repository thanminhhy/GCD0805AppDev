using GCD0805AppDev.Models;
using GCD0805AppDev.Utils;
using GCD0805AppDev.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
    [Authorize(Roles = Role.Manager)]
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
            List<TeamUsersViewModel> viewModel = _context.UserTeams
        .GroupBy(i => i.Team)
        .Select(res => new TeamUsersViewModel
        {
            Team = res.Key,
            Users = res.Select(u => u.User).ToList()
        })
        .ToList();

            return View(viewModel);
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var teamInDb = _context.Teams.SingleOrDefault(t => t.Id == id);
            if(teamInDb == null)
            {
                return HttpNotFound();
            }
            return View(teamInDb);
        }
        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if(!ModelState.IsValid)
            {
                return View(team);
            }

            var teamInDb = _context.Teams.SingleOrDefault(t => t.Id == team.Id);
            if(teamInDb == null)
            {
                return HttpNotFound();
            }

            teamInDb.Name = team.Name;
            _context.SaveChanges();

            return RedirectToAction("Index", "Teams");
        }
        [HttpGet]
        public ActionResult AddUsers()
        {
            var role = _context.Roles.SingleOrDefault(m => m.Name == Role.User);
            var viewModel = new UserTeamsViewModel()
            {
                Teams = _context.Teams.ToList(),
                Users = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddUsers(UserTeamsViewModel viewModel)
        {
            var model = new UserTeam()
            {
                UserId = viewModel.UserId,
                TeamId = viewModel.TeamId
            };
            _context.UserTeams.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index","Teams");
        }
        [HttpGet]
        public ActionResult RemoveUser()
        {
            var users = _context.UserTeams
                .Select(t => t.User)
                .Distinct()
                .ToList();
            var teams = _context.UserTeams
                .Select(t => t.Team)
                .Distinct()
                .ToList();

            var viewModel = new UserTeamsViewModel()
            {
                Teams = teams,
                Users = users
            };
            return View(viewModel);
        }
    }
}