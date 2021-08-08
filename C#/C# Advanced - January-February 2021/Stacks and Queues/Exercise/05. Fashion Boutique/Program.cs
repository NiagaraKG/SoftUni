using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(input);
            int sum = 0, racks = 1, capacity = int.Parse(Console.ReadLine());
            while (clothes.Any())
            {
                int current = clothes.Pop();
                if (sum + current <= capacity) { sum += current; }
                else { sum = current; racks++; }
            }
            Console.WriteLine(racks);
        }
    }
}
