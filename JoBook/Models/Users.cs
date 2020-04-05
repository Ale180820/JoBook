using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoBook.Models
{
    public class Users
    {
     /*
     * @author: Aylinne Recinos
     * @version: 1.0.0
     * @description: Class for Users
     */
        public int idUser { get; set; }
        public String name { get; set; }
        public String lastName { get; set; }
        public String typeUser { get; set; }
    }
}