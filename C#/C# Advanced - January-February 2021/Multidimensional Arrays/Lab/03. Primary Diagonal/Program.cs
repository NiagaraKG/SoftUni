using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sum = 0;
            for (int r = 0; r < n; r++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = row[c];
                }
                sum += matrix[r, r];
            }
            Console.WriteLine(sum);
        }
    }
}
