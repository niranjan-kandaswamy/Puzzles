using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle2
    {
        public Puzzle2()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 2");
            Console.WriteLine("This program prints the nth number in a Fibonacci series.");
            Console.WriteLine("Enter an index number to find in the series (Enter number between 1 and 100):");

            string input = Console.ReadLine();
            int index = 0;
            if (int.TryParse(input, out index))
            {
                if (index < 0 || index > 100)
                {
                    Random r = new Random();
                    index = r.Next(100);
                    Console.WriteLine("Entered number {0} is not valid or out of range, selecting {1} as index.", input, index);
                }
            }
            else
            {
                Random r = new Random();
                index = r.Next(100);
                Console.WriteLine("Entered number {0} is not valid or out of range, selecting {1} as index.", input, index);

            }


            Console.WriteLine("Result\r\n");
            Console.WriteLine("Number = {0}, Index = {1}", FindNumber(index), index);

        }

        private ulong FindNumber(int index)
        {
            ulong a = 0, b = 1;
            ulong n = 0;
            Console.Write("{0}", n);
            for (int count = 1; count < index; count++)
            {
                if ( count % 2 == 0 )
                {
                    a = a + b;
                    n = a;
                }
                else
                {
                    b = a + b;
                    n = b;
                }
                Console.Write(",{0}", n);
            }
            Console.WriteLine("");
            return n;
        }
    }
}
