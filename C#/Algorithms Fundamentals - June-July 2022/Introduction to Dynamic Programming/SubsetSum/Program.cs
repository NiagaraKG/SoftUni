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
            var nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());
            var sums = GetAllSums(nums);
            if (sums.ContainsKey(target))
            {
                var usedNums = FindSubset(sums, target);
                Console.WriteLine(string.Join(", ", usedNums));
            }
            else { Console.WriteLine("Not possible"); }
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var result = new List<int>();
            while(target> 0)
            {
                int current = sums[target];
                result.Add(current);
                target -= current;                
            }
            return result;
        }

        private static Dictionary<int, int> GetAllSums(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };
            foreach (var n in nums)
            {
                var currentSums = sums.Keys.ToArray();
                foreach (var s in currentSums)
                {
                    var sum = s + n;
                    if (!sums.ContainsKey(sum))
                    {
                        sums.Add(sum, n);
                    }
                }
            }
            return sums;
        }
    }
}