using JoBook.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
* @author: Aylinne Recinos
* @version: 1.0.0
* @description: Class for Users
*/

namespace JoBook.Models {

    public class User {

        public static int codeUser = 0;
        public int IdUser { get; set; }
        public String Nickname { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public int Type { get; set; }

        public bool saveUser(bool type) {
            codeUser++;
            this.IdUser = codeUser;
            try {
                if (type) {
                    Storage.Instance.listUsers.Add(this);
                } else {
                    Storage.Instance.listUsers.Add(this);
                    var path = AppDomain.CurrentDomain.BaseDirectory + "/files/Users/Users.csv";
                    var streamWriter = new StreamWriter(path, true);
                    streamWriter.WriteLine(this.IdUser + "," + this.Nickname + "," + this.Password + ","
                        + this.Name + "," + this.Lastname + "," + this.Type);
                    streamWriter.Close();
                }
                return true;
            } catch {
                return false;
            }
        }

        public bool loginUser() {
            bool result = false;
            foreach (var item in Storage.Instance.listUsers) {
                if (item.Nickname.Equals(this.Nickname) && item.Password.Equals(this.Password)) {
                    Storage.Instance.userLogin = item;
                    result = true;
                }
            }
            return result;
        }

        public string returnGreeting(){
            if (DateTime.Now.ToString("tt", CultureInfo.InvariantCulture) == "AM"){
                return "¡Buenos días!";
            }else if(DateTime.Now.ToString("tt", CultureInfo.InvariantCulture) == "PM"){
                return "¡Buenas tardes!";
            }else{
                return "";
            }
        }

        public string evaluateTypeUser(){
            if (Type == 1){
                return "Management";
            }else{
                return "Developer";
            }
        }
    }
}
