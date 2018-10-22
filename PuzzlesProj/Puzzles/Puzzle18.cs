using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle18
    {
        public Puzzle18()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 18.");
            Console.WriteLine("This program contains program to ");
            Console.WriteLine("1. Reverse a string ");
            Console.WriteLine("2. Finds a duplicate letter and removes it from the string ");

            Console.WriteLine("Enter a string :");
            string input = Console.ReadLine();
            Console.WriteLine("Reversed string is '{0}'", Reverse(input));
            Console.WriteLine("Duplicate removed string is '{0}'", RemoveDuplicate(input));
        }

        private string Reverse(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                char[] result = new char[input.Length];
                ReverseUsingRecursion(input, 0, ref result);
                return new string(result);
            }
            return input;
        }

        private void ReverseUsingRecursion(string input, int index, ref char[] result)
        {
            if (index < (input.Length / 2))
            {
                char ch = input[input.Length - (index + 1)];
                result[input.Length - (index + 1)] = input[index];
                result[index] = ch;
                ReverseUsingRecursion(input, ++index, ref result);
            }
            else if (input.Length % 2 != 0 )
            {
                result[index] = input[index];
            }
            return;
        }

        private string RemoveDuplicate(string inputString)
        {
            return RemoveDuplicateUsingRecursion(inputString, 0);
        }

        private string RemoveDuplicateUsingRecursion(string input, int index)
        {
            char[] inArr = input.ToCharArray();
            int i = index;
            for (int j = index + 1; i < inArr.Length && j < inArr.Length; j++)
            {
                if (inArr[i] == inArr[j])
                {
                    for (int k = j, l = j + 1; l < inArr.Length; k++, l++)
                    {
                        inArr[k] = inArr[l];
                    }
                    inArr = new string(inArr).Remove(inArr.Length-1).ToCharArray();
                }
            }

            if (i == inArr.Length)
            {
                return new string(inArr);
            }
            else
            {
                return RemoveDuplicateUsingRecursion(new string(inArr), ++i);
            }
        }
    }
}
