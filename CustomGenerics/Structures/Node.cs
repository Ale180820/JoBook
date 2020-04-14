using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomGenerics.Structures
{
    class Node<T>{

        //    public int priority { get; set; }
        //    public T value { get; set; }

        //    private Node<T> leftNode;
        //    private Node<T> rightNode;
        //    private T valueNode;
        //    int heapSize = 10;


        //    //Constructor method.
        //    public Node<T> newNode(T value)
        //    {
        //        Node<T> node = new Node<T>();
        //        this.valueNode = value;
        //        this.leftNode = null;
        //        this.rightNode = null;
        //        return node;
        //    }

        //    public void inOrden(Node<T> auxiliar)
        //    {
        //        if (auxiliar != null) {
        //            inOrden(auxiliar.getLeftNode());
        //            auxiliar.getValue();
        //            inOrden(auxiliar.getRightNode());   
        //        }

        //    }
        //    public void preOrden(Node<T> auxiliar)
        //    {
        //        if (auxiliar != null) {
        //            auxiliar.getValue();
        //            preOrden(auxiliar.getLeftNode());
        //            preOrden(auxiliar.getRightNode());
        //        }
        //    }

        //    public void convertNode(Node<T> root) {
        //        inOrden(root);
        //        preOrden(root);
        //    }

        //    //Method for delete node. 
        //    public Node<T> deleteNode(Node<T> aux, T data, Comparison<T> comparison)
        //    {
        //        if (aux == null)
        //        {
        //            return null;
        //        }
        //        else if (comparison.Invoke(data, aux.getValue()) < 0)
        //        {
        //            Node<T> leftN = deleteNode(aux.getLeftNode(), data, comparison);
        //            aux.setLeftNode(leftN);
        //        }
        //        else if (comparison.Invoke(data, aux.getValue()) > 0)
        //        {
        //            Node<T> rightN = deleteNode(aux.getRightNode(), data, comparison);
        //            aux.setRightNode(rightN);
        //        }
        //        else
        //        {
        //            Node<T> prev = aux;
        //            if (prev.getRightNode() == null)
        //            {
        //                aux = prev.getLeftNode();
        //            }
        //            else if (prev.getLeftNode() == null)
        //            {
        //                aux = prev.getRightNode();
        //            }
        //            else
        //            {
        //                prev = changeNode(prev);
        //            }
        //            prev = null;
        //        }
        //        return aux;
        //    }

        //    //Method for change node. 
        //    protected void changeWithParents(int Child)
        //    {
        //        Node<T> prev = aux;
        //        Node<T> anterior = aux.getLeftNode();
        //        while (anterior.getRightNode() != null)
        //        {
        //            prev = anterior;
        //            anterior = anterior.getRightNode();
        //        }
        //        aux.setValue(anterior.getValue());
        //        if (prev == aux)
        //        {
        //            prev.setLeftNode(anterior.getLeftNode());
        //        }
        //        else
        //        {
        //            prev.setRightNode(anterior.getLeftNode());
        //        }
        //        return anterior;
        //    }

        //    public T vistNode()
        //    {
        //        if (this.leftNode != null)
        //        {
        //            this.leftNode.vistNode();
        //        }
        //        if (this.rightNode != null)
        //        {
        //            this.rightNode.vistNode();
        //        }
        //        return this.getValue();
        //    }

        //    //Method for add node in tree
        //    public Node<T> addNode(Node<T> root, Comparison<T> comparison, T value)
        //    {
        //        if(root == null) {
        //            return newNode(value);
        //        }
        //        if (comparison.Invoke(root.getValue(), this.getValue()) < 0) {
        //            root.leftNode = addNode(root.leftNode, comparison, value);

        //        }
        //        else {
        //            root.rightNode = addNode(root.rightNode, comparison, value);
        //        }
        //        return root;
        //    }

        //    //Method for find element in tree
        //    public T findNode(T value, Comparison<T> comparison)
        //    {
        //        if (this.getValue().Equals(value))
        //        {
        //            return this.valueNode;
        //        }
        //        else if ((comparison.Invoke(value, this.valueNode) < 0))
        //        {
        //            return this.leftNode.findNode(value, comparison);
        //        }
        //        else if ((comparison.Invoke(value, this.valueNode) > 0))
        //        {
        //            return this.rightNode.findNode(value, comparison);
        //        }
        //        return this.valueNode;
        //    }



        //    //Node Value
        //    public void setValue(T value) {
        //        valueNode = value;
        //    }
        //    public T getValue() {
        //        return valueNode;
        //    }
        //    //Left Node
        //    public void setLeftNode(Node<T> leftValue) {
        //        leftNode = leftValue;
        //    }
        //    public Node<T> getLeftNode() {
        //        return leftNode;
        //    }
        //    //Right Node
        //    public void setRightNode(Node<T> rightValue) {
        //        rightNode = rightValue;
        //    }
        //    public Node<T> getRightNode() {
        //        return rightNode;
        //    }
        //    //Left Child's number
        //    public static int getLeftNode(int rootPosition) {
        //        return (2 * (rootPosition));
        //    }
        //    //Right Child's number
        //    public static int getRightNode(int rootPosition) {
        //        return (2 * (rootPosition + 1));
        //    }
        private Node<T> root;
        private Node<T> leftNode;
        private Node<T> rightNode;
        private T valueNode;
        int numberNodes = 0;
        int position = 0;

        //Constructor method.
        public Node(T value) {
            this.valueNode = value;
            this.rightNode = null;
            this.leftNode = null;
            this.position = numberNodes;

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


        public Node<T> DeleteNode(Node<T> root) {
            Node<T> aux = root;
            bool findWay = true;
            int maxNodes = numberNodes;
            
            while(aux.position != maxNodes)
            {
                if (maxNodes / 2 <= 5 && findWay) {
                    findWay = false;
                    DeleteNode(aux.leftNode);
                }
                else {
                    DeleteNode(aux.rightNode);
                }
                if (nodeHasChild(aux) == 0) {
                    DeleteNode(aux.rightNode);
                }
                else if(nodeHasChild(aux)==1){
                    DeleteNode(aux.leftNode);
                }
                else if(aux.leftNode != null && aux.rightNode == null){
                    root = aux.leftNode;
                    aux = null;
                }
                else {
                    root = aux.rightNode;
                    aux = null;
                }
            }
            numberNodes--;
            return root;
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
