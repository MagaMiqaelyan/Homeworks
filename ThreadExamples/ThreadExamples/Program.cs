using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamples
{
    class Program
    {
        static int Length = Convert.ToInt32(Console.ReadLine());
        static int[] Array = new int[Length];
        static int Sum = 0;

        static void Main(string[] args)
        {          
            Random random = new Random();
            for (int item = 0; item < Length; ++item) 
            {
                Array[item] = random.Next(1, 5);
                Console.Write(Array[item] + " ");
            }

            #region Exercise1
            Thread thread1 = new Thread(MyThread1);
            Thread thread2 = new Thread(MyThread2);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            Console.WriteLine("\nSum using Thread class is {0}", Sum);
            #endregion

            #region Exercise2
            Console.Write("Please input Threads count ");
            int countofthreads = Convert.ToInt32(Console.ReadLine());
            int SumWithParallelFor = 0;
            Parallel.For(0, Length, new ParallelOptions { MaxDegreeOfParallelism = countofthreads },
                         () => 0,
                         (j, loop, sum) =>
                         {
                             sum += Array[j];
                             return sum;
                         },
                         (sum) => Interlocked.Add(ref SumWithParallelFor, sum));
            Console.WriteLine("\nSum using ParallelFor is " + SumWithParallelFor);
            #endregion

            // Console.WriteLine("\nSum is {0}", Array.AsParallel().Sum());           
        }
        /// <summary>
        /// Calculate sum of the first half of the array   
        /// </summary>
        public static void MyThread1()
        {
            //Console.WriteLine("Thread 1");
            for (int i = 0; i < Length / 2; ++i) 
            {
                Sum += Array[i]; 
            }         
        }

        /// <summary>
        /// Calculate sum of the second half of the array 
        /// </summary>
        public static void MyThread2()
        {
           // Console.WriteLine("\nThread 2");
            for (int i = Length / 2; i < Length; ++i)
            {
                Sum += Array[i];                
            }
        }
    }
}
