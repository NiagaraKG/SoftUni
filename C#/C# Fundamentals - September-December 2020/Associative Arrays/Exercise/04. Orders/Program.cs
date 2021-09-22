using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();
            string[] command = Console.ReadLine().Split();
            while(command[0] != "buy")
            {
                if(products.ContainsKey(command[0]))
                {
                    products[command[0]][0] = double.Parse(command[1]);
                    products[command[0]][1] += double.Parse(command[2]);
                }
                else
                {
                    products.Add(command[0], new List<double> { double.Parse(command[1]), double.Parse(command[2]) });
                }
                command = Console.ReadLine().Split();
            }
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0]*item.Value[1]):F2}");
            }
        }
    }
}
