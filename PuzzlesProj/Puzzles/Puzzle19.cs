using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle19
    {
        public Puzzle19()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 18.");
            Console.WriteLine("This program contains program to ");
            Console.WriteLine("1. Convert string to integer ");

            Console.WriteLine("Enter a integer number :");
            string input = Console.ReadLine();
            Console.WriteLine("Converted number is '{0}'", ConverToInt(input));
        }

        private int ConverToInt(string input)
        {
            int result = 0;
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    int n = 0;
                    for (int i = 0, j = input.Length - 1; i < input.Length; i++, j--)
                    {
                        if (input[i] < '0' || input[i] > '9')
                        {
                            throw new InvalidOperationException("Invalid input");
                        }
                        n = (int)(input[i] - '0');
                        result += n * PowerOf(10, j);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = 0;
            }
            return result;
        }

        private int PowerOf(int n, int p)
        {
            int r = 1;
            for (int i = 0; i < p; i++)
            {
                r *= n;
            }
            return r;
        }
    }
}
