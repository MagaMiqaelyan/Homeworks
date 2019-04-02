﻿using System;
using System.Diagnostics;

namespace Insertionsort
{
    public class InsertionSort
    {
        public static void Insertion(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = temp;
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }
        //for (int i = 0; i <arr.Length; i++)
        //{
        //    Console.Write(arr[i]+ " ");
        //}
    }
}
