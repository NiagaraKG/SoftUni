using System;

namespace SumOfCoins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }
        private static long Factorial(int n)
        {
            if(n == 0) { return 1; }
            if (n == 1) { return n; }
            return n * Factorial(n - 1);
        }
    }
}
