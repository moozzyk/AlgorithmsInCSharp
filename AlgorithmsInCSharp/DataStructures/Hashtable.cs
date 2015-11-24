using System;

namespace AlgorithmsInCSharp.DataStructures
{
    public class Hashtable_Chaining<TKey>
    {
        private readonly Func<TKey, int> _hashFunction;
        private readonly LinkedList<TKey>[] _hashtable;

        public LinkedList<TKey>[] Hashtable
        {
            get { return _hashtable; }
        }

        public Hashtable_Chaining(int size, Func<TKey, int> hashFunction)
        {
            _hashFunction = hashFunction;
            _hashtable = new LinkedList<TKey>[size];
        }

        public void Add(TKey key)
        {
            var index = GetIndex(key);

            if (_hashtable[index] == null)
            {
                _hashtable[index] = new LinkedList<TKey>();
            }

            _hashtable[index].Insert(key);
        }

        public TKey Get(TKey key)
        {
            var index = GetIndex(key);
            var node = _hashtable[index] == null ? null :  _hashtable[index].Search(key);

            return node == null ? default(TKey) : node.Value;
        }

        public bool Delete(TKey key)
        {
            var index = GetIndex(key);
            if (_hashtable[index] == null)
            {
                return false;
            }

            var node = _hashtable[index].Search(key);
            if (node == null)
            {
                return false;
            }

            _hashtable[index].Delete(node);

            return true;
        }

        private int GetIndex(TKey key)
        {
            var hash = _hashFunction(key);
            return hash % _hashtable.Length;
        }

    }
}