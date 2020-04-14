using CustomGenerics.Interfaces;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace CustomGenerics.Structures
{
    public class PriorityQueue<T>
    {
        Node<T> root = new Node<T>();
        

        public void Enqueue(T value, )
        {
            if(root == null)
            {
                root == value;
            }
            else
            {
                this.root.add
            }

        }















        class Node<T> {
            public int priority { get; set; }
            public T value { get; set; }
        }
        public void MaxHeap(int key)
        {
            while (key >= 0 && coladeprioridad[(key - 1) / 2].priority < coladeprioridad[key].priority) {
                changeNode(key, (key - 1) / 2);
                key = (key - 1) / 2;
            }
        }

        public void MinHeap(int key)
        {
            while (key >= 0 && coladeprioridad[(key - 1) / 2].priority > coladeprioridad[key].priority) {
                changeNode(key, (key - 1) / 2);
                key = (key - 1) / 2;
            }
        }

        List<Node<T>> coladeprioridad = new List<Node<T>>();
        int size = -1;
        bool minPriority;
        public int Count {
            get
            {
                return coladeprioridad.Count;
            }
        }
        public PriorityQueue(bool minPriority) {
            minPriority = false;
            this.minPriority = minPriority;
        }
        //Enqueue node
        public void Enqueue(int priority, T value) {
            Node<T> newNode = new Node<T>() {
                priority = priority,
                value = value
            };
        }
        public T Dequeue()
        {
            if (size > -1) {
                var valueRet = coladeprioridad[0].value;
                coladeprioridad[0] = coladeprioridad[size];
                coladeprioridad.RemoveAt(size);
                size = size - 1;
                if (minPriority) {
                    minHeap(0);
                }
                else {
                    maxHeap(0);
                }
                return valueRet;
            }
            return default(T);
        }

        public T peek() { 
            if(coladeprioridad.Count != 0)
            {
                return coladeprioridad[0].value;
            }
            else {
                return default(T);
            }
        }

        public void maxHeap(int key)
        {
            int leftNode, rightNode, upMost;
            leftNode = getLeftNode(key);
            rightNode = getRightNode(key);
            upMost = key;

            if ((leftNode <= size) && (coladeprioridad[upMost].priority) <
                (coladeprioridad[leftNode].priority))
            {
                upMost = leftNode;
            }
            else if ((rightNode <= size) && (coladeprioridad[upMost].priority) <
                (coladeprioridad[rightNode].priority))
            {
                upMost = leftNode;
            }
            else if (upMost != key)
            {
                changeNode(upMost, key);
                maxHeap(upMost);
            }
        }

        public void minHeap(int key)
        {
            int leftNode, rightNode, downMost;
            leftNode = getLeftNode(key);
            rightNode = getRightNode(key);
            downMost = key;
            if ((leftNode <= size) && (coladeprioridad[downMost].priority) <
                (coladeprioridad[leftNode].priority))
            {
                downMost = leftNode;
            }
            else if ((rightNode <= size) && (coladeprioridad[downMost].priority) <
                (coladeprioridad[rightNode].priority))
            {
                downMost = leftNode;
            }
            else if (downMost != key)
            {
                changeNode(downMost, key);
                minHeap(downMost);
            }
        }

        public void changeNode(int before, int after)
        {
            var aux = coladeprioridad[before];
            coladeprioridad[before] = coladeprioridad[after];
            coladeprioridad[after] = aux;
        }

        public void updatePriority(T value, int priority)
        {
            int i = 0;
            for (; i <= size; i++)
            {
                Node<T> newNode = coladeprioridad[i];
                if (object.ReferenceEquals(newNode.value, value)) {
                    newNode.priority = priority;
                    if (minPriority) {
                        MinHeap(i);
                        minHeap(i);
                    }
                    else {
                        MaxHeap(i);
                        maxHeap(i);
                    }
                }
            }
        }

        private Node<T> root = new Node<T>();
        private Node<T> lastNode = new Node<T>();

        public bool isEmpty()
        {
            if (size == 0) return true;
            return false;
        }
        //Left Child's number
        public static int getLeftNode(int rootPosition)
        {
            return (2 * (rootPosition));
        }
        //Right Child's number
        public static int getRightNode(int rootPosition)
        {
            return (2 * (rootPosition + 1));
        }
    }
}
