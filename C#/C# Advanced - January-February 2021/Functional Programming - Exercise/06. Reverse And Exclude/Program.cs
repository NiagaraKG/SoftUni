using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] collection = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
            int n = int.Parse(Console.ReadLine());
            Func<int, bool> divisible = x => x % n != 0;
            Console.WriteLine(string.Join(" ", collection.Where(divisible).ToArray()));
        }
    }
}
