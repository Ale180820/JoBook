using System;
using System.Collections;
using System.Collections.Generic;

/*
* @author: victorisimoo
* @version: 1.0.0
* @description: Class for HashTable Structure
*/

namespace CustomGenerics.Structures {

    public class HashTable<T> : IEnumerable<T> {

        private class HashEntry<T> {

            public string key;
            public List<T> value = new List<T>();
            public  bool isDeleted = false;

            public HashEntry(String insertKey, T insertValue) {
                key = insertKey;
                value.Add(insertValue);
            }

            public bool IsDeleted(){
                return isDeleted;
            }

            public List<T> returnValue(){
                return value;
            }
        }

        private int[] SIZES = { 50, 100, 300 };
        private int sizeIdx = 0;
        private HashEntry<T>[] table;
        private int numEntries, numFilledSlots, numProbes = 0;

        public HashTable() {
            table = new HashEntry<T>[SIZES[sizeIdx]];
        }

        private void increaseCapacity(){
            HashEntry<T>[] oldTable = table;
            table = new HashEntry<T>[SIZES[++sizeIdx]];
            for (int i = 0; i < oldTable.Length; ++i) {
                if (oldTable[i] != null && !oldTable[i].IsDeleted()){
                    foreach (T value in oldTable[i].returnValue()){
                        insert(oldTable[i].key, value);
                    }
                }
            }
        }

        public bool insert(String key, T value){
            int size = SIZES[sizeIdx];
            int iteration = 0;
            numProbes = 0;
            if (numFilledSlots > 0.75 * size){
                increaseCapacity();
                size = SIZES[sizeIdx];
            }

            for (int i = 0; i < size; ++i){
                int index = probe(key, iteration, size);
                if (table[index] == null || table[index].IsDeleted()){
                    table[index] = new HashEntry<T>(key, value);
                    ++numEntries;
                    ++numFilledSlots;
                    numProbes = i;
                    return true;
                }else if (table[index].key.Equals(key) && !table[index].IsDeleted()){
                    table[index].value.Add(value);
                    ++numEntries;
                    numProbes = i;
                    return true;
                }
            }
            numProbes = iteration - 1;
            return false;
        }

        private int probe(String key, int iteration, int size) {
            return (hash(key) + ((int)(Math.Pow(iteration, 2) + iteration) >> 2)) % size;
        }

        public int hash(String key) {
            int hashValue = 0;
            for (int pos = 0; pos < key.Length; ++pos) {
                hashValue = (hashValue << 4) + key.Substring(pos).GetHashCode();
                int highBits = hashValue;
                if (highBits != 0){
                    hashValue ^= highBits >> 24;
                }
                hashValue &= ~highBits;
            }
            return hashValue;
        }
        
        public List<T> find(String key){
            int size = SIZES[sizeIdx];
            for (int i = 0; i < size; ++i){
                int index = probe(key, i, size);
                if (table[index] == null){
                    return null;
                }else if (table[index].key.Equals(key) && !table[index].IsDeleted())
                {
                    return table[index].value;
                }
            }
            return null;
        }

        public bool delete(String key) {
            int size = SIZES[sizeIdx];
            for (int i = 0; i < size; ++i) {
                int index = probe(key, i, size);
                if (table[index] == null){
                    return false;
                }else if (table[index].key.Equals(key) && !table[index].IsDeleted()){
                    table[index].isDeleted = true;
                    return true;
                }
            }
            return false;
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
