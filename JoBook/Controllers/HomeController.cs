using JoBook.Models;
using JoBook.Services;
using System;
using System.IO;
using System.Web.Mvc;

namespace JoBook.Controllers {
    
    public class HomeController : Controller {

        public ActionResult Index() {
            LoadUserDocument();
            LoadTaskDocument();
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection) {
            var userLogin = new User {
                Nickname = collection["Nickname"],
                Password = collection["Password"]
            };

            if (userLogin.loginUser()){
                if (Storage.Instance.userLogin.Type == 2){
                    return RedirectToAction("UserProfile","User");
                }else{
                    return RedirectToAction("ManagementProfile", "User");
                }
            }
            return View();
        }


        public void LoadTaskDocument() {
            var ubication = Server.MapPath($"~/files/Tasks/Tasks.csv");
            using (var fileStream = new FileStream(ubication, FileMode.Open)) {
                using (var streamReader = new StreamReader(fileStream)){
                    Task newTask;
                    while (streamReader.Peek() >= 0){
                        newTask = new Task();
                        String lineReader = streamReader.ReadLine();
                        String[] parts = lineReader.Split(',');
                        if (parts[0] != ("idTask") && parts[0] != ("")) {
                            newTask.idTask = Convert.ToInt32(parts[0]);
                            newTask.Name = parts[1];
                            newTask.Description = parts[2];
                            newTask.Project = parts[3];
                            newTask.Priority = Convert.ToInt32(parts[4]);
                            newTask.idUser = Convert.ToInt32(parts[5]);
                            newTask.Delivery = Convert.ToDateTime(parts[6]);
                            newTask.saveTask(true);
                        }
                    }
                }
            }
        }

        public void LoadUserDocument() {
            var ubication = Server.MapPath($"~/files/Users/Users.csv");
            using (var fileStream = new FileStream(ubication, FileMode.Open)) {
                using (var streamReader = new StreamReader(fileStream)){
                    User newUser;
                    while (streamReader.Peek() >= 0) {
                        newUser = new User();
                        String lineReader = streamReader.ReadLine();
                        String[] parts = lineReader.Split(',');
                        if (parts[0] != ("idUser") && parts[0] != ("")){
                            newUser.IdUser = Convert.ToInt32(parts[0]);
                            newUser.Nickname = parts[1];
                            newUser.Password = parts[2];
                            newUser.Name = parts[3];
                            newUser.Lastname = parts[4];
                            newUser.Type = Convert.ToInt32(parts[5]);
                            newUser.saveUser(true);
                        }

                    }
                }
            }
        }

    }
}