using CustomGenerics.Interfaces;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace CustomGenerics.Structures
{
    public class PriorityQueue<T>: IQueue<T> where T : IComparable<T>
    {
        private List<T> priorityQueue = new List<T>();
        protected override bool IsEmpty() {
            if(priorityQueue.Count != 0) {
                return false;
            }
            else {
                return true;
            }
        }

        protected override void Enqueue(T value) {
            priorityQueue.Add(value);
            int leafPosition = (priorityQueue.Count) - 1;
            int rootPosition = (leafPosition - 1) / 2;

            while (priorityQueue[leafPosition].CompareTo(priorityQueue[rootPosition]) < 0) {

                Swap(leafPosition, rootPosition);

                leafPosition = rootPosition;
                rootPosition = (leafPosition - 1) / 2;
            }
        }

        protected override T Dequeue() {
            if(priorityQueue.Count == 0) {
                return default(T);
            }
            else if(priorityQueue.Count == 1) {
                T aux = priorityQueue[0];
                priorityQueue.Remove(aux);
                return aux;
            }
            else {
                T ReturnValue = priorityQueue[0];
                T lastValue = priorityQueue[priorityQueue.Count - 1];
                priorityQueue.Remove(lastValue);
                priorityQueue[priorityQueue.IndexOf(priorityQueue[0])] = lastValue;

                int rootPosition = 0;
                bool flag = true;
                while (flag) {
                    int leftLeaf = 2 * rootPosition + 1;
                    int downMostLeaf = leftLeaf;
                    if(leftLeaf >= priorityQueue.Count) { break; }
                    int rightLeaf = leftLeaf + 1;
                    if((rightLeaf < priorityQueue.Count) && (priorityQueue[rightLeaf].CompareTo(priorityQueue[leftLeaf]) < 0)) {
                        downMostLeaf = rightLeaf;
                    }
                    if(priorityQueue[downMostLeaf].CompareTo(priorityQueue[rootPosition]) < 0) {

                        Swap(downMostLeaf, rootPosition);
                        rootPosition = downMostLeaf;
                    }
                    else { break; }
                }
                return ReturnValue;
            }
        }
        protected override T Peek()
        {
            if (!IsEmpty()) {
                return priorityQueue[0];
            }
            else {
                return default(T);
            }
        }
        protected override void Swap(int leaf, int rootPosition)
        {
            T valueAux = priorityQueue[leaf];
            priorityQueue[priorityQueue.IndexOf(valueAux)] = priorityQueue[rootPosition];
            priorityQueue[priorityQueue.IndexOf(priorityQueue[rootPosition])] = valueAux;
        }
        //class Node {
        //    public int priority { get; set; }
        //    public T value { get; set; }
        //}
        //public void MaxHeap(int key)
        //{
        //    while (key >= 0 && priorityQueue[(key - 1) / 2].priority < priorityQueue[key].priority) {
        //        changeNode(key, (key - 1) / 2);
        //        key = (key - 1) / 2;
        //    }
        //}

        //public void MinHeap(int key)
        //{
        //    while (key >= 0 && priorityQueue[(key - 1) / 2].priority > priorityQueue[key].priority)
        //    {
        //        changeNode(key, (key - 1) / 2);
        //        key = (key - 1) / 2;
        //    }
        //}

        //List<Node> priorityQueue = new List<Node>();
        //int size = -1;
        //bool minPriority;
        //public int Count {
        //    get {
        //        return priorityQueue.Count;
        //    }
        //}
        //public PriorityQueue(bool minPriority) {
        //    minPriority = false;
        //    this.minPriority = minPriority;
        //}
        ////Enqueue node
        //public void Enqueue(int priority, T value) {
        //    Node<T> newNode = new Node<T>() {
        //        priority = priority,
        //        value = value
        //    };
        //}
        //public T Dequeue()
        //{
        //    if (size > -1)
        //    {
        //        var valueRet = priorityQueue[0].value;
        //        priorityQueue[0] = priorityQueue[size];
        //        priorityQueue.RemoveAt(size);
        //        size = size - 1;
        //        if (minPriority) {
        //            minHeap(0);
        //        }
        //        else {
        //            maxHeap(0);
        //        }
        //        return valueRet;
        //    }
        //    return default(T);
        //}

        //public T peek()
        //{
        //    if (size > -1)
        //    {
        //        var valueRet = priorityQueue[0].value;
        //        priorityQueue[0] = priorityQueue[size];
        //        priorityQueue.RemoveAt(size);
        //        size = size - 1;
        //        if (minPriority)
        //        {
        //            minHeap(0);
        //        }
        //        else
        //        {
        //            maxHeap(0);
        //        }
        //        return valueRet;
        //    }
        //    return default(T);
        //}

        //public void maxHeap(int key) {
        //    int leftNode, rightNode, upMost;
        //    leftNode = getLeftNode(key);
        //    rightNode = getRightNode(key);
        //    upMost = key;

        //    if ((leftNode <= size) && (priorityQueue[upMost].priority) <
        //        (priorityQueue[leftNode].priority)) {
        //        upMost = leftNode;
        //    }
        //    else if ((rightNode <= size) && (priorityQueue[upMost].priority) <
        //        (priorityQueue[rightNode].priority)) {
        //        upMost = leftNode;
        //    }
        //    else if (upMost != key) {
        //        changeNode(upMost, key);
        //        maxHeap(upMost);
        //    }
        //}

        //public void minHeap(int key) {
        //    int leftNode, rightNode, downMost;
        //    leftNode = getLeftNode(key);
        //    rightNode = getRightNode(key);
        //    downMost = key;
        //    if ((leftNode <= size) && (priorityQueue[downMost].priority) <
        //        (priorityQueue[leftNode].priority))
        //    {
        //        downMost = leftNode;
        //    }
        //    else if ((rightNode <= size) && (priorityQueue[downMost].priority) <
        //        (priorityQueue[rightNode].priority))
        //    {
        //        downMost = leftNode;
        //    }
        //    else if (downMost != key) {
        //        changeNode(downMost, key);
        //        minHeap(downMost);
        //    }
        //}

        //public void changeNode(int before, int after) {
        //    var aux = priorityQueue[before];
        //    priorityQueue[before] = priorityQueue[after];
        //    priorityQueue[after] = aux;
        //}
        
        //private Node<T> root = new Node<T>();
        //private Node<T> lastNode = new Node<T>();

        //public bool isEmpty() {
        //    if (size == 0) return true;
        //    return false;
        //}
        ////Left Child's number
        //public static int getLeftNode(int rootPosition)
        //{
        //    return (2 * (rootPosition));
        //}
        ////Right Child's number
        //public static int getRightNode(int rootPosition)
        //{
        //    return (2 * (rootPosition + 1));
        //}
    }
}
