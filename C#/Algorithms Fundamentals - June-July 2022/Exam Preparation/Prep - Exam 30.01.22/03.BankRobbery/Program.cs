using System;
using System.Collections.Generic;
using System.Linq;

namespace _30_01_22
{
    public class Program
    {
        public static void Main()
        {
            var boxes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int total = boxes.Sum(), Josh = total / 2;
            var sums = SumAll(boxes);
            while (!sums.ContainsKey(Josh)) { Josh--; }
            var Prakash = total - Josh;
            var jBoxes = FindSubset(sums, Josh).OrderBy(x=>x);
            Console.WriteLine(string.Join(" ", jBoxes));
            var pBoxes = boxes.Except(jBoxes).OrderBy(x => x);
            Console.WriteLine(string.Join(" ", pBoxes));
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

        private static Dictionary<int, int> SumAll(int[] boxes)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };
            foreach (var p in boxes)
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