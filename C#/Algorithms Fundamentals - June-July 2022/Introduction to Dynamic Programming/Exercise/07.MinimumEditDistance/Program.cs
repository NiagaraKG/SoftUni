using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingExercise
{
    public class Program
    {
        static void Main()
        {
            int rCost = int.Parse(Console.ReadLine());
            int iCost = int.Parse(Console.ReadLine());
            int dCost = int.Parse(Console.ReadLine());
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            var table = new int[first.Length + 1, second.Length + 1];
            for (int c = 1; c < table.GetLength(1); c++) { table[0, c] = table[0,c-1]+iCost; }
            for (int r = 1; r < table.GetLength(0); r++) { table[r, 0] = table[r-1,0] + dCost; }
            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (first[r - 1] == second[c - 1]) { table[r, c] = table[r - 1, c - 1]; }
                    else
                    {
                        int replace = table[r - 1, c - 1] + rCost;
                        int delete = table[r - 1, c] + dCost;
                        int insert = table[r, c - 1] + iCost;
                        table[r, c] = Math.Min(replace, Math.Min(delete, insert));
                    }
                }
            }
            Console.WriteLine($"Minimum edit distance: {table[first.Length, second.Length]}");
        }
    }
}