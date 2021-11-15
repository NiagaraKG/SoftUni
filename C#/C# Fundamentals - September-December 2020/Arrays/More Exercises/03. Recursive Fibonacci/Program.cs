using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static long Get_Fibonacci(long n)
        {
            if(n == 2 || n == 1) { return 1; }
            return Get_Fibonacci(n-1) + Get_Fibonacci(n-2);
        }
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());         
            Console.WriteLine(Get_Fibonacci(n));
        }
    }
}
