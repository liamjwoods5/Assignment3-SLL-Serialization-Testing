using System;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        //•	The SLL class must implement an ILinkedListADT interface
        [DataMember]
        public Node head { get; private set; }
        public SLL()
        {
            head = null;
        }


        //method to add a node at the beginning of the list
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
        }

        //method to add a node at the end of the list
        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (head == null)
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


        //method to remove a node at a specific index
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


        //method to remove the first node
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty");
            }
            head = head.Next;
        }


        //method to remove the last node
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty");
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


        //method to add a node
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


        //method to replace a node
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


        //method to get the value of a node at a specific index
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
            return current.Data;
        }


        //method to find the index of a node
        public int IndexOf(User value)
        {
            if (Count() == 1 && head.Data.Equals(value))
            {
                return 0;
            }

            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }



        //method to check if a node is in the list
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


        //method to clear the list
        public void Clear()
        {
            head = null;
        }


        //method to count the number of nodes in the list
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


        //method to check if the list is empty
        public bool IsEmpty()
        {
            return head == null;
        }


        //method to join two lists
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
