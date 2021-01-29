using System;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            int removed = 0;

            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++) { board[r, c] = row[c]; }
            }
            while (true)
            {
                int maxAttacks = 0, rowMaxAttacker = -1, colMaxAttacker = -1;
                for (int r = 0; r < n; r++)
                {

                    for (int c = 0; c < n; c++)
                    {
                        if (board[r, c] == 'K')
                        {
                            int attacks = CountAttacks(board, r, c);
                            if (attacks > maxAttacks) { maxAttacks = attacks; rowMaxAttacker = r; colMaxAttacker = c; }
                        }
                    }
                }
                if (maxAttacks == 0) { break; }
                board[rowMaxAttacker, colMaxAttacker] = '0';
                removed++;
            }
            Console.WriteLine(removed);
        }

        static int CountAttacks(char[,] board, int row, int col)
        {
            int br = 0;
            if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2, col - 1] == 'K') { br++; }
            if (row - 2 >= 0 && col + 1 < board.GetLength(0) && board[row - 2, col + 1] == 'K') { br++; }
            if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1, col - 2] == 'K') { br++; }
            if (row - 1 >= 0 && col + 2 < board.GetLength(0) && board[row - 1, col + 2] == 'K') { br++; }

            if (row + 2 < board.GetLength(0) && col - 1 >= 0 && board[row + 2, col - 1] == 'K') { br++; }
            if (row + 2 < board.GetLength(0) && col + 1 < board.GetLength(0) && board[row + 2, col + 1] == 'K') { br++; }
            if (row + 1 < board.GetLength(0) && col - 2 >= 0 && board[row + 1, col - 2] == 'K') { br++; }
            if (row + 1 < board.GetLength(0) && col + 2 < board.GetLength(0) && board[row + 1, col + 2] == 'K') { br++; }
            return br;
        }
    }
}
