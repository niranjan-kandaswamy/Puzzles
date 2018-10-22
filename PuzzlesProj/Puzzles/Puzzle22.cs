using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle22
    {
        public Puzzle22()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 22.");
            Console.WriteLine("This program lists # of odd and even numbers in a given array ");
            int[] arr = GenerateArray(10, 50);

            PrintArray(arr);
            Console.WriteLine("# of Odd numbers = {0}", DetermineOddCount(arr));
            Console.WriteLine("# of Even numbers = {0}", DetermineEvenCount(arr));
        }


        private int DetermineOddCount(int[] arr)
        {
            int oddCount = 0;
            foreach(int n in arr)
            {
                if ( n % 2 != 0)
                {
                    oddCount++;
                }
            }
            return oddCount;
        }

        private int DetermineEvenCount(int[] arr)
        {
            int evenCount = 0;
            foreach (int n in arr)
            {
                if (n % 2 == 0)
                {
                    evenCount++;
                }
            }
            return evenCount;
        }


        private int[] GenerateArray(int length, int maxValue)
        {
            Random r = new Random();
            int[] arr = new int[length];
            int n = 0;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    n = r.Next(maxValue);
                } while (Contains(new List<int>(arr), n));
                arr[i] = n;
            }
            return arr;
        }

        private bool Contains(List<int> arrList, int n)
        {
            int index = arrList.FindIndex(0, arrList.Count - 1, x => x == n);
            if (index >= 0)
            {
                return true;
            }
            return false;
        }

        /*
        private bool Contains(int[] arr, int n)
        {
            foreach (int a in arr)
            {
                if (a == n)
                {
                    return true;
                }
            }
            return false;
        }
        */

        private void PrintArray(int[] arr)
        {
            Console.WriteLine("Printing Array");
            foreach (int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

    }
}
