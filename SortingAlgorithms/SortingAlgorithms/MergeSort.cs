using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class MergeSort
    {
        public static void Merge(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MergeDo(arr, 0, arr.Length - 1);

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("GetMamory is " + GC.GetTotalMemory(false));
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
        }

        private static void MergeDo(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeDo(arr, left, middle);
                MergeDo(arr, middle + 1, right);
                MergeHelp(arr, left, middle, right);
            }
        }
        private static void MergeHelp(int[] arr, int left, int middle, int right)
        {
            int[] Left = new int[middle - left + 1];
            int[] Right = new int[right - middle];
            int k = left;
            int l = 0;
            int r = 0;

            for (int i = 0; i < Left.Length; i++)
            {
                Left[i] = arr[left + i];
            }
            for (int i = 0; i < Right.Length; i++)
            {
                Right[i] = arr[middle + 1 + i];
            }
            while (l < Left.Length && r < Right.Length)
            {
                if (Left[l] <= Right[r])
                {
                    arr[k] = Left[l];
                    l++;
                }
                else
                {
                    arr[k] = Right[r];
                    r++;
                }
                k++;
            }
            while (l < Left.Length)
            {
                arr[k] = Left[l];
                l++;
                k++;
            }
            while (r < Right.Length)
            {
                arr[k] = Right[r];
                r++;
                k++;
            }
        }
    }
}
