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
        static void Help(string[] arr, string str)
        {
            //str.Split();
            for (int i = 0; i < Convert.ToInt32(str.Last()) - Convert.ToInt32(str.First()) + 1; i++)
            {               
                if (str.Contains('-'))
                {
                    arr[i] = (Convert.ToInt32(new string(str[0],1)) + i).ToString();
                    continue;
                }                
                if (str[i] == ',')                                   
                    continue;                
                else
                    arr[i] = str[i].ToString();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Please enter the size of an array that you want to sort: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] unsorted = new int[n];
            int[] unsorted1 = new int[n];
            int[] unsorted2 = new int[n];
            int[] unsorted3 = new int[n];
            int[] unsorted4 = new int[n];
            int[] unsorted5 = new int[n];
            Random random = new Random();
           

            Console.WriteLine("Unsorted array is:");
            for (int i = 0; i < n; i++)
            {
                unsorted[i] = random.Next(1, 100);
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < unsorted.Length; i++)
            {
                unsorted1[i] = unsorted[i];
                unsorted2[i] = unsorted[i];
                unsorted3[i] = unsorted[i];
                unsorted4[i] = unsorted[i];
                unsorted5[i] = unsorted[i];              
            }

            Console.WriteLine("\nSelect which algorithm you want to perform:\n 1.Insertion sort \n 2.Bubble sort\n 3.Quick sort\n 4.Heap sort\n 5.Merge sort\n 6.All");
            string NumberSorted = Console.ReadLine();
            string[] a = new string[unsorted.Length];
            Help(a, NumberSorted);
            for (int i=0; i < a.Length; i++)
            {
                switch (a[i])
                {
                    case "1":
                        Console.WriteLine("Insertion sort");
                        InsertionSort.Insertion(unsorted1);
                        break;
                    case "2":
                        Console.WriteLine("Bubble sort");
                        BubleSort.Buble(unsorted2);
                        break;
                    case "3":
                        Console.WriteLine("Quick sort");
                        QuickSort.Quick(unsorted3);
                        break;
                    case "4":
                        Console.WriteLine("Heap sort");
                        HeapSort.Heap(unsorted4);
                        break;
                    case "5":
                        Console.WriteLine("Merge sort");
                        MergeSort.Merge(unsorted5);
                        break;
                    case "6":
                        Console.WriteLine("All");
                        Console.Write("Insertion sort: ");
                        InsertionSort.Insertion(unsorted1);
                        Console.Write("\nBubble sort: ");
                        BubleSort.Buble(unsorted2);
                        Console.Write("\nQuick sort: ");
                        QuickSort.Quick(unsorted3);
                        Console.Write("\nHeap sort: ");
                        HeapSort.Heap(unsorted4);
                        Console.Write("\nMerge sort: ");
                        MergeSort.Merge(unsorted5);
                        break;
                    default:
                        //Console.WriteLine("Don't any sorting algorithms");
                        break;
                }
            }
        }
    }
}


    
