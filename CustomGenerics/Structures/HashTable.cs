using CustomGenerics.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* @author: victorisimoo
* @version: 1.0.0
* @description: Class for HashTable Structure
*/


namespace CustomGenerics.Structures {
    public class HashTable<T> : IEnumerable<T> {

        private Stack<LinkedList<T>[]> table;
        private int sizeHashTable;

        public HashTable() {
            table = new Stack<LinkedList<T>[]>();
            sizeHashTable++; 
        }

        public int hashCode(T value){
            return (20 * value.GetHashCode()) % 5;
        }

        public bool put(T key, T value) {
            int hash = hashCode(key);
            if (table.Peek()[hash] == null) {
                table.Peek()[hash] = new LinkedList<T>();
                table.Peek()[hash].AddFirst(value);
                return true;
            }else {
                return false;
            }
        }

        public T get(T key){
            if (table.Count == 0){ return default(T);}
            try {
                return table.Peek()[hashCode(key)].First();
            }catch {
                return default(T);
            }
        }

        public void getAllValues(){
            for (int i  = 0; i < table.Count; i++){
                table.Peek()[i].First();
            }
        }

        //Interface method
        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        //Interface method
        public IEnumerator<T> GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}
