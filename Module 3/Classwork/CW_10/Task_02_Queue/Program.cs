using System;

namespace Task_02_Queue
{
    class Node<T>
    {
        public T value;
        public Node<T> next;

        public Node(T value, Node<T> next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

    class Queue<T>
    {
        Node<T> firstNode = null;
        Node<T> lastNode = null;
        public int Size { get; private set; } = 0;
        public bool IsEmpty { get => firstNode == null; }

        public void Enqueue(T value)
        {
            Node<T> temp = new Node<T>(value);
            Size++;
            if (firstNode == null)
            {
                firstNode = temp;
            }
            if (lastNode == null)
            {
                lastNode = temp;
            } 
            else 
            {
                lastNode.next = temp;
                lastNode = temp; 
            }
        }

        public T Dequeue()
        {
            if (firstNode == null)
            {
                throw new NullReferenceException("Queue is empty");
            }
            T value = firstNode.value;
            firstNode = firstNode.next;
            if (firstNode == null)
            {
                lastNode = null;
            }
            Size--;
            return value;
        }

        public T Top()
        {
            if (firstNode == null)
            {
                throw new NullReferenceException("Queue is empty");
            }
            T value = firstNode.value;
            return value;
        }
    }

    struct Person
    {
        string name;
        string surname;
        int age;

        public Person(string n, string s, int a)
        {
            name = n;
            surname = s;
            age = a;
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
