using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(dimentions[0]);
            Console.WriteLine(dimentions[1]);
            int[,] matrix = new int[dimentions[0], dimentions[1]];
            int sum = 0;
            for (int r = 0; r < dimentions[0]; r++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int c = 0; c < dimentions[1]; c++)
                {
                    matrix[r, c] = row[c];
                    sum += matrix[r, c];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
