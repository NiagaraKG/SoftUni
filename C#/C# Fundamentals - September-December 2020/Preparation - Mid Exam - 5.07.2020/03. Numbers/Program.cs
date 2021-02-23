using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> above = new List<double>();
            double av = input.Average();
            foreach (var item in input)
            { if (item > av) { above.Add(item); } }
            if(above.Count == 0) { Console.WriteLine("No"); return; }
            above.Sort((x, y) => y.CompareTo(x));
            for (int i = 0; i < above.Count && i < 5; i++)
            {
                Console.Write(above[i] + " ");
            }
        }
    }
}
