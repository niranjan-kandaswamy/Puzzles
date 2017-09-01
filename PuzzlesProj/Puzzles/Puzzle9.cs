using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle9
    {
        public Puzzle9()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 9.");
            Console.WriteLine("This program checks duplicate characters in a string.");
            Console.Write("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Result.");
            Console.WriteLine("Duplicate characters in input string '{0}' are as follows:", input);

            char[] resultArr = FindDuplicateCharacters(input);
            resultArr.ToList().ForEach(x =>
            {
                Console.Write("{0}", x);
            });

            Console.WriteLine("");
            Console.WriteLine("Result after removing duplicate characters:");
            string result = RemoveDuplicateCharacters(input);
            Console.WriteLine(result);
        }

        private char[] FindDuplicateCharacters(string input)
        {
            char[] resultArr = new char[] { };

            char[] inputArr = input.ToArray();
            for(int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if ( inputArr[i] == inputArr[j])
                    {
                        if (!resultArr.Contains(inputArr[i]))
                        {
                            Array.Resize(ref resultArr, resultArr.Length + 1);
                            resultArr[resultArr.Length - 1] = inputArr[i];
                        }
                    }
                }
            }


            return resultArr;
        }

        private string RemoveDuplicateCharacters(string input)
        {
            string result = string.Empty;
            List<char> tempList = input.ToList().Distinct().ToList();
            result = string.Join("", tempList.ToArray());
            return result;
        }
    }
}
