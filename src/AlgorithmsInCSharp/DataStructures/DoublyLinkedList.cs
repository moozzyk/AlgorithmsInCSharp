using System;

namespace AlgorithmsInCSharp.DataStructures
{
    public class DoublyLinkedList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node _head;
        private Node _tail;

        public Node Head { get { return _head; } }
        public Node Tail { get { return _tail; } }

        public void Insert(T value)
        {
            var node = new Node
                {
                    Value = value,
                    Next = _head,
                    Previous = null
                };

            if (node.Next != null)
            {
                node.Next.Previous = node;
            }
            else
            {
                _tail = node;
            }

            _head = node;
        }

        public void Append(T value)
        {
            var node = new Node
                {
                    Value = value,
                    Previous = _tail,
                    Next = null
                };

             if (node.Previous != null)
             {
                 node.Previous.Next = node;
             }
             else
             {
                 _head = node;
             }

             _tail = node;
        }

        public void InsertBefore(Node node, T value)
        {
            if (node == _head)
            {
                Insert(value);
                return;
            }

            var newNode = new Node
                {
                    Value = value,
                    Previous = node.Previous,
                    Next = node
                };

            newNode.Previous.Next = newNode;
            newNode.Next.Previous = newNode;
        }

        public void InsertAfter(Node node, T value)
        {
            if (node == _tail)
            {
                Append(value);
                return;
            }

            var newNode = new Node
                {
                    Value = value,
                    Previous = node,
                    Next = node.Next
                };

            newNode.Previous.Next = newNode;
            newNode.Next.Previous = newNode;
        }

        public void Delete(Node node)
        {
            if (!NodeInList(node))
            {
                throw new ArgumentException("The node does not belong to this list.", nameof(node));
            }

            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            else
            {
                _head = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            else
            {
                _tail = node.Previous;
            }
        }

        private bool NodeInList(Node node)
        {
            for (var n = _head; n != null; n = n.Next)
            {
                if (n == node)
                {
                    return true;
                }
            }
            return false;
        }

        public Node Search(T value)
        {
            for (var node = Head; node != null; node = node.Next)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }
    }
}