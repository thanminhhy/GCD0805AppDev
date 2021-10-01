﻿using GCD0805AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
    public class TodosController : Controller
    {
        private ApplicationDbContext _context;
        public TodosController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Todos
        public ActionResult Index()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }
    }
}