using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzlesProj.Puzzles
{
    internal class Puzzle15
    {
        public Puzzle15()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Puzzle 15");
            Console.WriteLine("This program finds occurrence of 'AA' or 'BB' or 'CC' and removes it");

            string result = RemovePattern("ACCAABBC");
            Console.WriteLine("Result = '{0}'", result);

            result = RemovePattern("ACCAAABBABCCBC");
            Console.WriteLine("Result = '{0}'", result);
        }

        private string RemovePattern(string input)
        {
            if (!string.IsNullOrEmpty(input) && input.Trim().Length > 0 )
            {
                string tempStr = input.Trim();
                int index = 0;

                while ( tempStr.Length > 0)
                {
                    index = tempStr.IndexOf("AA");
                    if ( index > -1 )
                    {
                        tempStr = tempStr.Remove(index, 2);
                        continue;
                    }
                    
                    index = tempStr.IndexOf("BB");
                    if (index > -1)
                    {
                        tempStr = tempStr.Remove(index, 2);
                        continue;
                    }

                    index = tempStr.IndexOf("CC");
                    if (index > -1)
                    {
                        tempStr = tempStr.Remove(index, 2);
                        continue;
                    }

                    
                    break;
                }
                return tempStr;
            }
            return input;
            
        }


    }
}
