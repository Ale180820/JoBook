using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * @author: Aylinne Recinos
 * @version: 1.0.0
 * @description: Class for Tasks
 */

namespace JoBook.Models {

    public class Tasks {

        public String name { get; set; }
        public String description { get; set; }
        public String project { get; set; }
        public int priority { get; set; }
        public int idUser { get; set; }
        public DateTime dateOfDelivery { get; set; }
    }
}