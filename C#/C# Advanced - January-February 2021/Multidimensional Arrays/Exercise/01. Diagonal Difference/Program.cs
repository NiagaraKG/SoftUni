using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int first = 0, second = 0;
            for (int r = 0; r < n; r++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = row[c];
                }
                first += matrix[r, r];
                second += matrix[r,n-r-1];
            }
            Console.WriteLine(Math.Abs(first-second));
        }
    }
}
