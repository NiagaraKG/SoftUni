using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] quantities = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(quantities);
            Console.WriteLine(orders.Max());
            while (orders.Count > 0)
            {
                int current = orders.Peek();
                if (n >= current) { n -= current; orders.Dequeue(); }
                else
                {
                    Console.WriteLine("Orders left: " + string.Join(" ", orders));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
