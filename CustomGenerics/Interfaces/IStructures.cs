using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * @author: Victor Noe Hernández
 * @version: 1.0.0
 * @description: class for ILenearDataStructure
 */

namespace CustomGenerics.Interfaces {
    public abstract class IStructures <T> {

        protected abstract void Insert(T value);
        protected abstract void Delete(T value);
        protected abstract T Get();
    }

    public abstract class IPriorityQueue <T>
    {
        protected abstract void Enqueue(T value, Comparison<T> comparison);
        protected abstract T Dequeue(T value, Comparison<T> comparison);
        protected abstract T peek();
    }

}
