using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle13
    {
        private int[] _array = null;
        public Puzzle13()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 1");
            Console.WriteLine("This program rotates an array given a pivot");
            Console.WriteLine("Enter # of elements to create in array (Enter number between 5 and 15):");
            string input = Console.ReadLine();
            int noOfElements = 0;
            if (int.TryParse(input, out noOfElements))
            {
                if (noOfElements < 5 || noOfElements > 15)
                {
                    Console.WriteLine("Entered number {0} is out of range, selecting 10 as size.", noOfElements);
                    noOfElements = 7;
                }
            }
            else
            {
                Console.WriteLine("Entered # of elements is not valid");
                return;
            }
            Console.WriteLine("Enter a pivot:");
            input = Console.ReadLine();
            int pivot = 0;
            if (int.TryParse(input, out pivot))
            {
                if (pivot > noOfElements || pivot < noOfElements)
                {
                    pivot = noOfElements / 2;
                    Console.WriteLine("Entered pivot {0} is out of array range, selecting {1} as pivot.", input, pivot);
                }
            }
            else
            {
                Console.WriteLine("Entered pivot is not valid");
                return;
            }

            InitializeArray(noOfElements);
            PrintArray();

            PerformRotate(pivot);

            Console.WriteLine("");
            Console.WriteLine("Result");
            PrintArray();
            Console.WriteLine("");
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
            _array.ToList().ForEach(x =>
           {
               Console.Write("{0}, ", x);
           });

        }

        private void PerformRotate(int pivot)
        {
            int j = pivot;
            int a = _array[j],  b = _array[j];
            for(int i = 0; i < _array.Length; i++)
            {
                
                if ( j >= pivot && j < _array.Length-1)
                {
                    a = b;
                    b = _array[j+1];
                    _array[j + 1] = a;
                    j++;
                    if (j == _array.Length)
                    {
                        j = -1;
                    }
                }
                else
                {
                    a = b;
                    b = _array[j + 1];
                    _array[j + 1] = a;
                    j++;
                }

            }
        }
    }
}
