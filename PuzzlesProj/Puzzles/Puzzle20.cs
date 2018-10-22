using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    public class Puzzle20
    {
        public Puzzle20()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 20.");
            Console.WriteLine("This program Sorts number using various algorithms");
            int[] arr = null;

            /* Bubble Sort *
            arr = GenerateArray(10, 50);
            PrintArray(arr);
            //BubbleSort(arr);
            BubbleSort_Recursive(arr, 0);
            PrintArray(arr);
            */

            /* Selection Sort
            arr = GenerateArray(10, 50);
            PrintArray(arr);
            SelectionSort(arr);
            PrintArray(arr);
            */

            /* Insert Sort *
            arr = GenerateArray(7, 50);
            PrintArray(arr);
            //InsertSort(arr);
            Console.WriteLine("Performing Insert Sort Recursively");
            InsertSort_Recursive(arr, 1);
            PrintArray(arr);
            */

            /* Merge Sort *
            arr = GenerateArray(10, 50); //new int[] { 7, 5, 3, 1,0};
            PrintArray(arr);
            Console.WriteLine("Performing Merge Sort");
            MergeSort(arr, 0, arr.Length - 1);
            PrintArray(arr);
            */

            /* Iterative Merge Sort */
            arr = GenerateArray(4, 50); //new int[] { 7, 5, 3, 1,0};
            PrintArray(arr);
            Console.WriteLine("Performing Merge Sort using Iterations");
            IterativeMergeSort(arr, 0, arr.Length - 1);
            PrintArray(arr);


            /* Quick Sort *
            arr = GenerateArray(6, 50); //new int[] { 7, 5, 1,3,0}; 
            PrintArray(arr);
            Console.WriteLine("Performing Quick Sort");
            QuickSort(arr, 0, arr.Length - 1);
            PrintArray(arr);
            */

        }

        private int[] GenerateArray(int length, int maxValue)
        {
            Random r = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next(maxValue);
            }
            return arr;
        }

        private void PrintArray(int[] arr)
        {
            Console.WriteLine("Printing Array");
            foreach(int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

        private void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for ( int j = i+1; j < arr.Length; j++)
                {
                    if  ( arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        private void BubbleSort_Recursive(int[] arr, int index)
        {
            if ( index >= arr.Length)
            {
                return;
            }

            for (int i = index, j = index + 1 ; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            BubbleSort_Recursive(arr, index + 1);
        }

        /// <summary>
        /// Selection Sort - 
        /// Iterate through array from begining, for each element, compared to rest and swap if its smaller
        /// </summary>
        /// <param name="arr"></param>
        private void SelectionSort(int[] arr)
        {
            Console.WriteLine("Performing Selection Sort ");
            int minIndex = 0, temp = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if ( arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;

            }
        }

        /*
         * Insertion sort is a comparison-based algorithm that builds a final sorted array one element at a time. 
         * It iterates through an input array and removes one element per iteration, finds the place the 
         * element belongs in the array, and then places it there.
         * */
        private void InsertSort(int[] arr)
        {
            Console.WriteLine("Performing Insert Sort ");
            int temp = 0;
            for(int i = 1; i < arr.Length; i++)
            {
                if ( arr[i] < arr[i-1])
                {
                    for(int k = i; k > 0; k--)
                    {
                        if (arr[k] > arr[k - 1])
                        {
                            break;
                        }
                        else
                        {
                            temp = arr[k];
                            arr[k] = arr[k - 1];
                            arr[k - 1] = temp;
                        }
                    }
                }
            }
        }

        private void InsertSort_Recursive(int[] arr, int index)
        {
            if ( index >= arr.Length )
            {
                return;
            }

            for ( int i = index ; i > 0; i--)
            {
                if ( arr[i] < arr[i-1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }
                else
                {
                    break;
                }
            }
            InsertSort_Recursive(arr, index + 1);
        }

        private void MergeSort(int[] arr, int left, int right)
        {
            // log(x) Y = N
            // log(2) 8 = 3
            int mid = 0;
            if (left < right)
            {
                mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, (mid + 1), right);
                DoMerge(arr, left, mid, right);
            }
        }

        private void DoMerge(int[] arr, int left, int mid, int right)
        {
            //Console.WriteLine("Left={0}, Mid={1},right={2}", left, mid, right);
            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            // Copy to temp arrays

            // Copy left items to leftArr
            for (i = 0; i < n1; i++)
            {
                leftArr[i] = arr[left + i];
            }

            // Copy right items to rightArr
            for (j = 0; j < n2; j++)
            {
                rightArr[j] = arr[mid + 1 + j];
            }

            // Now sort merge to main array while merging, sort and add
            k = left;
            for (i = j = 0; i < n1 && j < n2; k++)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
            }

            // Copy remaining elements from leftArr
            for (; i < n1; i++, k++)
            {
                arr[k] = leftArr[i];
            }

            // Copy remaining elements from rightArr
            for (; j < n2; j++, k++)
            {
                arr[k] = rightArr[j];
            }

            //Console.Write("Result array:");
            //PrintArray(arr);

        }

        private void IterativeMergeSort(int[] arr, int left, int right)
        {
            int currSize, leftStart = 0;

            for(currSize = 1; currSize <= right;currSize = 2*currSize)
            {
                for(leftStart = 0; leftStart < right;leftStart += 2*currSize)
                {
                    int mid = leftStart + currSize - 1;
                    int rightEnd = Min(leftStart + 2 * currSize - 1, right);
                    DoMerge(arr, leftStart, mid, rightEnd);
                }
            }
        }
        private int Min(int x, int y)
        {
            return (x < y) ? x : y;
        }


        private int IterationCount(int size)
        {
            int count = 0;
            int temp = 1;
            for(; temp > 0 ; )
            {
                temp = size /= 2;
                count++;
            }
            return count;
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if ( left < right )
            {
                int pi = Partition(arr, left, right);
                QuickSort(arr, left, pi - 1);
                QuickSort(arr, pi + 1, right);
            }
        }

        private int Partition(int[] arr, int left,int right)
        {
            int pivot = arr[right];
            int i = (left - 1);
            int temp = 0;
            for (int j = left; j <= right-1; j++)
            {
                if ( arr[j] <= pivot)
                {
                    i++;
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }

            //Console.WriteLine("Partition");
            //PrintArray(arr);
            
            temp = arr[right];
            arr[right] = arr[i + 1];
            arr[i + 1] = temp;

            //Console.WriteLine("Swap");
            //PrintArray(arr);

            //Console.WriteLine("pi = {0}", i + 1);
            return i + 1;
        }

    }
}
