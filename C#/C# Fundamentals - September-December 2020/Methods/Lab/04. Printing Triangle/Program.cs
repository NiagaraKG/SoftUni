using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintLine(i);
            }
            for (int i = n-1; i >= 1; i--)
            {
                PrintLine(i);
            }
        }

        static void PrintLine(int n)
        {            
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

    }
}
