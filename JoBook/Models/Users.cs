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

    public class Users {

        public int idUser { get; set; }
	    public String username { get; set; }
        public String name { get; set; }
        public String lastName { get; set; }
        public String typeUser { get; set; }
    }
}
