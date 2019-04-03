using System;
using System.Diagnostics;

namespace Quicksort
{
    public class QuickSort
    {
        public static void Quick(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            QuickHelp(0, arr.Length - 1, arr);

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("GetMamory is " + GC.GetTotalMemory(false));
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
        }
        private static void QuickHelp(int left, int right, int[] arr)
        {
           
            if (left < right) 
            {
                int pi = partition(left, right, arr);

                QuickHelp(left, pi - 1, arr);
                QuickHelp(pi + 1, right, arr);
            }
           
        }
        private static int partition(int left, int right, int[] arr)
        {
            int pivot = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int swap = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = swap;

            return i + 1;
        }
    }
}
