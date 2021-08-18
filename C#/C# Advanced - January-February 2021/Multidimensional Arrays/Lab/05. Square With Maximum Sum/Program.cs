using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[dimentions[0], dimentions[1]];
            int max = int.MinValue;
            int[] square = new int[4];
            for (int r = 0; r < dimentions[0]; r++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int c = 0; c < dimentions[1]; c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            for (int r = 0; r < dimentions[0]-1; r++)
            {
                for (int c = 0; c < dimentions[1]-1; c++)
                {
                    int sum = matrix[r, c] + matrix[r + 1, c + 1] + matrix[r, c + 1] + matrix[r + 1, c];
                    if(sum>max) 
                    {
                        max = sum;
                        square[0] = matrix[r, c];
                        square[1] = matrix[r, c+1];
                        square[2] = matrix[r+1, c];
                        square[3] = matrix[r+1, c+1];
                    }
                }
            }
            Console.WriteLine(square[0] + " " + square[1]);
            Console.WriteLine(square[2] + " " + square[3]);
            Console.WriteLine(max);
        }
    }
}
