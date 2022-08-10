using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
    public class Program
    {
        private static Dictionary<int, long> calculated = new Dictionary<int, long>();
        public static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            var counts = new int[first.Length +1, second.Length+1];
            for(int r = 1; r < counts.GetLength(0); r++)
            {
                for (int c = 1; c < counts.GetLength(1); c++)
                {
                    if(first[r - 1] == second[c - 1])
                    {
                        counts[r, c] = counts[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        counts[r, c] = Math.Max(counts[r, c - 1], counts[r - 1, c]);
                    }
                }
            }
            Console.WriteLine(counts[first.Length, second.Length]);
        }
    }
}