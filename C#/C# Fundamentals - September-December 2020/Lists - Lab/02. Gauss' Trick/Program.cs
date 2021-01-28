using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> sums = new List<double>();
            for (int i = 0; i < (input.Count / 2) + (input.Count %2); i++)
            {
                double sum;
                if (i != input.Count - 1 - i)
                {
                    sum = input[i] + input[input.Count - 1 - i];
                }
                else { sum = input[i]; }
                sums.Add(sum);
            }
            Console.WriteLine(string.Join(" ", sums));
        }
    }
}
