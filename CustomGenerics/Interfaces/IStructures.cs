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

    public abstract class IQueue <T>
    {
        protected abstract bool IsEmpty();
        protected abstract void Enqueue(T value);
        protected abstract T Dequeue();
        protected abstract T Peek();

        protected abstract void Swap(int leaf, int rootposition);
    }
}
