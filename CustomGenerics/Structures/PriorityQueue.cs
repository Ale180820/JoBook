using CustomGenerics.Interfaces;
using CustomGenerics.Structures;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace CustomGenerics.Structures 
{
    public class PriorityQueue<T> : IPriorityQueue<T>, IEnumerable<T>
    {
        Node<T> root = new Node<T>();
   
        public void EnqueueTask(T value, Comparison<T> comparison){
            Enqueue(value, comparison);
        }

        public T DequeueTask(T value, Comparison<T> comparison) {
            return Dequeue(value, comparison);
        }

        public T PeekTask() {
            return peek();
        }



        IEnumerator IEnumerable.GetEnumerator(){
            throw new NotImplementedException();
        }

        protected override void Enqueue(T value, Comparison<T> comparison) {
            this.root.AddNode(root, value, comparison,(root.level()));
            root.levelCompleted = 0;
        }

        protected override T Dequeue(T value, Comparison<T> comparison) {
            T dequeueNode = root.getNodeValue();
            if (root.getLeftNode().getNodeValue() != null && root.getRightNode().getNodeValue() != null) {
                root.setNodeValue(root.DeleteLastNode(root, root.level()).getNodeValue());
                T auxRoot = root.getNodeValue();
                root.downChange(root, auxRoot, comparison);
                root.setNodeValue(root.getNodeValue());
            }
            else {
                root = null;
            }
            return root.getNodeValue();
        }

        public List<T> showTask() {
            return root.values;
        }



        protected override T peek() {
            return root.getNodeValue();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }
}
