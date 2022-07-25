using System;
using System.Linq;
using System.Collections.Generic;

namespace SearchingSortingAndGreedyAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            var coins = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x => x));
            int target = int.Parse(Console.ReadLine());
            Dictionary<int, int> used = new Dictionary<int, int>();
            int total = 0;
            while (target > 0 && coins.Count > 0)
            {
                var current = coins.Dequeue();
                var count = target / current;
                if (count != 0)
                {
                    target %= current;
                    used.Add(current, count);
                    total += count;
                }
            }
            if(target > 0) { Console.WriteLine("Error"); }
            else
            {
                Console.WriteLine($"Number of coins to take: {total}");
                foreach (var kvp in used)
                {
                    Console.WriteLine($"{kvp.Value} coin(s) with value {kvp.Key}");
                }
            }
        }        
    }
}