using System;
using System.Collections.Generic;

namespace RecursionAndBacktracking
{
    public class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();
        public static void Main()
        {
            var board = new bool[8, 8];
            PlaceQueens(board, 0);
        }

        public static void PlaceQueens(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                Print(board);
                return;
            }
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlace(row, col))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(row + col);
                    board[row, col] = true;
                    PlaceQueens(board, row + 1);
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static void Print(bool[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[r, c])
                    {
                        Console.Write("* ");
                    }
                    else { Console.Write("- "); }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static bool CanPlace(int row, int col)
        {
            return !attackedRows.Contains(row) && !attackedCols.Contains(col) && !attackedLeftDiagonals.Contains(row - col) && !attackedRightDiagonals.Contains(row + col);
        }
    }
}