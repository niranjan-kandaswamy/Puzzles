using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle11
    {
        public Puzzle11()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 11");
            Console.WriteLine("This program finds factorial of a given number using recursion");
            Console.WriteLine("Enter a number (less than 10):");
            string input = Console.ReadLine();
            int number = 0;
            if (int.TryParse(input, out number))
            {
                if (number < 0 || number > 10)
                {
                    number = new Random().Next(10);
                    Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, number);
                }
            }
            else
            {
                number = new Random().Next(10);
                Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, number);
            }

            Console.WriteLine("");
            Console.WriteLine("Result.");
            Console.WriteLine("FindFactorUsingLoop(): Factor of {0} is {1}", number, FindFactorUsingLoop(number));

            Console.WriteLine("");
            Console.WriteLine("FindFactorUsingRecursion(): Factor of {0} is {1}", number, FindFactorUsingRecursion(number, number));
        }

        private int FindFactorUsingLoop(int number)
        {
            int factor = number;
            for (int i = number - 1; i > 0; i--)
            {
                factor = factor * i;
            }
            return factor;
        }

        private int FindFactorUsingRecursion(int number, int factor)
        {
            if (factor > 1)
            {
                factor--;
                number *= (factor);
                
                return FindFactorUsingRecursion(number , factor);
            }
            return number;
        }
    }
}
