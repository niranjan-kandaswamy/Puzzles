using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle5
    {
        public Puzzle5()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 5.");
            Console.WriteLine("This program checks if two strings are anagram or not.");

            Console.Write("Enter string1 :");
            string string1 = Console.ReadLine();

            Console.Write("Enter string1 :");
            string string2 = Console.ReadLine();

            if ( CheckStringForAnagram(string1, string2))
            {
                Console.WriteLine("The two strings '{0}' and '{1}' are Anagram.", string1, string2);
            }
            else
            {
                Console.WriteLine("The two strings '{0}' and '{1}' are NOT Anagram.", string1, string2);
            }

        }

        private bool CheckStringForAnagram(string str1, string str2)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(str1) && !string.IsNullOrEmpty(str1))
            {
                if ( str1.Length == str1.Length)
                {
                    result = true;
                    str1.ToCharArray().ToList().ForEach(x =>
                    {
                        if ( !str2.Contains(x))
                        {
                            result = false;
                        }
                    });
                }
            }

            return result;
        }
    }
}
