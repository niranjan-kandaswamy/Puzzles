using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle16
    {

        public Puzzle16()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 16.");
            Console.WriteLine("This program finds the position of a string within another string using SubString and without SubString methods");
            string inputString = "FindWithoutUsingSubstring";
            string searchString = "in";
            FindUsingSubstring(inputString, searchString);
            FindWithoutUsingSubstring(inputString, searchString);
        }

        private void FindUsingSubstring(string inputString, string searchString)
        {
            Console.WriteLine("Finding string using SubString");
            int index = inputString.IndexOf(searchString);
            if ( index > 0 )
            {
                index++;
                Console.WriteLine("'{0}' is found at position '{1}' within search string '{2}'", searchString, index, inputString);
            }
        }

        private void FindWithoutUsingSubstring(string inputString, string searchString)
        {
            Console.WriteLine("Finding string without using SubString");
            int index = -1;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == searchString[0])
                {
                    index = i;
                    for (int j = 1; j < searchString.Length; j++)
                    {
                        if (!((i + j) < inputString.Length &&
                            inputString[i + j] == searchString[j]))
                        {
                            index = -1;
                            break;
                        }

                    }

                    if (index > 0)
                    {
                        break;
                    }
                }
            }

            if (index > 0)
            {
                index++;
                Console.WriteLine("'{0}' is found at position '{1}' within search string '{2}'", searchString, index, inputString);
            }
            else
            {
                Console.WriteLine("'{0}' is NOT found within search string '{1}'", searchString, inputString);
            }
        }

    }

}
