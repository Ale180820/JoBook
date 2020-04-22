﻿using JoBook.Models;
using JoBook.Services;
using System;
using System.Web.Mvc;

namespace JoBook.Controllers {

    public class UserController : Controller {
        // GET: User
        public ActionResult Index() {
            return View();
        }

        public ActionResult UserProfile() {

            return View("UserProfile");
            
        }

        public ActionResult ManagementProfile(string completed){

            if (!String.IsNullOrEmpty(completed)) {
                Storage.Instance.queueTask.DequeueTask(Task.ComparePriority);
            }

            return View("ManagementProfile");
        }

        public ActionResult CreateView(){
            return View("Create");
        }

        // GET: User/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: User/Create
        public ActionResult Create() {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                var newUser = new User {
                    Name = collection["Name"],
                    Lastname = collection["Lastname"],
                    Nickname = collection["Nickname"],
                    Password = collection["Password"],
                    Type = Convert.ToInt32(collection["Type"])
                };
                newUser.saveUser(false);
                if (Storage.Instance.userLogin.loginUser()) {
                    if (Storage.Instance.userLogin.Type == 2) {
                        return RedirectToAction("UserProfile", "User");
                    } else {
                        return RedirectToAction("ManagementProfile", "User");
                    }
                }

                return View();
            }
            catch {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }catch {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }catch {
                return View();
            }
        }
    }
}
