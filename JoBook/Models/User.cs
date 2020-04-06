using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
* @author: Aylinne Recinos
* @version: 1.0.0
* @description: Class for Users
*/

namespace JoBook.Models {

    public class User {

        public int IdUser { get; set; }
	    public String Nickname { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String Type { get; set; }
    }
}
