using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(x => x * 1.2).ToArray();
            foreach (var item in prices) { Console.WriteLine(item.ToString("0.00")); }
        }
    }
}
