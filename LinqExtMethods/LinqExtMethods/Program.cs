using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExtMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            // Where and Select
            var query = fruits.WhereExt((fruit) => fruit.Length < 6).SelectExt((fruit) => fruit);
            foreach (var obj in query)
            {
                Console.WriteLine("{0}", obj);
            }

            // ToList
            var list = fruits.ToListExt();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            
            // ToDictionary
            var dict = fruits.ToDictionaryExt(a => a.ToUpper());
            foreach (var item in dict)
            {
                Console.WriteLine("Key is {0}  Value is {1}", item.Key, item.Value);
            }

            // Grouping
            var group = fruits.GroupByExt(g => g.Length);
            foreach (var item in group)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(" {0}", i);
                }
            }

            // Ordering
            var order = fruits.OrderByExt(x => x.Length);
            foreach (var item in order)
            {
                Console.Write(item + " ");
            }
        }
    }
}
