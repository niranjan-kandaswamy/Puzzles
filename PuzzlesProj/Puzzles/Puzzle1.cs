using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle1
    {
        private int[] _array = null;
        public Puzzle1()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 1");
            Console.WriteLine("This program finds a number that is most present in an unsorted array");
            Console.WriteLine("Enter # of elements to create in array (Enter number between 10 and 1000):");
            string input = Console.ReadLine();
            int noOfElements = 0;
            if (int.TryParse(input, out noOfElements))
            {
                if (noOfElements < 0 || noOfElements > 1000)
                {
                    Console.WriteLine("Entered number {0} is out of range, selecting 10 as size.", noOfElements);
                    noOfElements = 10;
                }
            }
            InitializeArray(noOfElements);
            PrintArray();
            FindNumber_UsingArray();
            //FindNumber_UsingDictionary();
            Console.WriteLine("End of Puzzle 1. Press enter to quit.");
            Console.ReadLine();
        }

        private void InitializeArray(int noOfElements)
        {
            Random rand = new Random();
            _array = new int[noOfElements];
            for (int i = 0; i < noOfElements; i++)
            {
                _array[i] = rand.Next(noOfElements);
            }
        }

        private void PrintArray()
        {
            Console.WriteLine("Printing Array :");
            int size = _array.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write(_array[i] + ",");
            }
            Console.WriteLine("");
        }

        private void FindNumber_UsingArray()
        {
            Console.WriteLine("Finding number using Array.");
            //_array.GroupBy()
            var sortedArr = from n in _array orderby n ascending select n;

            Console.WriteLine("Printing Sorted numbers :");
            foreach ( int n in sortedArr)
            {
                Console.Write(n + ",");
            }

            int[] arr = sortedArr.ToArray();
            int count = 0, number = 0, prevN = 0, prevCount = 0;
            for(int n = 0; n < arr.Length; n++)
            {
                if ( n+1 == arr.Length)
                {
                    if (arr[n - 1] == arr[n])
                    {
                        count++;
                    }
                }
                else if ( n > 0 )
                {
                    if (arr[n-1] == arr[n])
                    {
                        count++;
                        number = arr[n];
                    }
                    else
                    {
                        if (count > prevCount)
                        {
                            prevCount = count;
                            prevN = number;
                        }
                        count = 1;
                        number = arr[n];
                    }
                }
                else if ( n == 0)
                {
                    prevN = number = arr[n];
                    count = prevCount = 1;
                }
            }

            Console.WriteLine("\r\nResults:");
            if (prevCount > count)
            {
                Console.WriteLine("Number = {0}, Count = {1}", prevN, prevCount);
            }
            else
            {
                Console.WriteLine("Number = {0}, Count = {1}", number, count);
            }
        }

        private void FindNumber_UsingDictionary()
        {
            Console.WriteLine("Finding number using Dictionary.");
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach ( int n in _array)
            {
                if (dict.ContainsKey(n))
                {
                    dict[n] = dict[n] + 1;
                }
                else
                {
                    dict[n] = 1;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("******\r\nResults:");

            Console.WriteLine("Printing Array in ascending order");

            IEnumerable<KeyValuePair<int, int>> list = dict.OrderBy(x => x.Key);
            foreach ( KeyValuePair<int,int> item in list)
            {
                Console.Write("{0},", item.Key);
                for(int i = 1; i < item.Value; i++)
                {
                    Console.Write("{0},", item.Key);
                }
            }

            KeyValuePair<int,int> kvp = dict.OrderByDescending(x => x.Value).FirstOrDefault();

            Console.WriteLine("\r\nMaximum times found = {0}, Count = {1}", kvp.Key, kvp.Value);

            kvp = dict.OrderBy(x => x.Value).FirstOrDefault();

            Console.WriteLine("Minumum times found = {0}, Count = {1}", kvp.Key, kvp.Value);
        }
    }
}
