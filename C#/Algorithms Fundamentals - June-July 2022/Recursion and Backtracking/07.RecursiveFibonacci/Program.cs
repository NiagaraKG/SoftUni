using System;

namespace RecursionAndBacktracking
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(n+1));
        }

        public static int Fibonacci(int n)
        {
            if (n <= 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

    }
}