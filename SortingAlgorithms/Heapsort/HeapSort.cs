using System;
using System.Diagnostics;

namespace Heapsort
{
    public  class HeapSort
    {
        public static void Heap(int[]arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HeapHelp(arr);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("GetMamory is "+ GC.GetTotalMemory(false));
        }
        private static void HeapHelp(int[] arr)
        {
           
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
             Doheap(arr, arr.Length, i); 

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;

                Doheap(arr, i, 0);
            } 
        }

        private static void Doheap(int[] arr, int size, int i)
        {
            int large = i;
            int right = 2 * i + 2;
            int left = 2 * i + 1;

            if (left < size && arr[left] > arr[large]) 
                large = left;
            if (right < size && arr[right] > arr[large]) 
                large = right;
            if (large != i) 
            {
                int swap = arr[i];
                arr[i] = arr[large];
                arr[large] = swap;

                Doheap(arr, size, large);
            }
        }
    }
}
