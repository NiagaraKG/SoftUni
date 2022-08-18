using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_01_21
{
    public class Program
    {
        private static int[,] counts;
        public static void Main()
        {
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split().Select(int.Parse).ToArray();
            CalculateCounts(first, second);
            int r = first.Length, c = second.Length;
            while (r > 0 && c > 0)
            {
                if (first[r - 1] == second[c - 1]) { r--; c--; }
                else if (counts[r, c - 1] >= counts[r - 1, c]) { c--; }
                else { r--; }
            }
            Console.WriteLine(counts[first.Length, second.Length]);
        }
        private static void CalculateCounts(int[] first, int[] second)
        {
            counts = new int[first.Length + 1, second.Length + 1];
            for (int r = 1; r < counts.GetLength(0); r++)
            {
                for (int c = 1; c < counts.GetLength(1); c++)
                {
                    if (first[r - 1] == second[c - 1])
                    {
                        counts[r, c] = counts[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        counts[r, c] = Math.Max(counts[r, c - 1], counts[r - 1, c]);
                    }
                }
            }
        }
    }
}
