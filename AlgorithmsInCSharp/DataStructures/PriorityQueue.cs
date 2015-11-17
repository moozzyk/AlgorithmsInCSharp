using System;

namespace AlgorithmsInCSharp.DataStructures
{
    public class PriorityQueue
    {
        private int[] _values = new int[8];
        private int _arraySize = 0;

        public void Insert(int value)
        {
            if (_arraySize == _values.Length)
            {
                var newValues = new int[_values.Length << 1];
                Array.Copy(_values, newValues, _values.Length);
                _values = newValues;
            }

            _arraySize++;
            _values[_arraySize - 1] = int.MinValue;
            IncreaseKey(_arraySize - 1, value);
        }

        public bool HasValues
        {
            get { return _arraySize > 0; }
        }

        public int Maximum
        {
            get
            {
                if (!HasValues)
                {
                    throw new InvalidOperationException("The queue is empty");
                }

                return _values[0];
            }
        }

        public int ExtractMax()
        {
            var max = Maximum;
            _values[0] = _values[_arraySize - 1];
            _arraySize--;
            Heap.MaxHeapifyIterative(_values, 0, _arraySize);
            return max;
        }

        public void IncreaseKey(int index, int value)
        {
            if (index >= _arraySize || index < 0)
            {
                throw new ArgumentException("Invalid index.", "index");
            }

            if (value < _values[index])
            {
                throw new ArgumentException("New value must be greater or equals than existing value.", "value");
            }

            _values[index] = value;
            while (index > 0 && _values[Heap.Parent(index)] < _values[index])
            {
                var parentIndex = Heap.Parent(index);
                var tmp = _values[parentIndex];
                _values[parentIndex] = _values[index];
                _values[index] = tmp;
                index = parentIndex;
            }
        }
    }
}