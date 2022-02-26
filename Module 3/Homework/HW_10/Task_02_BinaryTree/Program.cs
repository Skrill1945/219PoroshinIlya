using System;
using System.Collections.Generic;

namespace Task_HW_BinaryTree
{
    class Node<T>
        where T : IComparable
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
        where T : IComparable
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

        public void Inorder(Node<T> root)
        {
            if (root == null)
                return;

            //traverse the left subtree
            Inorder(root.left);

            //visit the root
            Console.Write(root + " ");

            //traverse the right subtree
            Inorder(root.right);
        }

        public void Preorder(Node<T> root)
        {
            if (root == null)
                return;

            //visit the root
            Console.Write(root + " ");

            //traverse the left subtree
            Preorder(root.left);

            //traverse the right subtree
            Preorder(root.right);
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
            Console.Write(root + " ");
        }

        public void Cascade(Node<T> root)
        {
            Queue<Node<T>> nodesToPrint = new();
            nodesToPrint.Enqueue(root);
            while (nodesToPrint.Count > 0)
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

        public void Print()
        {
            if (!IsEmpty)
                Inorder(root);
            else
                Console.WriteLine("Tree is empty");
        }

        public void Clear()
        {
            root = null;
        }

        public Node<T> Find(T value)
        {
            return Find(root, value);
        }

        private Node<T> Find(Node<T> root, T value)
        {
            if (root == null)
                return null;
            int res = root.value.CompareTo(value);
            if (res == 0)
                return root;
            else if (res >= 1)
                return Find(root.left, value);
            else
                return Find(root.right, value);
        }

        public void Delete(T val)
        {
            root = Delete(root, val);
        }

        T GetRightMin(Node<T> root)
        {
            Node<T> temp = root;

            //min value should be present in the left most node.
            while (temp.left != null)
                temp = temp.left;

            return temp.value;
        }

        private Node<T> Delete(Node<T> root, T val)
        {
            /* If the node becomes null, it will return null
            * Two possible ways which can trigger this case
            * 1. If we send the empty tree. i.e root == null
            * 2. If the given node is not present in the tree. */
            if (root == null)
                return null;
            /* If root.value < val. val must be present in the right subtree
             * So, call the above remove function with root.right */
            if (root.value.CompareTo(val) < 0)
                root.right = Delete(root.right, val);
            /* if root.value > val. val must be present in the left subtree
             * So, call the above function with root.left */
            else if (root.value.CompareTo(val) > 0)
                root.left = Delete(root.left, val);
            /* This part will be executed only if the root.value == val
             * The actual removal starts from here */
            else
            {
                /* Case 1: Leaf node. Both left and right reference is null
                 * replace the node with null by returning null to the calling pointer.*/
                if (root.left == null && root.right == null)
                {
                    return null;
                }
                /* Case 2: Node has right child.
                 * replace the root node with root.right */
                else if (root.left == null)
                {
                    return root.right;
                }
                /* Case 3: Node has left child.
                * replace the node with root.left */
                else if (root.right == null)
                {
                    return root.left;
                }
                /* Case 4: Node has both left and right children.
                 * Find the min value in the right subtree
                 * replace node value with min.
                 * And again call the remove function to delete the node which has the min value.
                 * Since we find the min value from the right subtree call the remove function with root.right. */
                else
                {
                    T rightMin = GetRightMin(root.right);
                    root.value = rightMin;
                    root.right = Delete(root.right, rightMin);
                }

            }
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedBinaryTree<int> binaryTree = new();
            binaryTree.Insert(100);
            binaryTree.Insert(50);
            binaryTree.Insert(200);
            binaryTree.Insert(150);
            binaryTree.Insert(300);
            binaryTree.Cascade(binaryTree.root);
            binaryTree.Delete(300);
            binaryTree.Cascade(binaryTree.root);
            binaryTree.Delete(100);
            binaryTree.Cascade(binaryTree.root);

            binaryTree.Insert(100);
            binaryTree.Insert(300);
            binaryTree.Insert(300);
            binaryTree.Cascade(binaryTree.root);

            binaryTree.Inorder(binaryTree.root);
            Console.WriteLine();
            binaryTree.Preorder(binaryTree.root);
            Console.WriteLine();
            binaryTree.Postorder(binaryTree.root);
            Console.WriteLine();
        }
    }
}
