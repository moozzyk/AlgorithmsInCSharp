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

    public class Hashtable_OpenAddressing<TKey>
    {
        private readonly Func<TKey, int> _hashFunction;
        private TKey[] _hashtable;
        private bool[] _wasEverOccupied;

        public TKey[] Hashtable
        {
            get { return _hashtable; }
        }

        public Hashtable_OpenAddressing(int size, Func<TKey, int> hashFunction)
        {
            _hashFunction = hashFunction;
            _hashtable = new TKey[size];
            _wasEverOccupied = new bool[size];
        }

        public void Add(TKey key)
        {
            if (Equals(key, default(TKey)))
            {
                throw new ArgumentException("Cannot use default value of the type as a key.", "key");
            }

            var index = GetIndex(key, returnFirstEmptySlot: true);
            if (!index.HasValue)
            {
                throw new InvalidOperationException("Hashtable is full.");
            }

            _hashtable[index.Value] = key;

            // we need to mark the slot as occupied so that we will continue searching for the key
            // past an empty slot since, due to conflict resolution, the key might be located after empty slots.
            _wasEverOccupied[index.Value] = true;
        }

        public TKey Get(TKey key)
        {
            if (Equals(key, default(TKey)))
            {
                throw new ArgumentException("Cannot use default value of the type as a key.", "key");
            }

            // due to conflict resolution the item might be located after an empty slot
            var index = GetIndex(key, returnFirstEmptySlot: false);
            return index == null ? default(TKey) : _hashtable[index.Value];
        }

        public bool Delete(TKey key)
        {
            if (Equals(key, default(TKey)))
            {
                throw new ArgumentException("Cannot use default value of the type as a key.", "key");
            }

            // due to conflict resolution the item might be located after an empty slot
            var index = GetIndex(key, returnFirstEmptySlot: false);
            if (index == null || Equals(_hashtable[index.Value], default(TKey)))
            {
                return false;
            }

            _hashtable[index.Value] = default(TKey);

            return true;
        }

        private int? GetIndex(TKey key, bool returnFirstEmptySlot)
        {
            var hash = _hashFunction(key);
            var index =  hash % _hashtable.Length;

            for (var i = index; i != (_hashtable.Length + index - 1) % _hashtable.Length; i = (i + 1) % _hashtable.Length)
            {
                if (key.Equals(_hashtable[i]) || (_hashtable[i] == null && (returnFirstEmptySlot || !_wasEverOccupied[i])))
                {
                    return i;
                }
            }

            return null;
        }
    }
}