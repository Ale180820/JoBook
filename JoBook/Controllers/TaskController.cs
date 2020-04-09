﻿using JoBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoBook.Controllers {
    public class TaskController : Controller {
        // GET: Task
        public ActionResult Index() {
            return View();
        }

        // GET: Task/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                var newTask = new Task {
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Project = collection["Proyect"],
                    Priority = Convert.ToInt32(collection["Priority"]),
                    idUser = Convert.ToInt32(collection["idUser"])
                };

                return RedirectToAction("Index");
            }catch{
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here 
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
