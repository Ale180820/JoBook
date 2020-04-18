using CustomGenerics.Structures;
using JoBook.Models;
using System.Collections.Generic;

namespace JoBook.Services {
    public class Storage {

        private static Storage _instance = null;

        public static Storage Instance {
            get {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }
        
        public List<User> listUsers = new List<User>();
        public User userLogin = new User();
        public PriorityQueue<Task> queueTask = new PriorityQueue<Task>();
        public HashTable<Task> hashTable = new HashTable<Task>();

    }
}