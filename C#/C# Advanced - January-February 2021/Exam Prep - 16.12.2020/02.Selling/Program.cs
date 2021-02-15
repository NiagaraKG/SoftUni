using System;
using System.Collections.Generic;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] bakery = new char[n, n];
            int[] seller = new int[2];
            List<int> pillars = new List<int>();
            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    bakery[r, c] = row[c];
                    if (bakery[r, c] == 'S') { seller[0] = r; seller[1] = c; }
                    else if (bakery[r, c] == 'O') { pillars.Add(r); pillars.Add(c); }
                }
            }
            int money = 0;
            bool isIn = true;
            while (money < 50 && isIn)
            {
                bakery[seller[0], seller[1]] = '-';
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up": seller[0]--; break;
                    case "down": seller[0]++; break;
                    case "left": seller[1]--; break;
                    case "right": seller[1]++; break;
                }
                if (seller[0] < 0 || seller[0] >= n) { isIn = false; break; }
                else if (seller[1] < 0 || seller[1] >= n) { isIn = false; break; }
                else
                {
                    if (bakery[seller[0], seller[1]] == 'O')
                    {
                        if (seller[0] == pillars[0]) { seller[0] = pillars[2]; seller[1] = pillars[3]; }
                        else { seller[0] = pillars[0]; seller[1] = pillars[1]; }
                        bakery[pillars[0], pillars[1]] = '-'; bakery[pillars[2], pillars[3]] = '-';
                        bakery[seller[0], seller[1]] = 'S';
                    }
                    else if(char.IsDigit(bakery[seller[0], seller[1]]))
                    {
                        money += int.Parse(bakery[seller[0], seller[1]].ToString());
                        bakery[seller[0], seller[1]] = 'S';                        
                    }
                }                
            }
            if(!isIn) { Console.WriteLine("Bad news, you are out of the bakery."); }
            else { Console.WriteLine("Good news! You succeeded in collecting enough money!"); }
            Console.WriteLine("Money: " + money);
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(bakery[r,c]);
                }
                Console.WriteLine();
            }
        }
    }
}
