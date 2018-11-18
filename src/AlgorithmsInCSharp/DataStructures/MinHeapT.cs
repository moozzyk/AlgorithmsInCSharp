using System;
using System.Collections.Generic;

namespace AlgorithmsInCSharp.DataStructures {
    public class MinHeap<T> where T: IComparable<T> {
        private readonly IList<T> _container;
        public MinHeap(int capacity = 128)
        {
            _container = new List<T>(capacity);
        }

        public void Insert(T item)
        {
            _container.Add(item);

            for (var i = _container.Count - 1; i > 0;)
            {
                var parentIndex = (i - 1) / 2;
                if (_container[i].CompareTo(_container[parentIndex]) < 0)
                {
                    Swap(_container, i, parentIndex);
                    i = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public T FindMin()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty");
            }
            return _container[0];
        }

        public void DeleteMin()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            _container[0] = _container[_container.Count - 1];
            _container.RemoveAt(_container.Count - 1);

            for (var i = 0; i < _container.Count; )
            {
                var childIndex = (i + 1) * 2 - 1;
                if (childIndex > Count - 1)
                {
                    break;
                }

                if (childIndex + 1 < Count - 1)
                {
                    if (_container[childIndex + 1].CompareTo(_container[childIndex]) < 0)
                    {
                        childIndex = childIndex + 1;
                    }
                }

                if (_container[i].CompareTo(_container[childIndex]) > 0)
                {
                    Swap(_container, i, childIndex);
                    i = childIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public int Count => _container.Count;

        public bool IsEmpty => Count == 0;

        private static void Swap(IList<T> container, int index1, int index2)
        {
            var item = container[index1];
            container[index1] = container[index2];
            container[index2] = item;
        }
    }
}
