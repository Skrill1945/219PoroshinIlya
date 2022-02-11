using System;

namespace CW_10
{
    class Node<T>
    {
        public T value;
        public Node<T> prev;

        public Node(T value, Node<T> prev)
        {
            this.value = value;
            this.prev = prev;
        }
    }

    class Stack<T>
    {
        Node<T> curNode = null;

        public void Push(T value)
        {
            curNode = new Node<T>(value, curNode);
        }

        public T Pop()
        {
            T value = curNode.value;
            curNode = curNode.prev;
            return value;
        }

        public void Clear()
        {
            curNode = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
