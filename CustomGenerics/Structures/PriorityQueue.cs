using System;
using CustomGenerics.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class PriorityQueue<T> : DataStructures<T>, IEnumerable<T>
    {
        private Node<T> root = new Node<T>();
        private int size, weight;
        public bool isEmpty() {
            if (size == 0) return true;
            return false;
        }

        protected override void enqueueValue(T value, Comparison<T> comparison)
        {
            Node<T> newNode = new Node<T>();
            if(size == 0)
            {
                
            }

        }

        protected override T deleteValue(T value, Comparison<T> comparison)
        {
            throw new NotImplementedException();
        }
    }
}
