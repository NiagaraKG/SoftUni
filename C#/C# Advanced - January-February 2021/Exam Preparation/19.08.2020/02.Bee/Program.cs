using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];
            int[] bee = new int[2];
            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    territory[r, c] = row[c];
                    if (territory[r, c] == 'B')
                    {
                        bee[0] = r;
                        bee[1] = c;
                    }
                }
            }
            int pollinated = 0;
            string command = Console.ReadLine();
            while (command != "End")
            {
                territory[bee[0], bee[1]] = '.';
                switch (command)
                {
                    case "up": bee[0]--; break;
                    case "down": bee[0]++; break;
                    case "left": bee[1]--; break;
                    case "right": bee[1]++; break;
                }
                if (bee[0] < 0 || bee[0] >= n) { Console.WriteLine("The bee got lost!"); break; }
                else if (bee[1] < 0 || bee[1] >= n) { Console.WriteLine("The bee got lost!"); break; }
                if (territory[bee[0], bee[1]] == 'f') { pollinated++; }
                if (territory[bee[0], bee[1]] == 'O')
                {
                    territory[bee[0], bee[1]] = '.';
                    switch (command)
                    {
                        case "up": bee[0]--; break;
                        case "down": bee[0]++; break;
                        case "left": bee[1]--; break;
                        case "right": bee[1]++; break;
                    }
                    if (territory[bee[0], bee[1]] == 'f') { pollinated++; }
                }
                territory[bee[0], bee[1]] = 'B';
                command = Console.ReadLine();
            }
            if(pollinated < 5) { Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinated} flowers more"); }
            else { Console.WriteLine($"Great job, the bee managed to pollinate {pollinated} flowers!"); }
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
