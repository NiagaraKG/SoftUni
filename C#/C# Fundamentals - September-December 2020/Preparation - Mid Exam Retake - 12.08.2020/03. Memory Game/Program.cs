using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split();
            int moves = 0;
            while (command[0] != "end")
            {
                moves++;
                int f = int.Parse(command[0]);
                int s = int.Parse(command[1]);
                if (f == s || f < 0 || f >= elements.Count || s < 0 || s >= elements.Count)
                {
                    string e = "-" + moves + "a";
                    elements.Insert(elements.Count/2, e);
                    elements.Insert(elements.Count/2, e);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if(elements[f] == elements[s])
                {
                    string value = elements[f];
                    Console.WriteLine($"Congrats! You have found matching elements - {value}!");
                    elements.RemoveAll(x => x == value);                    
                }
                else { Console.WriteLine("Try again!"); }
                if (elements.Count == 0)
                { Console.WriteLine($"You have won in {moves} turns!"); return; }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
