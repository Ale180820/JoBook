using JoBook.Models;
using JoBook.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JoBook.Controllers {

    public class UserController : Controller {
        // GET: User
        public ActionResult Index() {
            return View();
        }

        public ActionResult UserProfile(string completed) {

            //if(Storage.Instance.queueTask.PeekTask().Name != null) {
            //    foreach (var item in Storage.Instance.hashTable.find(Storage.Instance.queueTask.PeekTask().Name)) {
            //        Storage.Instance.taskV.Name = item.Name;
            //        Storage.Instance.taskV.Description = item.Description;
            //        Storage.Instance.taskV.Delivery = item.Delivery;
            //    }
            //}

            //if (!String.IsNullOrEmpty(completed)) {
            //    if (Storage.Instance.queueTask.PeekTask() != null) {
            //        Storage.Instance.hashTable.delete(Storage.Instance.queueTask.DequeueTask(Storage.Instance.queueTask.PeekTask(), Task.ComparePriority).Name);
            //    }
            //}
            
            return View("UserProfile");
        }

        public ActionResult ManagementProfile(string completed){
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
