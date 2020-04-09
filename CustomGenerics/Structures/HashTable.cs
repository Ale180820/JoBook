using CustomGenerics.Interfaces;
using System;
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
    public class HashTable<T> : IStructures<T>
    {
        protected override void Delete(T value)
        {
            throw new NotImplementedException();
        }

        protected override T Get()
        {
            throw new NotImplementedException();
        }

        protected override void Insert(T value)
        {
            throw new NotImplementedException();
        }
    }
}
