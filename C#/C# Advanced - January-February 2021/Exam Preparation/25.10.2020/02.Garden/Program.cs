using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] garden = new int[dimentions[0], dimentions[1]];
            Dictionary<int, int> flowers = new Dictionary<int, int>();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Bloom")
            {
                int x = int.Parse(command[0]);
                int y = int.Parse(command[1]);
                if (x < 0 || x >= dimentions[0]) { Console.WriteLine("Invalid coordinates."); }
                else if (y < 0 || y >= dimentions[1]) { Console.WriteLine("Invalid coordinates."); }
                else { flowers.Add(x, y); }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var f in flowers)
            {
                garden[f.Key, f.Value]++;
                int row = f.Key - 1, col = f.Value;
                while (row >= 0) { garden[row, col]++;  row--; }
                row = f.Key + 1;
                while (row < dimentions[0]) { garden[row, col]++; row++; }

                row = f.Key; col = f.Value - 1;
                while (col >= 0) { garden[row, col]++; col--; }
                col = f.Value + 1;
                while (col < dimentions[0]) { garden[row, col]++; col++; }
            }
            for (int r = 0; r < dimentions[0]; r++)
            {
                for (int c = 0; c < dimentions[1]; c++)
                {
                    Console.Write(garden[r,c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
