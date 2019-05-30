using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtMethods
{
    public class Grouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        IEnumerable<TSource> elements;
        public TKey Key { get; private set; }

        public Grouping(TKey key, IEnumerable<TSource> elements)
        {           
            this.Key = key;
            this.elements = elements;
        }        

        public IEnumerator<TSource> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }        
    }
}
