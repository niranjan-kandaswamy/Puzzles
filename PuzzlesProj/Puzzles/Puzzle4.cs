using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle4
    {
        public Puzzle4()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 4.");
            Console.WriteLine("This program swaps 2 numbers without using 3rd variable");

            Console.WriteLine("Enter positive number x=");
            string numX = int.MaxValue.ToString();//Console.ReadLine();
            Console.WriteLine("Enter positive number y=");
            string numY = (int.MaxValue - 1).ToString() ; //Console.ReadLine();
            Random r = new Random();
            uint x = 0, y = 0;
            if (uint.TryParse(numX, out x) == false)
            {
                x = (uint)r.Next(1000);
                Console.WriteLine("NumX is not valid integer, Choosing a random number : {0}", x);
            }

            if (uint.TryParse(numY, out y) == false)
            {
                y = (uint)r.Next(1000);
                Console.WriteLine("NumY is not valid integer, Choosing a random number : {0}", y);
            }

            Console.WriteLine("Numbers are X = {0}, Y = {1}", x, y);

            Swap_UsingAddition(x, y);

            Swap_UsingBitwiseOperators(x, y);
        }

        private void Swap_UsingAddition(uint x, uint y)
        {
            Console.WriteLine("Swap_UsingAddition()");
            x = x + y;
            y = x - y;
            x = x - y;

            Console.WriteLine("Result. X = {0}, Y = {1}", x, y);
        }

        private void Swap_UsingBitwiseOperators(uint x, uint y)
        {
            Console.WriteLine("Swap_UsingBitwiseOperators()");
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;

            Console.WriteLine("Result. X = {0}, Y = {1}", x, y);
        }
    }
}
