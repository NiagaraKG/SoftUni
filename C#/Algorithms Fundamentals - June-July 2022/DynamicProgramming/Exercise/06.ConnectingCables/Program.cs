using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingExercise
{
    public class Program
    {
        private static Dictionary<int, long> calculated = new Dictionary<int, long>();
        public static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = first.ToArray();
            Array.Sort(second);
            var counts = new int[first.Length + 1, second.Length + 1];
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
            Console.WriteLine($"Maximum pairs connected: {counts[first.Length, second.Length]}");
        }
    }
}