﻿using AppKurs.Data;
using AppKurs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppKurs.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserTaskController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() => View(_db.UserTasks.ToList());

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] UserTask model)
        {
            UserTask uTask = new UserTask { TaskTitle = model.TaskTitle,
                                            TaskText = model.TaskText,
                                            TaskAnswer = model.TaskAnswer,
                                            TaskUser = User.Identity.Name,
                                            TaskTopic = model.TaskTopic };
            _db.UserTasks.Add(uTask);
            _db.SaveChanges();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usertask = await _db.UserTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usertask == null)
            {
                return NotFound();
            }

            return View(usertask);
        }
    }
}
