using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomGenerics.Structures {

    class Node<T>{

        private Node<T> leftNode;
        private Node<T> rightNode;
        public Node<T> aux;
        private T valueNode;
        public int numberNodes = 0;
        public int counter = 0;
        public int position = 0;
        public int levelCompleted = 0;

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
        public void AddNode(Node<T> root, T value, Comparison<T> ComparePriority, int initialLevel) {
            if (root.valueNode == null) {
                root.valueNode = value;
                root.leftNode = new Node<T>();
                root.rightNode = new Node<T>();
                numberNodes++;
                root.position = numberNodes;
            }
            else if (root.leftNode.valueNode == null && root.rightNode.valueNode == null) {
                AddNode(root.leftNode, value, ComparePriority, initialLevel);
            }
            else if(root.leftNode.valueNode != null && root.rightNode.valueNode == null){
                AddNode(root.rightNode, value, ComparePriority, initialLevel);
            }
            else {
                if(initialLevel > 1) {
                    if (((numberNodes + 1) / Convert.ToInt32(Math.Pow(2, (initialLevel-1))) % 2 == 0)) {
                        AddNode(root.leftNode, value, ComparePriority, --initialLevel);
                    }
                    else if (((numberNodes + 1) / Convert.ToInt32(Math.Pow(2, (initialLevel - 1))) % 2 == 1)) {
                        AddNode(root.rightNode, value, ComparePriority, --initialLevel);
                    }
                }
                else if(nodeHasChild(root) == 1) {
                    if(root.rightNode.valueNode == null) {
                        AddNode(root.leftNode, value, ComparePriority, initialLevel);
                    }
                    else {
                        AddNode(root.rightNode, value, ComparePriority, initialLevel);
                    }
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

        bool final = true;
        /// <summary>
        /// Delete the last node in the queue 
        /// </summary>
        /// <param name="lastNode"></param>
        /// <param name="initialLevel"></param>
        /// <returns></returns>
        public Node<T> DeleteLastNode(Node<T> lastNode, int initialLevel) {
            if(lastNode.leftNode.valueNode == null && lastNode.rightNode.valueNode == null) {
                return null;
            }
            Node<T> auxiliar = lastNode;
            while (auxiliar.position != auxiliar.numberNodes && initialLevel >= 1 && final)
            {
                if ((numberNodes / Convert.ToInt32(Math.Pow(2, (initialLevel - 1)))) % 2 == 0) {
                    --initialLevel;
                    auxiliar = auxiliar.getLeftNode();
                }
                else {
                    --initialLevel;
                    auxiliar = auxiliar.getRightNode();
                }
            }
            final = false;
            lastNode.valueNode = auxiliar.valueNode;

            if (lastNode.position != numberNodes && initialLevel >= 2) { 
                if ((numberNodes / Convert.ToInt32(Math.Pow(2, (initialLevel - 1)))) % 2 == 0) {
                    return DeleteLastNode(lastNode.leftNode, --initialLevel);
                }
                else {
                    return DeleteLastNode(lastNode.rightNode, --initialLevel);
                }
            }
            else {
                if(lastNode.rightNode == null) {
                    lastNode.leftNode = null;
                    return lastNode;
                }
                else {
                    lastNode.rightNode = null;
                    return lastNode;
                }
            }
            
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
                    showValues(lastNode.leftNode, --initialLevel);
                }
                else if ((numberNodes / (Math.Pow((initialLevel - 1), 2))) % 2 == 1)
                {
                    values.Add(lastNode.rightNode.valueNode);
                    showValues(lastNode.rightNode, --initialLevel);
                }
            }
            return values;
        }
        public int level() {
            int total = Convert.ToInt32(Math.Pow(2, levelCompleted));
            while (numberNodes >= total && numberNodes >= (total + Convert.ToInt32(Math.Pow(2, levelCompleted + 1)))) {
                total += Convert.ToInt32(Math.Pow(2, levelCompleted + 1));
                levelCompleted++;
            }
            return (levelCompleted+1);
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
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.rightNode.valueNode) > 0)
                {
                    nodeChange.valueNode = nodeChange.rightNode.valueNode;
                    nodeChange.rightNode.valueNode = original;
                }
            }
            else if (nodeChange.rightNode.valueNode == null) {
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.leftNode.valueNode) > 0)
                {
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
                if (nodeChange.rightNode.valueNode == null) {
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
            return this.rightNode;
        }
    }
}
