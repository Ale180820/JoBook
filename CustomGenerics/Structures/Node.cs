﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomGenerics.Structures {

    class Node<T>{

        private Node<T> root;
        private Node<T> leftNode;
        private Node<T> rightNode;
        private T valueNode;
        int numberNodes = 0;
        int position = 0;
        int levelCompleted = 0;
        int nodesInLevel = 0;

        //Constructor method.
        public Node(T value) {
            this.valueNode = value;
            this.rightNode = null;
            this.leftNode = null;
            this.position = numberNodes;
        }
        public Node(){}
        
        /// <summary>
        /// Add node in the queue
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <param name="ComparePriority"></param>
        public void AddNode(Node<T> root, T value, Comparison<T> ComparePriority) {
            if (root.valueNode == null) {
                root.valueNode = value;
                root.leftNode = new Node<T>();
                root.rightNode = new Node<T>();
                numberNodes++;
                nodesInLevel++;
                root.position = numberNodes;
            }
            else if (root.leftNode.valueNode == null && root.rightNode.valueNode == null) {
                AddNode(root.leftNode, value, ComparePriority);
            }
            else if(root.leftNode.valueNode != null && root.rightNode.valueNode == null){
                AddNode(root.rightNode, value, ComparePriority);
            }
            else {
                if (nodeHasChild(root.leftNode) == 1) {
                    if(nodeHasChild(root.rightNode)== 1) {
                        AddNode(root.leftNode, value, ComparePriority);
                    }
                    else {
                        AddNode(root.rightNode, value, ComparePriority);
                    }     
                }
                else {
                    AddNode(root.leftNode, value, ComparePriority);
                }
            }

            if (root.leftNode.valueNode != null || root.rightNode.valueNode != null) {
                T val = root.valueNode;
                upChange(root, val, ComparePriority);
            }
        }
        /// <summary>
        /// Checks if the node has children
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int nodeHasChild(Node<T> node) {
            if(node.leftNode.valueNode != null && node.rightNode.valueNode != null) {
                return 1;
            }
            else {
                return 0;
            }  
        }

        
        /// <summary>
        /// Delete the last node in the queue 
        /// </summary>
        /// <param name="lastNode"></param>
        /// <param name="initialLevel"></param>
        /// <returns></returns>
        public T DeleteNode(Node<T> lastNode, int initialLevel) {
            Node<T> aux = lastNode;
            while(lastNode != null && lastNode.position != numberNodes && initialLevel >= 1) { 
                if ((numberNodes / (Math.Pow((initialLevel - 1),2))) % 2 == 0) {
                     DeleteNode(lastNode.leftNode, initialLevel--);
                } else if ((numberNodes / (Math.Pow((initialLevel - 1), 2))) % 2 == 1) {
                    DeleteNode(lastNode.rightNode, initialLevel--);
                }
            }
            lastNode.valueNode = default(T);
            return aux.valueNode;
        }
        public List<T> showValues(Node<T> lastNode, int initialLevel)
        {
            Node<T> aux = lastNode;
            List<T> values = new List<T>();
            while (lastNode != null && lastNode.position != numberNodes && initialLevel >= 1)
            {
                if ((numberNodes / (Math.Pow((initialLevel - 1), 2))) % 2 == 0)
                {
                    values.Add(lastNode.leftNode.valueNode);
                    DeleteNode(lastNode.leftNode, initialLevel--);
                }
                else if ((numberNodes / (Math.Pow((initialLevel - 1), 2))) % 2 == 1)
                {
                    values.Add(lastNode.rightNode.valueNode);
                    DeleteNode(lastNode.rightNode, initialLevel--);
                }
            }
            return values;
        }
        public int level() {
            if ((Math.Pow(levelCompleted,2) == nodesInLevel)) {
                nodesInLevel = nodesInLevel - 2 ^ levelCompleted;
                levelCompleted = +1;
            }
            return levelCompleted;
        }

        /// <summary>
        /// Change the node based in priority 
        /// </summary>
        /// <param name="nodeChange"></param>
        /// <param name="ComparePriority"></param>
        public void upChange(Node<T> nodeChange, T original, Comparison<T> ComparePriority) {
            
            if (nodeHasChild(nodeChange) == 1)
            {
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.leftNode.valueNode) > 0)
                {
                    nodeChange.valueNode = nodeChange.leftNode.valueNode;
                    nodeChange.leftNode.valueNode = original;
                }
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.rightNode.valueNode) > 0) {
                    nodeChange.valueNode = nodeChange.rightNode.valueNode;
                    nodeChange.rightNode.valueNode = original;
                }
            }
            else if (nodeChange.rightNode.valueNode == null) {
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.leftNode.valueNode) > 0) {
                    nodeChange.valueNode = nodeChange.leftNode.valueNode;
                    nodeChange.leftNode.valueNode = original;
                }
            }
        }
       
        /// <summary>
        /// Change the node since the root
        /// </summary>
        /// <param name="nodeChange"></param>
        /// <param name="ComparePriority"></param>
        public void downChange(Node<T> nodeChange, T original, Comparison<T> ComparePriority) {
            if (nodeChange.leftNode.valueNode != null && nodeChange.rightNode.valueNode != null) {
                if (nodeChange.rightNode == null) {
                    if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.leftNode.valueNode) > 0) {
                        nodeChange.valueNode = nodeChange.leftNode.valueNode;
                        nodeChange.leftNode.valueNode = original;
                        downChange(nodeChange.leftNode, original, ComparePriority);
                    }
                } else {
                    if (ComparePriority.Invoke(nodeChange.leftNode.valueNode, nodeChange.rightNode.valueNode) > 0) {
                        if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.rightNode.valueNode) > 0) {
                            nodeChange.valueNode = nodeChange.rightNode.valueNode;
                            nodeChange.rightNode.valueNode = original;
                            downChange(nodeChange.rightNode, original, ComparePriority);

                        }
                    } else if (ComparePriority.Invoke(nodeChange.rightNode.valueNode, nodeChange.leftNode.valueNode) < 0) {
                        if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.leftNode.valueNode) < 0) {
                            nodeChange.valueNode = nodeChange.leftNode.valueNode;
                            nodeChange.leftNode.valueNode = original;
                            downChange(nodeChange.leftNode, original, ComparePriority);
                        }
                    }
                }
            }
        }

        //Node's value
        public void setNodeValue(T nodeValue) {
            this.valueNode = nodeValue;
        }
        public T getNodeValue() {
            return this.valueNode;
        }

        //Left Node's value
        public void setLeftNode(Node<T> leftNode) {
            this.leftNode = leftNode;
        }
        public Node<T> getLeftNode() {
            return this.leftNode;
        }

        //Right Node's value
        public void setRightNode(Node<T> rightNode) {
            this.rightNode = rightNode;
        }
        public Node<T> getRightNode() {
            return this.leftNode;
        }
    }
}
