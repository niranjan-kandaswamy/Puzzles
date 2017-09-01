using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle7
    {
        Random _random = new Random();
        public Puzzle7()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 7.");
            Console.WriteLine("This program finds the number of digits set in a given number.");
            Console.Write("Enter a number:");
            string input = Console.ReadLine();
            int number = 0;
            if (!int.TryParse(input, out number))
            {
                number = _random.Next(1000);
                Console.WriteLine("Invalid number entered. Choosing {0}", number);
            }

            Console.WriteLine("");
            Console.WriteLine("No of Digits set in {0} is {1}", number, FindNoOfDigitsSet(number));
        }

        private int FindNoOfDigitsSet(int number)
        {
            int n = number;
            int count = 0;
            while (number > 0)
            {
                if ( (number & 1) == 1)
                {
                    count++;
                }
                number >>= 1;
            }
            return count;
        }
    }
}
