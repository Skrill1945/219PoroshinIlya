using System;
using System.Collections.Generic;

namespace Task_02_BinaryTree
{
    class Node<T>
        where T: IComparable
    {
        public T value;
        public int valueCount;
        public Node<T> left;
        public Node<T> right;

        public Node(T _value, Node<T> _left = null, Node<T> _right = null)
        {
            value = _value;
            valueCount = 1;
            left = _left;
            right = _right;
        }

        public void InsertValue(T newValue)
        {
            int res = newValue.CompareTo(value);
            if (res > 0)
            {
                if (right != null)
                    right.InsertValue(newValue);
                else
                    right = new Node<T>(newValue);
            }
            else if (res < 0)
            {
                if (left != null)
                    left.InsertValue(newValue);
                else
                    left = new Node<T>(newValue);
            }
            else
            {
                valueCount++;
            }
        }

        public override string ToString()
        {
            return $"{value}->{valueCount}";
        }
    }

    class SortedBinaryTree<T>
        where T: IComparable
    {
        public Node<T> root = null;
        public bool IsEmpty { get => root == null; }
        //метод Insert() для добавления в дерево нового значения;
        public void Insert(T value)
        {
            if (!IsEmpty)
                root.InsertValue(value);
            else
                root = new Node<T>(value);
        }

        //метод Preorder() выполняющий вывод в порядке слева направо значений из узлов, начиная с заданного;
        public void Preorder(Node<T> root)
        {
            if (root == null)
                return;

            //visit the root
            Console.WriteLine(root + " ");

            //traverse the left subtree
            Preorder(root.left);

            //traverse the right subtree
            Preorder(root.right);
        }
        
        public void Inorder(Node<T> root)
        {
            if (root == null)
                return;

            //traverse the left subtree
            Inorder(root.left);

            //visit the root
            Console.WriteLine(root + " ");

            //traverse the right subtree
            Inorder(root.right);
        }
        
        public void Postorder(Node<T> root)
        {
            if (root == null)
                return;

            //traverse the left subtree
            Postorder(root.left);

            //traverse the right subtree
            Postorder(root.right);

            //visit the root
            Console.WriteLine(root + " ");
        }

        public void Cascade(Node<T> rootNode)
        {
            Queue<Node<T>> nodesToPrint = new();
            nodesToPrint.Enqueue(rootNode);
            while(nodesToPrint.Count > 0)
            {
                Node<T> node = nodesToPrint.Dequeue();

                if (node.left != null)
                    nodesToPrint.Enqueue(node.left);

                if (node.right != null)
                    nodesToPrint.Enqueue(node.right);

                Console.Write(node + " ");
            }
            Console.WriteLine();
        }

        //метод Print() для печати дерева и свойство IsEmpty для проверки пустоты дерева.
        public void Print()
        {
            if (!IsEmpty)
                Inorder(root);
            else
                Console.WriteLine("Tree is empty");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedBinaryTree<int> binaryTree = new();
            binaryTree.Insert(100);
            binaryTree.Insert(200);
            binaryTree.Insert(50);
            binaryTree.Insert(75);
            binaryTree.Insert(125);
            binaryTree.Cascade(binaryTree.root);
            binaryTree.Inorder(binaryTree.root);
            binaryTree.Preorder(binaryTree.root);
            binaryTree.Postorder(binaryTree.root);
        }
    }
}
