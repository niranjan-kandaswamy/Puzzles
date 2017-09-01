using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle8
    {
        public Puzzle8()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 8.");
            Console.WriteLine("This program checks if the given string is a palindrome or not.");
            Console.Write("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("");
            bool result = CheckPalindrome_UsingArray(input);
            Console.WriteLine("Result from CheckPalindrome_UsingArray() ");
            if (result == true)
            {
                Console.WriteLine("Entered string '{0}' is Palindrome !", input);
            }
            else
            {
                Console.WriteLine("Entered string '{0}' is NOT a Palindrome !", input);
            }

            result = CheckPalindrome_UsingLinq(input);
            Console.WriteLine("Result from CheckPalindrome_UsingArray() ");
            if (result == true)
            {
                Console.WriteLine("Entered string '{0}' is Palindrome !", input);
            }
            else
            {
                Console.WriteLine("Entered string '{0}' is NOT a Palindrome !", input);
            }

        }

        private bool CheckPalindrome_UsingArray(string input)
        {
            
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            bool result = true;
            int len = input.Length;
            for(int i = 0, j = len-1; i < len /2; i++, j--)
            {
                if (input[i] != input[j])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private bool CheckPalindrome_UsingLinq(string input)
        {
            bool result = false;
            if (string.IsNullOrEmpty(input))
            {
                return result;
            }

            string reversed = string.Empty;
            input.Reverse().ToList().ForEach(
                x =>
                {
                    reversed += x;
                });


            Console.WriteLine("");
            Console.WriteLine("reversed='{0}'", reversed);


            if ( input == reversed)
            {
                result = true;
            }


            return result;
        }
    }
}
