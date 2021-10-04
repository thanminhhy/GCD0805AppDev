﻿using GCD0805AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using GCD0805AppDev.ViewModels;

namespace GCD0805AppDev.Controllers
{
    public class TodosController : Controller
    {
        private ApplicationDbContext _context;
        public TodosController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var todos = _context.Todos
                .Include(t => t.Category)
                .ToList();

            return View(todos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new TodoCategoriesViewModel()
            {
                Categories = categories
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(TodoCategoriesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TodoCategoriesViewModel()
                {
                    Todo = model.Todo,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);
            }

            var newTodo = new Todo()
            {
                Description = model.Todo.Description,
                DueDate = model.Todo.DueDate,
                CategoryId = model.Todo.CategoryId
            };
            _context.Todos.Add(newTodo);
            _context.SaveChanges();
            return RedirectToAction("Index", "Todos");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }
            _context.Todos.Remove(todoInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Todos");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var todoInDb = _context.Todos
                .Include(t => t.Category)
                .SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }
            return View(todoInDb);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }
            var viewModel = new TodoCategoriesViewModel()
            {
                Todo = todoInDb,
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }

            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == todo.Id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }
            todoInDb.Description = todo.Description;
            todoInDb.DueDate = todo.DueDate;
            _context.SaveChanges();
            return RedirectToAction("Index", "Todos");
        }
    }
}