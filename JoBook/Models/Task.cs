using JoBook.Services;
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

    public class Task {

        public int idTask { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Project { get; set; }
        public int Priority { get; set; }
        public int idUser { get; set; }
        public DateTime Delivery { get; set; }

        /// <summary>
        /// Delegate to compare the tasks
        /// </summary>
        public static Comparison<Task> ComparePriority = delegate (Task task1, Task task2) {
            return task1.Priority.CompareTo(task2.Priority);
        };


        public bool saveTask() {
            try {
                Storage.Instance.hashTable.insert(this.Name, this);
                Storage.Instance.hashTable.delete("Login");
                return true;
            }catch{
                return false;
            }

            
        }
    }
}