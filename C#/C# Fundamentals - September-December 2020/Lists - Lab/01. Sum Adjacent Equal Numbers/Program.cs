using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            for (int i = 1; i < numbers.Count; i++)
            {
                if(numbers[i] == numbers[i-1])
                {
                    numbers[i - 1] = 2 * numbers[i];
                    numbers.RemoveAt(i--);
                    if (i > 0) { i--; }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
