using System;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] field = new int[n, n];
            for (int r = 0; r < n; r++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < n; c++) { field[r, c] = row[c]; }
            }
            string[] pairs = Console.ReadLine().Split(" ");
            for (int i = 0; i < pairs.Length; i++)
            {
                int[] coordinates = pairs[i].Split(",").Select(int.Parse).ToArray();
                int x = coordinates[0], y = coordinates[1];
                if (field[x, y] > 0)
                {
                    int power = field[x, y];
                    field[x, y] = 0;
                    if (x-1>=0 && field[x - 1, y] >0) { field[x - 1, y] -= power; }
                    if (x+1<n && field[x + 1, y] > 0) { field[x + 1, y] -= power; }
                    if (y-1>=0 && field[x, y-1] > 0) { field[x, y-1] -= power; }
                    if (y+1<n && field[x, y+1] > 0) { field[x, y+1] -= power; }
                    if(x-1 >=0 && y-1 >=0 && field[x - 1, y-1] > 0) { field[x - 1, y - 1] -= power; }
                    if(x-1 >=0 && y+1 <n && field[x - 1, y+1] > 0) { field[x - 1, y + 1] -= power; }
                    if(x+1 <n && y-1 >=0 && field[x + 1, y-1] > 0) { field[x + 1, y - 1] -= power; }
                    if(x+1 <n && y+1 <n && field[x + 1, y+1] > 0) { field[x + 1, y + 1] -= power; }
                }
            }
            int br = 0, sum = 0;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (field[r, c] > 0) { br++; sum += field[r, c]; }
                }
            }
            Console.WriteLine("Alive cells: " + br);
            Console.WriteLine("Sum: " + sum);
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++) { Console.Write(field[r, c] + " "); }
                Console.WriteLine();
            }
        }
    }
}
