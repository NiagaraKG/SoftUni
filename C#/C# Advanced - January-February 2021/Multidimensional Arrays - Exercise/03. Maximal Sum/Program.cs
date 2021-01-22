using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimentions[0], dimentions[1]];
            int max = int.MinValue;
            int[] maximal = new int[9];
            for (int r = 0; r < dimentions[0]; r++)
            {
                int[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int c = 0; c < dimentions[1]; c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            for (int r = 0; r < dimentions[0] - 2; r++)
            {
                for (int c = 0; c < dimentions[1] - 2; c++)
                {
                    int sum = matrix[r, c] + matrix[r + 1, c] + matrix[r + 2, c] + matrix[r, c + 1] + matrix[r + 1, c + 1] + matrix[r + 2, c + 1] + matrix[r, c + 2] + matrix[r + 1, c + 2] + matrix[r + 2, c + 2];
                    if (sum > max)
                    {
                        max = sum;
                        maximal[0] = matrix[r, c];
                        maximal[1] = matrix[r, c + 1];
                        maximal[2] = matrix[r, c + 2];
                        maximal[3] = matrix[r + 1, c];
                        maximal[4] = matrix[r + 1, c + 1];
                        maximal[5] = matrix[r + 1, c + 2];
                        maximal[6] = matrix[r + 2, c];
                        maximal[7] = matrix[r + 2, c + 1];
                        maximal[8] = matrix[r + 2, c + 2];
                    }
                }
            }
            Console.WriteLine("Sum = " + max);
            Console.WriteLine(maximal[0] + " " + maximal[1] + " " + maximal[2]);
            Console.WriteLine(maximal[3] + " " + maximal[4] + " " + maximal[5]);
            Console.WriteLine(maximal[6] + " " + maximal[7] + " " + maximal[8]);
        }
    }
}
