using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimap
{
    class MultiMap<TKey, TValue> : IDictionary<TKey, HashSet<TValue>>
    {
        private Dictionary<TKey, HashSet<TValue>> multimap;

        public MultiMap()
        {
            multimap = new Dictionary<TKey, HashSet<TValue>>();
        }

        public HashSet<TValue> this[TKey key] { get => multimap[key]; set => multimap[key] = value; }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<HashSet<TValue>> Values => throw new NotImplementedException();

        public int Count => multimap.Count();

        public bool IsReadOnly => throw new NotImplementedException();
               
        public void Add(TKey key, HashSet<TValue> value)
        {
            if (multimap.Keys.Contains(key))
                multimap.Add(key, value);
            else throw new Exception();
        }

        public void Add(KeyValuePair<TKey, HashSet<TValue>> item)
        {
            if (!multimap.Contains(item))
                multimap.Add(item.Key, item.Value);
            else throw new Exception();
        }

        public void Clear()
        {
            multimap.Clear();
        }

        public bool Contains(KeyValuePair<TKey, HashSet<TValue>> item)
        {
            if (multimap.Contains(item))
                return true;
            else return false;
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, HashSet<TValue>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, HashSet<TValue>>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, HashSet<TValue>> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out HashSet<TValue> value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //public HashSet<TValue> GetValues(TKey key)
        //{
        //    HashSet<TValue> result = null;
        //    TryGetValue(key, out result);
        //    return result;
        //}
    }
}
