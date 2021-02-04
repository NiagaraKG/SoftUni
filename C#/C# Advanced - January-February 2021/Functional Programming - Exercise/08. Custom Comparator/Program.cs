using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort(numbers, (x, y) =>
            {
                if (x % 2 != 0 && y % 2 == 0) { return 1; }
                else if (x % 2 == 0 && y % 2 != 0) { return -1; }
                return x.CompareTo(y);
            });
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
