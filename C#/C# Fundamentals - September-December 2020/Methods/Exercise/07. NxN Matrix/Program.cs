using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                PrintLine(n);
            }
        }

        static void PrintLine(int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += n + " ";
            }
            Console.WriteLine(result);
        }
    }
}
