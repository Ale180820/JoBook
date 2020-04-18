using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Interfaces
{
    public abstract class DataStructures<T> {
        protected abstract void enqueueValue(T value, Comparison<T> comparison);
        protected abstract T deleteValue(T value, Comparison<T> comparison);
    }
}
