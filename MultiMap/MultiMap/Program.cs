using System;
using System.Collections.Generic;

namespace MultiMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var multimap = new Multimap<string, string>();
            var hashset = new HashSet<string>();          
            hashset.Add("Yerevan");
            hashset.Add("Gyumri");
            multimap.Add("EPH", hashset);

            var check = new HashSet<string>();
            check.Add("Goris");
            //openWith.Remove("EPH");
            Console.WriteLine(multimap.Contains(new KeyValuePair<string, HashSet<string>>("EPH", check)));

            //KeyValuePair<string, HashSet<string>>[] array = new KeyValuePair<string, HashSet<string>>[10];
            //multimap.CopyTo(array,5);
            //foreach (var item in array)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            var example = new HashSet<string>();
            multimap.TryGetValue("EPH", out example);
            foreach (var item in example)
            {
                Console.WriteLine("The values of the key is " + item);
            }

            Console.WriteLine();
            foreach (string value in multimap.Keys)
            {
                Console.WriteLine("Keys = {0}", value);
            }          
            foreach (var value in multimap.Values)
            {
                foreach (var item in value)
                {
                    Console.WriteLine("Value = {0}", item);
                }
            }
        }
    }
}
