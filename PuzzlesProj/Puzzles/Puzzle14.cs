using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle14
    {
        private int[] _array = null;
        public Puzzle14()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 14");
            Console.WriteLine("This program finds a missing number in the array");

            int[] arr = GetArray(1);
            PrintArray(arr);
            int result = FindMissingNumber(arr);
            Console.WriteLine("Missing number = {0}", result);
            Console.WriteLine("***********");

            arr = GetArray(2);
            PrintArray(arr);
            result = FindMissingNumber(arr);
            Console.WriteLine("Missing number = {0}", result);
            Console.WriteLine("***********");

            arr = GetArray(3);
            PrintArray(arr);
            result = FindMissingNumber(arr);
            Console.WriteLine("Missing number = {0}", result);
            Console.WriteLine("***********");

            arr = GetArray(4);
            PrintArray(arr);
            result = FindMissingNumber(arr);
            Console.WriteLine("Missing number = {0}", result);
            Console.WriteLine("***********");

            arr = GetArray(5);
            PrintArray(arr);
            result = FindMissingNumber(arr);
            Console.WriteLine("Missing number = {0}", result);
            Console.WriteLine("***********");

            arr = GetArray(6);
            PrintArray(arr);
            result = FindMissingNumber(arr);
            Console.WriteLine("Missing number = {0}", result);
            Console.WriteLine("***********");
        }


        private int FindMissingNumber(int[] arr)
        {
            int result = -1;

            List<int> intList = new List<int>(arr);
            intList.Sort();

            PrintArray(intList.ToArray());

            for (int i = 0; i < intList.Count - 1; i++)
            {
                if (intList[i] + 1 == intList[i + 1] ||
                    intList[i] == intList[i + 1])
                {
                    continue;
                }
                else if (intList[i] + 1 <= 0 )
                {
                    continue;
                }
                else
                {
                    result = intList[i] + 1;
                    return result;
                }
            }

            return intList[intList.Count - 1] + 1;
        }

        private int[] GetArray(int problem)
        {
            int[] resultArr = null;
            switch (problem)
            {
                case 1:
                    resultArr = new int[] { 1, 2, 4, 6, 3, 7, 8 };
                    break;
                case 2:
                    resultArr = new int[] { 2, 3, -7, 6, 8, 1, -10, 15 };
                    break;
                case 3:
                    resultArr = new int[] { 1, 1, 0, -1, -2 };
                    break;
                case 4:
                    resultArr = new int[] { 2, 3, 7, 6, 8, -1, 10, 15, 0, 1 };
                    break;
                case 5:
                    resultArr = new int[] { 100 };
                    break;
                case 6:
                    resultArr = new int[] { 10000, 10001 };
                    break;
            }
            return resultArr;
        }

        private void PrintArray(int[] arr)
        {
            Console.WriteLine("Printing Array :");
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write(arr[i] + ",");
            }
            Console.WriteLine("");
        }

    }
}
