using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle3
    {
        public Puzzle3()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 3");
            Console.WriteLine("This program merges 2 arrays.");
            Console.WriteLine("Program merges using 2 techniques - Using Indexes, Using Linq.");

            int[] arr1 = GenerateArray(15); //new int [] { 9, 5, 11, 6};//
            Console.WriteLine("Printing 1st Array numbers:");
            arr1.OrderBy(x => x).ToList().ForEach(x =>
            {
                Console.Write("{0}, ", x);
            });

            Console.WriteLine("");
            Console.WriteLine("");

            int[] arr2 = GenerateArray(10);//new int[] { 1, 12, 4, 2, 10 }; //
            Console.WriteLine("Printing 2nd Array numbers:");
            arr2.OrderBy(x => x).ToList().ForEach(x =>
            {
                Console.Write("{0},", x);
            });

            Console.WriteLine("");
            Console.WriteLine("");
            MergeArrays_UsingIndexes(arr1, arr2);

            Console.WriteLine("");
            MergeArrays_UsingLinq(arr1, arr2);
        }

        private int[] GenerateArray(int length)
        {
            Random r = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next(length * 10);
            }

            
            //arr.Select(x => (x * 3) ).Where(x => (x % 2 != 0)).ToList().ForEach(x=>
            //{
            //    Console.Write("{0} , ", x);
            //});

            return arr;
        }

        private void MergeArrays_UsingIndexes(int[] arr1, int[] arr2)
        {
            Console.WriteLine("Merging Arrays using Indexes");

            var arrlist1 = arr1.OrderBy(x => x).ToList();
            var arrlist2 = arr2.OrderBy(x => x).ToList();

            List<int> targetArr = null, sourceArr = null;
            if ( arrlist1[0] <= arrlist2[0])
            {
                targetArr = arrlist1;
                sourceArr = arrlist2;
            }
            else
            {
                targetArr = arrlist2;
                sourceArr = arrlist1;
            }

            int tcount = targetArr.Count;
            int scount = sourceArr.Count;
            for (int i = 0; i < tcount; i++)
            {
                for( int j = 0; j < scount; j++)
                {
                    if (targetArr[i] <= sourceArr[j])
                    {
                        if ( (i+1) < tcount)
                        {
                            if (targetArr[i+1] < sourceArr[j])
                            {
                                break;
                            }
                            else if(targetArr[i+1] >= sourceArr[j])
                            {
                                targetArr.Insert(i + 1, sourceArr[j]);
                                sourceArr.RemoveAt(j);

                                tcount = targetArr.Count;
                                i++;
                                scount = sourceArr.Count;
                                j--;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // add remaining if any
            targetArr.AddRange(sourceArr);

            Console.WriteLine("Completed merging. Printing Merged Array numbers:");
            targetArr.ToList().ForEach(x =>
            {
                Console.Write("{0},", x);
            });
            Console.WriteLine("");

        }

        private void MergeArrays_UsingLinq(int[] arr1, int[] arr2)
        {
            Console.WriteLine("Merging Arrays using LINQ");

            var sourceArr = arr1.OrderBy(x => x).ToList();
            var targetArr = arr2.OrderBy(x => x).ToList();

            targetArr.AddRange(sourceArr);

            var resultArr = targetArr.OrderBy(x => x).ToList();

            Console.WriteLine("Completed merging. Printing Merged Array numbers:");
            resultArr.ToList().ForEach(x =>
            {
                Console.Write("{0},", x);
            });
            Console.WriteLine("");
        }

    }
}
