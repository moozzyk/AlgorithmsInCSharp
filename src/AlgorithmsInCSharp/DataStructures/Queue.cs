using System;

namespace AlgorithmsInCSharp.DataStructures
{
    public class Queue<T>
    {
        private T[] _values;
        int _head;
        int _tail;

        public Queue(int size)
        {
            _values = new T[size + 1];
        }

        public void Enqueue(T value)
        {
            if ((_tail + 1) % _values.Length == _head)
            {
                throw new InvalidOperationException("Queue is full.");
            }

            _values[_tail] = value;
            _tail = (_tail + 1) % _values.Length;
        }

        public T Dequeue()
        {
            if (_head == _tail)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var value = _values[_head];
            _head = (_head + 1) % _values.Length;
            return value;
        }
    }
}