using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    class Node<T>{

        private Node<T> rightNode;
        private Node<T> leftNode;
        int height, weight, priority, level;
        private T valueNode;

        private int getHeight(Node<T> node)
        {
            int left, right;
            left = node.leftNode != null ? node.leftNode.height : -1;
            right = node.rightNode != null ? node.rightNode.height : -1;
            node.weight = left - right;
            node.height = (right > left ? right : left) + 1;
            return node.height;
        }

        public void addNode(Node<T> newNode, Comparison<T> comparison)
        {
            if (height < 0)
            {
                if (this.leftNode == null || level % 2 != 0) {
                    this.leftNode = newNode;
                }
                else {
                    this.leftNode.addNode(newNode, comparison);
                }
            }
            else if (height > 0)
            {
                if (rightNode == null || level % 2 == 0) {
                    this.rightNode = newNode;
                }
                else {
                    this.rightNode.addNode(newNode, comparison);
                }
            }
           
        }

        
    }
}
