using JoBook.Services;
using System;
using System.Linq;
using System.IO;

/*
 * @author: Aylinne Recinos
 * @version: 1.0.0
 * @description: Class for Tasks
 */

namespace JoBook.Models {

    public class Task {

        //Class atributes
        public int idTask { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Project { get; set; }
        public int Priority { get; set; }
        public int idUser { get; set; }
        public DateTime Delivery { get; set; }

        //Constructor class
        public Task() { 
        
        }

        //Constructor class
        public Task(String Name, int Priority){
            this.Priority = Priority;
            this.Name = Name;
        }

        /// <summary>
        /// Delegate to compare the tasks
        /// </summary>
        public static Comparison<Task> ComparePriority = delegate (Task task1, Task task2) {
            return task1.Priority.CompareTo(task2.Priority);
        };

        //Method for storing tasks
        public bool saveTask(bool type) {
            try {
                if (type) {
                    Storage.Instance.hashTable.insert(this.Name, this);
                    Storage.Instance.queueTask.EnqueueTask(new Task(this.Name, this.Priority), Task.ComparePriority);

                }else {
                    Storage.Instance.hashTable.insert(this.Name, this);
                    Storage.Instance.queueTask.EnqueueTask(new Task(this.Name, this.Priority), Task.ComparePriority);
                    var path = AppDomain.CurrentDomain.BaseDirectory + "/files/Tasks/Tasks.csv";
                    var streamWriter = new StreamWriter(path, true);
                    streamWriter.WriteLine(this.idTask + "," + this.Name + "," + this.Description + "," + this.Project + ","
                        + this.Priority + "," + this.idUser + "," + this.Delivery);
                    streamWriter.Close();
                }
                return true;
            }catch{
                return false;
            }
        }
    }
}