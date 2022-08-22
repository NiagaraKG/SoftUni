using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_01_21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                var currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = currRow[c];
                }
            }
            var sums = new int[rows, cols];
            sums[0, 0] = matrix[0, 0];
            for (int c = 1; c < cols; c++)
            {
                sums[0, c] = sums[0, c - 1] + matrix[0, c];
            }
            for (int r = 1; r < rows; r++)
            {
                sums[r, 0] = sums[r - 1, 0] + matrix[r, 0];
            }
            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    sums[r, c] = Math.Max(sums[r - 1, c], sums[r, c - 1]) + matrix[r, c];
                }
            }
            var path = new Queue<int>();
            int row = rows - 1, col = cols - 1;
            path.Enqueue(matrix[row,col]);
            while (row > 0 && col > 0)
            {
                if (sums[row - 1, col] > sums[row, col - 1]) { row--; }
                else { col--; }
                path.Enqueue(matrix[row, col]);
            }
            while (row > 0)
            {
                row--;
                path.Enqueue(matrix[row, col]);
            }
            while (col > 0)
            {
                col--;
                path.Enqueue(matrix[row, col]);
            }
            Console.WriteLine(path.Sum());
            Console.WriteLine(string.Join(" ", path));
        }
    }
}
