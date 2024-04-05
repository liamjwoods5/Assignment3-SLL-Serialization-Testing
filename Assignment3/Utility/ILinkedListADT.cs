using System;

namespace Assignment3
{
    /*
     * Author: Liam Woods, Syndey Woods
     * Date: Aprul 4th 2024
     * 
     * This program is a part of Assignment3
     * The ILinkedListADT interface, defined in this file, declares the methods that a linked list should have, such as Add, Remove, and GetValue.
     * The SLL class implements these methods. The User class represents the data stored in each node of the linked list.
     * The program also includes functionality for serializing the linked list to a file and deserializing it back from the file.
     * The SerializationTests class contains unit tests for the linked list operations and the serialization/deserialization functionality.
     */
    public interface ILinkedListADT
    {
        Node head { get; }

        //ILinkedListADT Methods
        void AddFirst(User value);
        void AddLast(User value);
        void Remove(int index);
        void RemoveFirst();
        void RemoveLast();
        void Add(User value, int index);
        void Replace(User value, int index);
        User GetValue(int index);
        int IndexOf(User value);
        bool Contains(User value);
        void Clear();
        int Count();
        bool IsEmpty();
        void JoinLists(ILinkedListADT secondList);
    }

    public class ILinkedListADTMethods : ILinkedListADT
    {
        public Node head { get; set; }


        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
        }



        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }



        public void Remove(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            if (index == 0)
            {
                head = head.Next;
                return;
            }
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }



        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            head = head.Next;
        }



        public void RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        }



        public void Add(User value, int index)
        {
            if (index < 0 || index > Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            Node newNode = new Node(value);
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }



        public void Replace(User value, int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }



        public User GetValue(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }



        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }



        public bool Contains(User value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }



        public void Clear()
        {
            head = null;
        }



        public int Count()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }



        public bool IsEmpty()
        {
            return head == null;
        }



        public void JoinLists(ILinkedListADT secondList)
        {
            if (IsEmpty())
            {
                head = secondList.head;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = secondList.head;
            }
        }


    }
}
