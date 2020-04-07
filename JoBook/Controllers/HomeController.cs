using JoBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoBook.Controllers {
    
    public class HomeController : Controller {

        public ActionResult Index() {
            LoadDocument();
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection) {
            var userLogin = new User {
                Nickname = collection["Nickname"],
                Password = collection["Password"]
            };
            if (userLogin.loginUser()){
                return RedirectToAction("Index");
            }
            return View();
        }


        public void LoadDocument() {
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