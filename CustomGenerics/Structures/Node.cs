using System;
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
                upChange(root, ComparePriority);
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
                if ((numberNodes / (2 ^ (initialLevel - 1))) % 2 == 0) {
                     DeleteNode(lastNode.leftNode, initialLevel--);
                }
                else if ((numberNodes / (2 ^ (initialLevel-1))) % 2 == 1) {
                    DeleteNode(lastNode.rightNode, initialLevel--);
                }
            }
            lastNode = null;
            return aux.valueNode;
        }

        public int level() {
            return Convert.ToInt32((Math.Log(Math.E, Convert.ToDouble(numberNodes)))/Math.Log(Math.E, 2));
        }

        /// <summary>
        /// Change the node based in priority 
        /// </summary>
        /// <param name="nodeChange"></param>
        /// <param name="ComparePriority"></param>
        public void upChange(Node<T> nodeChange, Comparison<T> ComparePriority) {
            Node<T> nodeAux = nodeChange;
            if (nodeChange.leftNode.valueNode != null && nodeChange.rightNode.valueNode != null) {
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.leftNode.valueNode) > 0) {
                    nodeChange.valueNode = nodeChange.leftNode.valueNode;
                    nodeChange.leftNode.valueNode = nodeAux.valueNode;
                }
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.rightNode.valueNode) > 0) {
                    nodeChange.valueNode = nodeChange.rightNode.valueNode;
                    nodeChange.rightNode.valueNode = nodeAux.valueNode;
                }
            }
            else if(nodeChange.rightNode.valueNode == null){
                if (ComparePriority.Invoke(nodeChange.valueNode, nodeChange.leftNode.valueNode) > 0) {
                    nodeChange.valueNode = nodeChange.leftNode.valueNode;
                    nodeChange.leftNode.valueNode = nodeAux.valueNode;
                }
            }
        }
       
        /// <summary>
        /// Change the node since the root
        /// </summary>
        /// <param name="nodeChange"></param>
        /// <param name="ComparePriority"></param>
        public void downChange(Node<T> nodeChange, Comparison<T> ComparePriority) {
            Node<T> nodeAux = nodeChange;

            if (nodeChange.rightNode == null)
            {
                if (ComparePriority.Invoke(nodeChange.getNodeValue(), nodeChange.getLeftNode().getNodeValue()) < 0) {
                    nodeChange = nodeChange.leftNode;
                    nodeChange.leftNode = nodeAux;
                    downChange(nodeChange.leftNode, ComparePriority);
                }
            }
            else {
                if (ComparePriority.Invoke(nodeChange.getLeftNode().getNodeValue(), nodeChange.getRightNode().getNodeValue()) < 0) {
                    if (ComparePriority.Invoke(nodeChange.getNodeValue(), nodeChange.getRightNode().getNodeValue()) < 0) {
                        nodeChange = nodeChange.rightNode;
                        nodeChange.rightNode = nodeAux;
                        downChange(nodeChange.rightNode, ComparePriority);
                        
                    }
                }
                else if (ComparePriority.Invoke(nodeChange.getRightNode().getNodeValue(), nodeChange.getLeftNode().getNodeValue()) < 0) {
                    if (ComparePriority.Invoke(nodeChange.getNodeValue(), nodeChange.getLeftNode().getNodeValue()) < 0) {
                        nodeChange = nodeChange.leftNode;
                        nodeChange.leftNode = nodeAux;
                        downChange(nodeChange.leftNode, ComparePriority);
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
