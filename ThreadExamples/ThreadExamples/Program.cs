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
        static void Main(string[] args)
        {
            Console.Write("Please input array length ");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[length];
            int sum = 0;
            Random random = new Random();

            for (int item = 0; item < length; ++item) 
            {
                array[item] = random.Next(1, 5);
                Console.Write(array[item] + " ");
            }

            #region Exercise1
            Thread thread1 = new Thread(()=> MyThread1(ref array,ref sum));
            Thread thread2 = new Thread(() => MyThread2(ref array, ref sum));
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            Console.WriteLine("\nSum using Thread class is {0}", sum);
            #endregion

            #region Exercise2
            Console.Write("Please input Threads count ");
            int countofthreads = Convert.ToInt32(Console.ReadLine());
            int SumWithParallelFor = 0;
            Parallel.For(0, length, new ParallelOptions { MaxDegreeOfParallelism = countofthreads },
                         () => 0,
                         (j, loop, summary) =>
                         {
                             summary += array[j];
                             return summary;
                         },
                         (summary) => Interlocked.Add(ref SumWithParallelFor, summary));
            Console.WriteLine("\nSum using ParallelFor is " + SumWithParallelFor);
            #endregion

            // Console.WriteLine("\nSum is {0}", Array.AsParallel().Sum());           
        }
        /// <summary>
        /// Calculate sum of the first half of the array   
        /// </summary>
        public static void MyThread1(ref int[] array, ref int sum)
        {
            //Console.WriteLine("Thread 1");
            for (int i = 0; i < array.Length/ 2; ++i) 
            {
                sum += array[i]; 
            }         
        }

        /// <summary>
        /// Calculate sum of the second half of the array 
        /// </summary>
        public static void MyThread2(ref int[] array, ref int sum)
        {
           // Console.WriteLine("\nThread 2");
            for (int i = array.Length / 2; i < array.Length; ++i)
            {
                sum += array[i];                
            }
        }
    }
}
