using CustomGenerics.Interfaces;
using CustomGenerics.Structures;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace CustomGenerics.Structures 
{
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        Node<T> root = new Node<T>();
        
        /// <summary>
        /// Add element in the priority queue
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparison"></param>
        public void EnqueueTask(T value, Comparison<T> comparison){
            Enqueue(value, comparison);
        }
        
        /// <summary>
        /// Return the root and removes it
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public T DequeueTask(T value, Comparison<T> comparison) {
            return Dequeue(value, comparison);
        }

        /// <summary>
        /// Returns the element with the highest priority
        /// </summary>
        /// <returns></returns>
        public T PeekTask() {
            return peek();
        }

        protected override void Enqueue(T value, Comparison<T> comparison) {
            this.root.AddNode(root, value, comparison);
        }
        protected override T Dequeue(T value, Comparison<T> comparison) {
            T dequeueNode = root.getNodeValue();
            root.setNodeValue(root.DeleteNode(root, root.level()));
            root.downChange(root, comparison);
            return dequeueNode;
        }

        protected override T peek() {
            return root.getNodeValue();
        }

    }
}
