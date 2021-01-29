using System;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentR = -1, currentC = -1, coals = 0;
            string[] directions = Console.ReadLine().Split();
            char[,] field = new char[n, n];
            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().Where(x => x != ' ').ToArray();
                for (int c = 0; c < n; c++)
                {
                    field[r, c] = row[c];
                    if (row[c] == 's') { currentR = r; currentC = c; }
                    if (row[c] == 'c') { coals++; }
                }
            }
            foreach (var d in directions)
            {
                if (d == "up" && currentR - 1 >= 0)
                {
                    currentR -= 1;
                    if (field[currentR, currentC] == 'c')
                    {
                        coals--;
                        field[currentR, currentC] = '*';
                        if (coals == 0) { Console.WriteLine($"You collected all coals! ({currentR}, {currentC})"); return; }
                    }
                    else if (field[currentR, currentC] == 'e') { Console.WriteLine($"Game over! ({currentR}, {currentC})"); return; }
                }
                else if (d == "down" && currentR + 1 < n)
                {
                    currentR += 1;
                    if (field[currentR, currentC] == 'c')
                    {
                        coals--;
                        field[currentR, currentC] = '*';
                        if (coals == 0) { Console.WriteLine($"You collected all coals! ({currentR}, {currentC})"); return; }
                    }
                    else if (field[currentR, currentC] == 'e') { Console.WriteLine($"Game over! ({currentR}, {currentC})"); return; }
                }
                else if (d == "left" && currentC - 1 >= 0)
                {
                    currentC -= 1;
                    if (field[currentR, currentC] == 'c')
                    {
                        coals--;
                        field[currentR, currentC] = '*';
                        if (coals == 0) { Console.WriteLine($"You collected all coals! ({currentR}, {currentC})"); return; }
                    }
                    else if (field[currentR, currentC] == 'e') { Console.WriteLine($"Game over! ({currentR}, {currentC})"); return; }
                }
                else if (d == "right" && currentC + 1 < n)
                {
                    currentC += 1;
                    if (field[currentR, currentC] == 'c')
                    {
                        coals--;
                        field[currentR, currentC] = '*';
                        if (coals == 0) { Console.WriteLine($"You collected all coals! ({currentR}, {currentC})"); return; }
                    }
                    else if (field[currentR, currentC] == 'e') { Console.WriteLine($"Game over! ({currentR}, {currentC})"); return; }
                }              
            }
            Console.WriteLine($"{coals} coals left. ({currentR}, {currentC})");
        }
    }
}
