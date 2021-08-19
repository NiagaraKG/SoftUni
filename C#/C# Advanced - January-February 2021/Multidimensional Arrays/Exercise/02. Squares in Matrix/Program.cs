using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int br = 0;
            char[,] matrix = new char[dimentions[0], dimentions[1]];
            for (int r = 0; r < dimentions[0]; r++)
            {
                char[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int c = 0; c < dimentions[1]; c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            for (int r = 0; r < dimentions[0]-1; r++)
            {
                for (int c = 0; c < dimentions[1] - 1; c++)
                {
                    if(matrix[r,c] == matrix[r,c+1] && matrix[r,c] == matrix[r+1,c] && matrix[r, c] == matrix[r + 1, c+1]) { br++; }
                }
            }
            Console.WriteLine(br);
        }
    }
}
