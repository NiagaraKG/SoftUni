using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class Program
    {
        private static Dictionary<int, long> calculated = new Dictionary<int, long>();
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(n));
        }

        private static long Fibonacci(int n)
        {
            if(calculated.ContainsKey(n)) { return calculated[n]; }
            if (n < 2) { return n; }
            var current = Fibonacci(n - 1) + Fibonacci(n - 2);
            calculated[n] = current;
            return current;
        }
    }
}