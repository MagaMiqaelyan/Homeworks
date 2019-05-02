using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MultiMap
{
    class Multimap<TKey, TValue> : IDictionary<TKey, HashSet<TValue>>
    {
        private Dictionary<TKey, HashSet<TValue>> multimap;

        /// <summary>
        /// Constructor
        /// </summary>
        public Multimap()
        {
            multimap = new Dictionary<TKey, HashSet<TValue>>();
        }

        public HashSet<TValue> this[TKey key] { get => multimap[key]; set => multimap[key] = value; } // The key of the value to get or set.

        public ICollection<TKey> Keys => multimap.Keys; // Gets a collection containing the keys

        public ICollection<HashSet<TValue>> Values => multimap.Values; // Gets a collection containing the values

        public int Count => multimap.Count(); // The number of key and values pairs contained in the dictionary

        public bool IsReadOnly => false; // A collection that is read-only does not allow the addition, removal, or modification of elements after the collection is created.

        /// <summary>
        /// Adds the specified key and values to the dictionary
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The values of the element to add.</param>
        public void Add(TKey key, HashSet<TValue> value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            if (multimap.Keys.Contains(key))
            {
                throw new ArgumentException();
            }
            else
            {
                multimap.Add(key, value);
            }
        }

        /// <summary>
        /// Adds the key and values pair to the dictionary
        /// </summary>
        /// <param name="item"> Key and value pair</param>
        public void Add(KeyValuePair<TKey, HashSet<TValue>> item)
        {
            if (!multimap.Contains(item))
            {
                multimap.Add(item.Key, item.Value);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Clear the dictionary
        /// </summary>
        public void Clear()
        {
            multimap.Clear();
        }

        /// <summary>
        /// Determines whether the dictionary contains a key and values pair.
        /// </summary>
        /// <param name="item"> Key and values pair</param>
        /// <returns> True if item is found in the dictionary; otherwise, false.</returns>
        public bool Contains(KeyValuePair<TKey, HashSet<TValue>> item)
        {
            if (multimap.Contains(item))
            {
                return true;
            }
             return false;            
        }

        /// <summary>
        /// Determines whether the Dictionary<TKey,HashSet<TValue>> contains the specified key
        /// </summary>
        /// <param name="key"> The key to locate in the  Dictionary<TKey,HashSet<TValue>> </param>
        /// <returns> True if the  Dictionary<TKey,HashSet<TValue>> contains an element with the specified key</returns>
        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            if (multimap.Keys.Contains(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Copies the key and values pair elements to an Array, starting at the specified array index.
        /// </summary>
        /// <param name="array"> Array </param>
        /// <param name="arrayIndex">The index in array at which copying begins.</param>
        public void CopyTo(KeyValuePair<TKey, HashSet<TValue>>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0) 
            {
                throw new ArgumentOutOfRangeException();
            }
            if (multimap.Count > array.Length - arrayIndex)
            {
                throw new ArgumentException();
            }
            else
            {
                foreach (var pair in multimap)
                {
                    array[arrayIndex] = pair;
                    arrayIndex++;
                }
            }

        }
      
        /// <summary>
        /// Removes the value with the specified key 
        /// </summary>
        /// <param name="key"> The key of the element to remove. </param>
        /// <returns> True if the element is found and removed; otherwise, false. </returns>
        public bool Remove(TKey key)
        {
            if (ContainsKey(key))
            {
                multimap.Remove(key);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the key and values pair
        /// </summary>
        /// <param name="item"> Key and values pair </param>
        /// <returns>True if the pair is found and removed; otherwise, false.</returns>
        public bool Remove(KeyValuePair<TKey, HashSet<TValue>> item)
        {
            if (Contains(item))
            {
                multimap.Remove(item.Key);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets values associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the values associated with the specified key, if the key is found;
        ///                     otherwise, the default values for the type of the values parameter. 
        ///                     This parameter is passed uninitialized.</param>
        /// <returns>true if the object that implements IDictionary<TKey,HashSet<TValue>> contains  elements with the specified key; 
        ///          otherwise, false.</returns>
        public bool TryGetValue(TKey key, out HashSet<TValue> value)
        {            
            value = default(HashSet<TValue>);
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            else if (ContainsKey(key) && multimap[key] != null)
            {
                value = multimap[key];
                return true;
            }
            return false;
        }

        /// <summary>
        /// Implementation for the GetEnumerator method.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TKey, HashSet<TValue>>> GetEnumerator()
        {
            return multimap.GetEnumerator();
        }
    }
}
