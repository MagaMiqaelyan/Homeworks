using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bublesort;
using Heapsort;
using Insertionsort;
using Mergesort;
using Quicksort;


namespace SortingAlgorithms
{
    class Program
    {
        static void Help(char[] arr, string str)
        {            
            if (str.Contains(','))
            {
                str.Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    arr[i] = str[i];
                }
            }
            if (str.Contains('-'))
            {
                str.Split('-');
                for (int i = 0; i < str.Last() - str.First() + 1; i++)
                {
                    arr[i] = (Char)((int)str[0] + i);
                }
            }
            else
                arr[0] = str[0];
            
        }
        static void Main(string[] args)
        {
            Console.Write("Please enter the size of an array that you want to sort: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] Unsorted = new int[n];
            int[] UnsorteCopy = new int[n];
            
            Random random = new Random();
           

            Console.WriteLine("Unsorted array is:");
            for (int i = 0; i < n; i++)
            {
                Unsorted[i] = random.Next(1, 100);
                Console.Write(Unsorted[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\nSelect which algorithm you want to perform:\n 1.Insertion sort \n 2.Bubble sort\n 3.Quick sort\n 4.Heap sort\n 5.Merge sort\n 6.All");
            string NumberSorted = Console.ReadLine();
            char[] a = new char[Unsorted.Length];
            Help(a, NumberSorted);
            for (int i=0; i < a.Length; i++)
            {
                switch (a[i])
                {
                    case '1':
                        Console.WriteLine("Insertion sort");
                        Array.Copy(Unsorted, UnsorteCopy, Unsorted.Length);
                        InsertionSort.Insertion(UnsorteCopy);
                        break;
                    case '2':
                        Console.WriteLine("Bubble sort");
                        BubleSort.Buble(UnsorteCopy);
                        break;
                    case '3':
                        Console.WriteLine("Quick sort");
                        QuickSort.Quick(UnsorteCopy);
                        break;
                    case '4':
                        Console.WriteLine("Heap sort");
                        HeapSort.Heap(UnsorteCopy);
                        break;
                    case '5':
                        Console.WriteLine("Merge sort");
                        MergeSort.Merge(UnsorteCopy);
                        break;
                    case '6':
                        Console.WriteLine("All");
                        Console.Write("Insertion sort: ");
                        InsertionSort.Insertion(UnsorteCopy);
                        Console.Write("\nBubble sort: ");
                        BubleSort.Buble(UnsorteCopy);
                        Console.Write("\nQuick sort: ");
                        QuickSort.Quick(UnsorteCopy);
                        Console.Write("\nHeap sort: ");
                        HeapSort.Heap(UnsorteCopy);
                        Console.Write("\nMerge sort: ");
                        MergeSort.Merge(UnsorteCopy);
                        break;
                    default:
                        //Console.WriteLine("Don't any sorting algorithms");
                        break;
                }
            }
        }
    }
}


    
