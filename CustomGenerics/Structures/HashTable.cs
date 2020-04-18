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
