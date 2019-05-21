using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForAndForeach
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parallel.ParallelFor(0, 10, (i) =>
            //{
            //    Console.WriteLine("Thread {0}, Number {1}", Thread.CurrentThread.ManagedThreadId, Math.Pow(i, 2));
            //});

            int[] numbers = { 10, 100, 1000, 10000};

            //Parallel.ParallelForEach(numbers, num =>
            //{
            //    Console.WriteLine("Thread {0}, Number {1}", Thread.CurrentThread.ManagedThreadId, Math.Log10(num));
            //});

            Parallel.ParallelForEachWithOptions(numbers, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, num =>
            {
                Console.WriteLine("Thread {0}, Number {1}", Thread.CurrentThread.ManagedThreadId, Math.Log10(num));
            });
        }
    }
}
