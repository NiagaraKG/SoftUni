using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> counts = new Dictionary<double, int>();
            for (int i = 0; i < values.Length; i++)
            {
                if (counts.ContainsKey(values[i]))
                {
                    counts[values[i]]++;
                }
                else
                {
                    counts.Add(values[i], 1);
                }
            }
            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
