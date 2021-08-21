using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];
            for (int r = 0; r < n; r++)
            {
                double[] row = Console.ReadLine().Split().Select(double.Parse).ToArray();
                matrix[r] = row;
            }
            for (int r = 0; r < n - 1; r++)
            {
                if (matrix[r].Length == matrix[r + 1].Length)
                {
                    for (int c = 0; c < matrix[r].Length; c++)
                    {
                        matrix[r][c] *= 2;
                        matrix[r + 1][c] *= 2;
                    }
                }
                else
                {
                    for (int c = 0; c < matrix[r].Length; c++) { matrix[r][c] /= 2; }
                    for (int c = 0; c < matrix[r+1].Length; c++) { matrix[r+1][c] /= 2; }
                }
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                int r = int.Parse(command[1]), c = int.Parse(command[2]), v = int.Parse(command[3]);
                if (r >= 0 && c >= 0 && r < matrix.Length && c < matrix[r].Length)
                {
                    if (command[0] == "Add")
                    {
                        matrix[r][c] += v;
                    }
                    else if (command[0] == "Subtract")
                    {
                        matrix[r][c] -= v;
                    }
                }
                command = Console.ReadLine().Split();
            }
            for (int r = 0; r < n; r++)
            {
                Console.WriteLine(string.Join(" ", matrix[r]));
            }
        }
    }
}
