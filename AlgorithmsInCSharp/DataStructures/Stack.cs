namespace AlgorithmsInCSharp.DataStructures
{
    public class Stack<T>
    {
        private T[] _values;
        private int _top;

        public Stack(int size)
        {
            _values = new T[size];
        }

        public bool IsEmpty { get { return _top == 0; } }

        public void Push(T value)
        {
            _values[_top++] = value;
        }

        public T Pop()
        {
            return _values[--_top];
        }
    }
}