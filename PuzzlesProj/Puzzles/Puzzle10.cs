using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle10
    {
        public Puzzle10()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 10");
            Console.WriteLine("This program finds Power of a given number using recursion");
            Console.WriteLine("Enter a number (less than 100):");
            string input = Console.ReadLine();
            int number = 0;
            if (int.TryParse(input, out number))
            {
                if (number < 0 || number > 100)
                {
                    number = new Random().Next(100);
                    Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, number);
                }
            }
            else
            {
                number = new Random().Next(100);
                Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, number);
            }

            Console.WriteLine("Enter a factor (less than 10):");
            input = Console.ReadLine();
            int factor = 0;
            if (int.TryParse(input, out factor))
            {
                if (factor < 0 || factor > 10)
                {
                    factor = new Random().Next(10);
                    if (factor ==0)
                    {
                        factor++;
                    }
                    Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, factor);
                }
            }
            else
            {
                number = new Random().Next(10);
                if (factor == 0)
                {
                    factor++;
                }
                Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, factor);
            }

            Console.Write("Number = {0}, factor = {1}", number, factor);

            Console.WriteLine("");
            Console.WriteLine("Result.");
            Console.WriteLine("FindFactorUsingLoop={0}", FindPowerOfUsingLoop(number, factor));

            Console.WriteLine("");
            Console.WriteLine("FindFactorUsingRecursion={0}", FindPowerOfUsingRecursion(number, number, factor));
        }

        private int FindPowerOfUsingLoop(int number, int factor)
        {
            int result = 1;
            for ( int i = 0; i < factor; i++)
            {
                result *= number;
            }
            return result;
        }

        private int FindPowerOfUsingRecursion(int result, int number, int factor)
        {
            if (factor == 1)
            {
                return result;
            }
            factor--;
            return FindPowerOfUsingRecursion(result * number, number, factor);
        }
    }
}
