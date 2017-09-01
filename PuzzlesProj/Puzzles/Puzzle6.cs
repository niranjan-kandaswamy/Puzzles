using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle6
    {
        public Puzzle6()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 6.");
            Console.WriteLine("This program finds pairs of numbers in an integer array, whose sum is equal to a given number.");

            Console.Write("Enter # of elements to generate in the array :");
            string input = Console.ReadLine();
            int count = 0;
            if ( !int.TryParse(input, out count))
            {
                Console.WriteLine("Invalid count entered. Choosing 10");
                count = 10;
            }
            int[] arr1 = GenerateArray(count); //new int [] { 9, 5, 11, 6};//
            Console.WriteLine("Printing 1st Array numbers:");
            arr1.OrderBy(x => x).ToList().ForEach(x =>
            {
                Console.Write("{0}, ", x);
            });

            Console.WriteLine("");
            Console.Write("Enter number to sum and search in array:");
            input = Console.ReadLine();
            int number = 0;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Invalid number entered. Choosing 10");
                number = 10;
            }

            Console.WriteLine("");
            List<int[]> resultArr = FindArrays(arr1, number);
            Console.WriteLine("Printing results.");
            resultArr.ForEach(x =>
            {
                Console.WriteLine("{0}, {1} = {2}", x[0], x[1], number);
            });
        }

        private int[] GenerateArray(int length)
        {
            Random r = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next(length);
            }
 
            return arr;
        }

        private List<int[]> FindArrays(int[] arr, int number)
        {
            List<int[]> result = new List<int[]>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == number)
                    {
                        result.Add(new int[2] { arr[i], arr[j] });
                    }
                }
            }

            return result;
        }
    }
}
