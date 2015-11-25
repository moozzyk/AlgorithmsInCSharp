namespace AlgorithmsInCSharp.DataStructures
{
    public class LinkedList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node _head;

        public Node Head { get { return _head; } }

        public void Insert(T value)
        {
            var node = new Node
                {
                    Value = value,
                    Next = _head
                };

            _head = node;
        }

        public Node Delete(Node node)
        {
            if (node == Head)
            {
                _head = node.Next;
                return node;
            }

            var previousNode = Head;
            while (previousNode.Next != null)
            {
                if (previousNode.Next == node)
                {
                    previousNode.Next = node.Next;
                    return node;
                }

                previousNode = previousNode.Next;
            }

            return null;
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