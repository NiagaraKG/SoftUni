using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingExercise
{
    public class Program
    {
        static void Main()
        {
            var presents = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int total = presents.Sum(), Alan = total / 2;
            var sums = SumAll(presents);
            while (!sums.ContainsKey(Alan)) { Alan--; }
            var Bob = total - Alan;
            Console.WriteLine($"Difference: {Bob - Alan}");
            Console.WriteLine($"Alan:{Alan} Bob:{Bob}");
            var aPresents = FindSubset(sums, Alan);
            Console.WriteLine($"Alan takes: {string.Join(" ", aPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();
            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);
                target -= element;
            }
            return subset;
        }

        private static Dictionary<int, int> SumAll(int[] presents)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };
            foreach (var p in presents)
            {
                var currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = sum + p;
                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, p);
                    }
                }
            }
            return sums;
        }
    }
}