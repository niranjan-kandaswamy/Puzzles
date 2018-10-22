using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle17
    {
        public Puzzle17()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 17.");
            Console.WriteLine("This program finds Nth max number in an array");

            for (int i = 0; i < 7; i++)
            {
                int[] inputArr = GenerateArray((i+1) * 5);
                int noToFind = new Random().Next((i + 1) * 5);
                int index = FindIndexInArray(inputArr, noToFind);
                PrintArray(inputArr);
                Console.WriteLine("'{0}' found at position '{1}'", noToFind, index);
            }
        }

        private int FindIndexInArray(int[] inputArr, int noToFind)
        {
            int index = -1;
            index = SortArray(inputArr, 0, 1, noToFind);
            return index;
        }

        private int SortArray(int[]inputArary, int currentIndex, int compareIndex, int noToFind)
        {
            if (currentIndex >= inputArary.Length && compareIndex >= inputArary.Length)
            {
                for ( int i = 0;i < inputArary.Length; i++)
                {
                    if ( inputArary[i] == noToFind)
                    {
                        return i;
                    }
                }
                return -1;
            }
            else if (currentIndex < inputArary.Length && compareIndex == inputArary.Length)
            {
                return SortArray(inputArary, currentIndex + 1, currentIndex + 2, noToFind);
            }

            if (inputArary[currentIndex] > inputArary[compareIndex])
            {
                inputArary[currentIndex] = inputArary[compareIndex] + inputArary[currentIndex];
                inputArary[compareIndex] = inputArary[currentIndex] - inputArary[compareIndex];
                inputArary[currentIndex] = inputArary[currentIndex] - inputArary[compareIndex];
            }
            
            return SortArray(inputArary, currentIndex, ++compareIndex, noToFind);
        }

        private void PrintArray(int[] arr)
        {
            Console.WriteLine("Sorted array = ");
            foreach ( int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

        private int[] GenerateArray(int length)
        {
            Random r = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next(length * 10);
            }

            return arr;
        }
    }
}
