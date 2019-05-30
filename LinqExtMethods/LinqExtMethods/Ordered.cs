using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtMethods
{
    public class OrderedEnumerable<TSource> : IOrderedEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> source;
        private readonly IComparer<TSource> comparer;

        public OrderedEnumerable(IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            this.source = source;
            this.comparer = comparer;
        }

        /// <summary>
        /// Performs a subsequent ordering on the elements of an IOrderedEnumerable<TSource> according to a key.
        /// </summary>
        /// <typeparam name="TKey"> The type of the key produced by keySelector.</typeparam>
        /// <param name="keySelector"> Used to extract the key for each element.</param>
        /// <param name="keyComparer"> Used to compare keys for placement in the returned sequence.</param>
        /// /// <param name="descending"> True to sort the elements in descending order; False to sort the elements in ascending order.</param>
        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            IComparer<TSource> extraComparer = new ProjectionComparer<TSource, TKey>(keySelector, keyComparer);
            if (descending)
            {
                extraComparer = new ReverseComparer<TSource>(extraComparer);
            }
            return new OrderedEnumerable<TSource>(source, new LinkedComparer<TSource>(comparer, extraComparer));
        }

        public IEnumerator<TSource> GetEnumerator()
        {                        
            List<TSource> results = new List<TSource>();
            foreach (TSource element in source)
            {
                bool inserted = false;
                for (int i = 0; i < results.Count; i++)
                {
                    if (comparer.Compare(element, results[i]) < 0)
                    {
                        results.Insert(i, element);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    results.Add(element);
                }
            }            
            foreach (TSource element in results)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
       
    /// <summary>
    /// Comparer which projects each element of the comparison to a key, and then compares
    /// those keys using the specified (or default) comparer for the key type.
    /// </summary>
    /// <typeparam name="TSource">Type of elements which this comparer will be asked to compare</typeparam>
    /// <typeparam name="TKey">Type of the key projected from the element</typeparam>
    public class ProjectionComparer<TSource, TKey> : IComparer<TSource>
    {
        readonly Func<TSource, TKey> projection;
        readonly IComparer<TKey> comparer;

        /// <summary>
        /// Creates a new instance using the specified projection, which must not be null.
        /// The default comparer for the projected type is used.
        /// </summary>
        /// <param name="projection">Projection to use during comparisons</param>
        public ProjectionComparer(Func<TSource, TKey> projection): this(projection, null)
        {
        }

        /// <summary>
        /// Creates a new instance using the specified projection, which must not be null.
        /// </summary>
        /// <param name="projection">Projection to use during comparisons</param>
        /// <param name="comparer">The comparer to use on the keys. May be null, in
        /// which case the default comparer will be used.</param>
        public ProjectionComparer(Func<TSource, TKey> projection, IComparer<TKey> comparer)
        {
            this.comparer = comparer ?? Comparer<TKey>.Default;
            this.projection = projection;
        }

        /// <summary>
        /// Compares first and second by projecting them to keys and then comparing the keys. 
        /// Null values are not projected.
        /// </summary>
        public int Compare(TSource first, TSource second)
        {
            if (first == null && second == null)
            {
                return 0;
            }
            if (first == null)
            {
                return -1;
            }
            if (second == null)
            {
                return 1;
            }
            return comparer.Compare(projection(first), projection(second));
        }
    }
       
    /// <summary>
    /// Comparer to daisy-chain two existing comparers and apply in sequence
    /// </summary>
    public sealed class LinkedComparer<TSource> : IComparer<TSource>
    {
        readonly IComparer<TSource> primary, secondary;

        /// <summary>
        /// Create a new LinkedComparer
        /// </summary>
        /// <param name="primary">The first comparison to use</param>
        /// <param name="secondary">The next level of comparison if the primary returns 0 </param>
        public LinkedComparer(IComparer<TSource> primary, IComparer<TSource> secondary)
        {
            this.primary = primary;
            this.secondary = secondary;
        }

        int IComparer<TSource>.Compare(TSource first, TSource second)
        {
            int result = primary.Compare(first, second);
            return result == 0 ? secondary.Compare(first, second) : result;
        }
    }

    /// <summary>
    /// Implementation of IComparer{TSource} based on another one;
    /// this simply reverses the original comparison.
    /// </summary>
    public sealed class ReverseComparer<TSource> : IComparer<TSource>
    {         

        /// <summary>
        /// Returns the original comparer; this can be useful to avoid multiple reversals.
        /// </summary>
        public IComparer<TSource> OriginalComparer { get; }
       
        /// <summary>
        /// Creates a new reversing comparer.
        /// </summary>
        /// <param name="original">The original comparer to use for comparisons.</param>
        public ReverseComparer(IComparer<TSource> original)
        {
            this.OriginalComparer = original;
        }

        /// <summary>
        /// Returns the result of comparing the specified values using the original
        /// comparer, but reversing the order of comparison.
        /// </summary>
        public int Compare(TSource first, TSource second)
        {
            return OriginalComparer.Compare(second, first);
        }
    }
}

