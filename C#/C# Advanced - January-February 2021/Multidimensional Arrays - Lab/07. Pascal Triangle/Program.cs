using System;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] matrix = new long[n][];
            long[] row = new long[1];
            row[0] = 1;
            matrix[0] = row;
            Console.WriteLine(string.Join(" ", row));
            for (int i = 1; i < n; i++)
            {
                row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    row[j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                }
                matrix[i] = row;
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
