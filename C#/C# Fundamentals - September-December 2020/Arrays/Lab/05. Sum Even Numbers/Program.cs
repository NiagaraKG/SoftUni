using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int i in arr) { if(i % 2 == 0) { sum += i; } }
            Console.WriteLine(sum);
        }
    }
}
