using System;

namespace EnumeratorForNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList1 = new LinkedList<int>();
            linkedList1.AddFirst(10);
            linkedList1.AddLast(15);
            linkedList1.AddLast(20);
            linkedList1.AddFirst(5);
            
            foreach (var item in linkedList1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(linkedList1.Contains(5));
            Console.WriteLine(linkedList1.Contains(12));

            var linkedlist2 = new LinkedList<string>();
            linkedlist2.AddFirst("b");
            linkedlist2.AddLast("c");
            linkedlist2.AddLast("a");

            Console.WriteLine(linkedlist2.Contains("d"));
            Console.WriteLine(linkedlist2.Contains("a"));
        }
    }
}
