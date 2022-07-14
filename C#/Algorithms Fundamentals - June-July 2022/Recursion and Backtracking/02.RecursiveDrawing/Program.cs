using System;

namespace RecursionAndBacktracking
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Draw(n);
        }

        public static void Draw(int n)
        {
            if (n == 0) return;
            Console.WriteLine(new string('*', n));
            Draw(n - 1);
            Console.WriteLine(new string('#', n));
        }

    }
}