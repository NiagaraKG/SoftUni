using System;
using System.Linq;
using System.Collections.Generic;

namespace SearchingSortingAndGreedyAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            var universe = Console.ReadLine().Split(", ").Select(int.Parse).ToHashSet();
            int n = int.Parse(Console.ReadLine());
            var subsets = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                subsets.Add(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            }
            var used = new List<int[]>();
            while (universe.Count > 0)
            {
                var current = subsets.OrderByDescending(s => s.Count(e => universe.Contains(e))).FirstOrDefault();
                used.Add(current);
                subsets.Remove(current);
                foreach (var num in current)
                {
                    universe.Remove(num);
                }
            }
            Console.WriteLine($"Sets to take ({used.Count}):");
            foreach (var s in used)
            {
                Console.WriteLine(string.Join(", ", s));
            }
        }
    }
}