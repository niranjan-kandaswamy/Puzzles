using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle12
    {
        public Puzzle12()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 12");
            Console.WriteLine("This program finds if the given number is an Armstrong number or not");
            Console.WriteLine("Enter a number (less than 1000):");
            string input = Console.ReadLine();
            int number = 0;
            if (int.TryParse(input, out number))
            {
                if (number < 0 || number > 1000)
                {
                    number = new Random(10).Next(1000);
                    Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, number);
                }
            }
            else
            {
                number = new Random(10).Next(1000);
                Console.WriteLine("Entered number {0} is not valid, selecting {1}", input, number);
            }

            Console.WriteLine("");
            Console.WriteLine("Result.");
            if (CheckNumberForArmstrong(number))
            {
                Console.WriteLine("Number {0} is Armstrong number.", number);
            }
            else
            {
                Console.WriteLine("Number {0} is NOT Armstrong number.", number);
            }

            Console.WriteLine("");
            Console.WriteLine("Generating Armstrong numbers between 10 and 10000");
            for(int i = 10;i< 10000; i++)
            {
                if (CheckNumberForArmstrong(i))
                {
                    Console.Write("{0}, ", i);
                }
            }

            Console.WriteLine("");
        }

        private bool CheckNumberForArmstrong(int number)
        {
            bool isArmstrong = false;

            int result = 0;
            int temp = number;
            int noOfDigits = number.ToString().Length;
            for(int i = 0; i < noOfDigits; i++)
            {
                int n = temp % 10;
                temp = temp / 10;
                result += FindPowerOfUsingRecursion(n, n, noOfDigits);
            }

            if ( result == number)
            {
                isArmstrong = true;
            }

            return isArmstrong;
        }

        private int FindPowerOfUsingRecursion(int result, int number, int factor)
        {
            if (factor > 1)
            {
                result *= number;
                factor--;
                return FindPowerOfUsingRecursion(result, number, factor);
            }
            return result;
        }
    }
}
