using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int[] player = new int[2];
            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    field[r, c] = row[c];
                    if (field[r, c] == 'f')
                    {
                        player[0] = r;
                        player[1] = c;
                    }
                }
            }
            bool finished = false;
            for (int i = 0; i < commands; i++)
            {
                field[player[0], player[1]] = '-';
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up": player[0]--; break;
                    case "down": player[0]++; break;
                    case "left": player[1]--; break;
                    case "right": player[1]++; break;
                }
                if(player[0] < 0) { player[0] += n; }
                else if(player[0] >= n) { player[0] -= n; }
                if(player[1] < 0) { player[1] += n; }
                else if(player[1] >= n) { player[1] -= n; }
                if (field[player[0], player[1]] == 'B')
                {
                    switch (direction)
                    {
                        case "up": player[0]--; break;
                        case "down": player[0]++; break;
                        case "left": player[1]--; break;
                        case "right": player[1]++; break;
                    }
                }
                else if (field[player[0], player[1]] == 'T')
                {
                    switch (direction)
                    {
                        case "up": player[0]++; break;
                        case "down": player[0]--; break;
                        case "left": player[1]++; break;
                        case "right": player[1]--; break;
                    }
                }
                if (player[0] < 0) { player[0] += n; }
                else if (player[0] >= n) { player[0] -= n; }
                if (player[1] < 0) { player[1] += n; }
                else if (player[1] >= n) { player[1] -= n; }
                if (field[player[0], player[1]] == 'F')
                {
                    field[player[0], player[1]] = 'f';
                    finished = true; break;
                }
                field[player[0], player[1]] = 'f';
            }
            if(finished) { Console.WriteLine("Player won!"); }
            else { Console.WriteLine("Player lost!"); }
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(field[r,c]);
                }
                Console.WriteLine();
            }
        }
    }
}
