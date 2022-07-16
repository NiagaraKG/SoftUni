using System;
using System.Collections.Generic;

namespace RecursionAndBacktracking
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            var field = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                string row = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    field[r, c] = row[c];
                }
            }
            Search(field, 0, 0, new List<string>(), string.Empty);
        }

        public static void Search(char[,] field, int row, int col, List<string> path, string direction)
        {
            if (row < 0 || col < 0 || row >= field.GetLength(0) || col >= field.GetLength(1) || field[row, col] == '*' || field[row, col] == 'v')
            {
                return;
            }
            path.Add(direction);
            if (field[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, path));
                path.RemoveAt(path.Count - 1);
                return;
            }
            field[row, col] = 'v';
            Search(field, row - 1, col, path, "U");
            Search(field, row + 1, col, path, "D");
            Search(field, row, col - 1, path, "L");
            Search(field, row, col + 1, path, "R");
            field[row, col] = '-';
            path.RemoveAt(path.Count - 1);
        }

    }
}