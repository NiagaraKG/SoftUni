using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).Where(x => x % 2 == 0).ToArray();
            Queue<int> result = new Queue<int>(input);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
