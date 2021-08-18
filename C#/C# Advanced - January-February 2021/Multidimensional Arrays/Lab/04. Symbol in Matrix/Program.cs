using System;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            char wanted = char.Parse(Console.ReadLine());
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (matrix[r, c] == wanted)
                    {
                        Console.WriteLine($"({r}, {c})");
                        return;
                    }
                }
            }
            Console.WriteLine(wanted + " does not occur in the matrix");
        }
    }
}
