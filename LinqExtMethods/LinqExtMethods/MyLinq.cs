using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExtMethods
{
    public static class MyLinq
    {
        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of source.</typeparam>
        /// <typeparam name="TResult"> The type of the value returned by selector. </typeparam>
        /// <param name="source"> A sequence of values to invoke a transform function on.</param>
        /// <param name="selector"> A transform function to apply to each element.</param>
        public static IEnumerable<TResult> SelectExt<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of source.</typeparam>
        /// <param name="source"> Whose elements to filter </param>
        /// <param name="predicate"> A function to test each element for a condition.</param>
        public static IEnumerable<TSource> WhereExt<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of source. </typeparam>
        /// <typeparam name="TKey"> The type of the key returned by keySelector. </typeparam>
        /// <param name="source"> Whose elements to group. </param>
        /// <param name="keySelector"> A function to extract the key for each element. </param>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var dict = new Dictionary<TKey, List<TSource>>();
            foreach (var item in source)
            {
                var key = keySelector(item);
                if (dict.Keys.Contains(key))
                {
                    dict[key].Add(item);
                }
                else
                {
                    dict.Add(key, new List<TSource> { item });
                }
            }            
            foreach (var item in dict)
            {
                yield return new Grouping<TKey, TSource>(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Create list
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of source.</typeparam>
        /// <param name="source"> Whose elements to create a list </param>
        public static List<TSource> ToListExt<TSource>(this IEnumerable<TSource> source)
        {
            return new List<TSource>(source);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of source.</typeparam>
        /// <typeparam name="TKey"> The type of the key returned by keySelector.</typeparam>
        /// <param name="source"> A sequence of values to order.</param>
        /// <param name="keySelector"> A function to extract a key from an element.</param>
        public static IOrderedEnumerable<TSource> OrderByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            {
                return new OrderedEnumerable<TSource>(source, new ProjectionComparer<TSource, TKey>(keySelector));
            }
        }

        /// <summary>
        /// Creates a Dictionary<TKey,TValue> from an IEnumerable<T> according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of source.</typeparam>
        /// <typeparam name="TKey"> The type of the key returned by keySelector.</typeparam>
        /// <param name="source"> Whose elements to create a dictionary</param>
        /// <param name="keySelector"> A function to extract a key from each element.</param>
        /// <returns></returns>
        public static Dictionary<TKey, TSource> ToDictionaryExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            Dictionary<TKey, TSource> result = new Dictionary<TKey,TSource>();
            foreach (var item in source)
            {
                result.Add(keySelector(item), item);
            }
            return result;
        }


    }
}
