using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle23
    {
        public Puzzle23()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 23.");
            Console.WriteLine("This program prints elements that can be added (from the input array) to form given number");

            int[] arr = GenerateArray(3, 50);
            PrintArray(arr);

            int num = new Random().Next(100);
            PrintNumbers(arr, num);
        }

        private void PrintNumbers(int[] numArr, int num)
        {
            int size = Fact(numArr.Length);
            //int[,] indexArr = CreateIndexArr(size, numArr.Length-1); // numArr.Length);
            int[,] indexArr = CreateIndexArr(size, numArr.Length); // numArr.Length);
            //int[,] indexArr = CreateIndexArr(size, numArr.Length); // numArr.Length);

            for (int i = 0; i < numArr.Length; i++)
            {
                for (int j = i + 1; j < numArr.Length; j++)
                {

                }
            }
        }

        private int Fact(int n)
        {
            int size = 1;
            for(int i = 1; i < n; i++)
            {
                size *= 2;
            }
            return size;
        }

        private int[,] CreateIndexArr(int row, int col)
        {
            Console.WriteLine("Creating IndexArr");
            int[,] indexArr = new int[row, col];
            int startNo = 0;
            List<string> list = new List<string>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++, startNo++)
                {
                    indexArr[i, j] = startNo;
                    string s = GetFormattedString(Convert.ToString(startNo, 2), col);
                    list.Add(s);
                    Console.WriteLine(s + " ");
                    //Console.Write(startNo + " ");
                }
                Console.WriteLine("");
            }

            return indexArr;
        }

        private string GetFormattedString(string s, int len)
        {
            string result = string.Empty;
            if (len > s.Length)
            {
                result = result.PadLeft(len - s.Length, '0');
            }
            result += s;
            return result;
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
