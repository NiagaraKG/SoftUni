using System;
using System.Collections.Generic;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];
            int[] snake = new int[2];
            List<int> burrows = new List<int>();
            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    territory[r, c] = row[c];
                    if (territory[r, c] == 'S') { snake[0] = r; snake[1] = c; }
                    else if (territory[r, c] == 'B') { burrows.Add(r); burrows.Add(c); }
                }
            }
            int food = 0;
            bool isOut = false;
            string command = Console.ReadLine();        
            while (food < 10)
            {
                territory[snake[0], snake[1]] = '.';
                switch (command)
                {
                    case "up": snake[0]--; break;
                    case "down": snake[0]++; break;
                    case "left": snake[1]--; break;
                    case "right": snake[1]++; break;
                }
                if(snake[0] < 0 || snake[0] >= n) { isOut = true; break; }
                if(snake[1] < 0 || snake[1] >= n) { isOut = true; break; }
                if(territory[snake[0], snake[1]] == '*') 
                {
                    food++;
                    if(food>=10) 
                    {
                        territory[snake[0], snake[1]] = 'S';
                        break; 
                    }
                }
                else if(territory[snake[0], snake[1]] == 'B')
                {
                    territory[snake[0], snake[1]] = '.';
                    if (snake[0] == burrows[0]) { snake[0] = burrows[2]; snake[1] = burrows[3]; }
                    else { snake[0] = burrows[0]; snake[1] = burrows[2]; }
                }
                territory[snake[0], snake[1]] = 'S';
                command = Console.ReadLine();
            }
            if(isOut) { Console.WriteLine("Game over!"); }
            else { Console.WriteLine("You won! You fed the snake."); }
            Console.WriteLine($"Food eaten: {food}");
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(territory[r,c]);
                }
                Console.WriteLine();
            }
        }
    }
}
