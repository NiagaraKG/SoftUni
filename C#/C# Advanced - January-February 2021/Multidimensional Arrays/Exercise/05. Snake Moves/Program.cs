using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            char[,] matrix = new char[dimentions[0], dimentions[1]];
            int i = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (r % 2 == 0) { matrix[r, c] = snake[i]; }
                    else { matrix[r, dimentions[1] - 1 - c] = snake[i]; }
                    i++;
                    if (i == snake.Length) { i = 0; }
                }
            }
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
