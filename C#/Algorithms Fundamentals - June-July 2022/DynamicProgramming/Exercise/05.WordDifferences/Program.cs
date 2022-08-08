using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingExercise
{
    public class Program
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            var table = new int[first.Length + 1, second.Length + 1];
            for (int r = 0; r < table.GetLength(0); r++) { table[r, 0] = r; }
            for (int c = 1; c < table.GetLength(1); c++) { table[0, c] = c; }
            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (first[r - 1] == second[c - 1]) { table[r, c] = table[r - 1, c - 1]; }
                    else
                    {
                        table[r, c] = Math.Min(table[r - 1, c], table[r, c - 1]) + 1;
                    }
                }
            }
            Console.WriteLine($"Deletions and Insertions: {table[first.Length, second.Length]}");
        }
    }
}