﻿using JoBook.Models;
using JoBook.Services;
using System;
using System.Web.Mvc;

namespace JoBook.Controllers {
    public class TaskController : Controller {

        // GET: Task
        public ActionResult Index() {
            if (Storage.Instance.userLogin.loginUser())
            {
                if (Storage.Instance.userLogin.Type == 2)
                {
                    return RedirectToAction("UserProfile", "User");
                }
                else
                {
                    return RedirectToAction("ManagementProfile", "User");
                }
            }
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
            try{
                var newTask = new Task {
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Project = collection["Proyect"],
                    Priority = Convert.ToInt32(collection["Priority"]),
                    idUser = Convert.ToInt32(collection["idUser"]),
                    Delivery = Convert.ToDateTime(collection["Delivery"])
                };

                Storage.Instance.queueTask.EnqueueTask(newTask, Task.ComparePriority);
                

                if (Storage.Instance.userLogin.loginUser()) {
                    if (Storage.Instance.userLogin.Type == 2) {
                        return RedirectToAction("UserProfile", "User");
                    }
                    else {
                        return RedirectToAction("ManagementProfile", "User");
                    }
                }
                return View();
            }
            catch{
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
