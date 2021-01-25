using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            PrintMIN(a, b, c);
        }

        static void PrintMIN(int a, int b, int c)
        {
            a = Math.Min(a, b);
            Console.WriteLine(Math.Min(a, c));
        }

    }
}
