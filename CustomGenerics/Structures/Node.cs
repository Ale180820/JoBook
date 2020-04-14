﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomGenerics.Structures
{
    class Node<T>{

        private Node<T> root;
        private Node<T> leftNode;
        private Node<T> rightNode;
        private T valueNode;
        int numberNodes = 0;
        int position = 0;
        int levelComplete = 0;

        //Constructor method.
        public Node(T value) {
            this.valueNode = value;
            this.rightNode = null;
            this.leftNode = null;
            this.position = numberNodes;

        }

        public Node()
        {
        }

        //Add node's method
        public void AddNode(Node<T> root, T value, Comparison<T> ComparePriority) {
            if (root.valueNode == null) {
                root.valueNode = value;
                numberNodes++;
                root.position = numberNodes;
            }
            else if (nodeHasChild(root) == 1) {
                AddNode(root.leftNode, value, ComparePriority);
            }
            else if(nodeHasChild(root) == 0) {
                AddNode(root.rightNode, value, ComparePriority);
            }
            if(root.leftNode != null || root.rightNode != null) {
                upChange(root, ComparePriority);
            }
        }        
        public int nodeHasChild(Node<T> node) {
            if(node.getLeftNode() == null && node.getRightNode() == null) {
                return 0;
            }
            else {
                return 1;
            }  
        }


        public Node<T> DeleteNode(Node<T> rot, Node<T> lastNode, int initialLevel) {
            T aux = lastNode.valueNode;
            while(lastNode != null && lastNode.position == numberNodes && initialLevel >= 1) {
                if ((numberNodes / (2 ^ (initialLevel - 1))) % 2 == 0) {
                     initialLevel--;
                     DeleteNode(lastNode.leftNode, initialLevel - 1);
                }
                else if ((numberNodes / (2 ^ (initialLevel))) % 2 == 1) {
                    initialLevel--;
                    DeleteNode(lastNode.rightNode, initialLevel);
                }
            }
            
        }

        public int level() {
            return Convert.ToInt32((Math.Log(Math.E, Convert.ToDouble(numberNodes)))/Math.Log(Math.E, 2));
        }


        //Change the node based in priority
        public void upChange(Node<T> nodeChange, Comparison<T> ComparePriority) {
            Node<T> nodeAux = nodeChange;
            if (ComparePriority.Invoke(nodeChange.getNodeValue(), nodeChange.getLeftNode().getNodeValue()) < 0) {
                nodeChange = nodeChange.leftNode;
                nodeChange.leftNode = nodeAux;
            }
            else if (ComparePriority.Invoke(nodeChange.getNodeValue(), nodeChange.getRightNode().getNodeValue()) < 0) {
                nodeChange = nodeChange.rightNode;
                nodeChange.rightNode = nodeAux;
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
