using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++) { numbers[i] = i + 1; }
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int, bool> filter = x =>
            {
                foreach (var d in dividers)
                {
                    if (x % d != 0) { return false; }
                }
                return true;
            };
            Console.WriteLine(string.Join(" ", numbers.Where(filter)));
        }
    }
}
