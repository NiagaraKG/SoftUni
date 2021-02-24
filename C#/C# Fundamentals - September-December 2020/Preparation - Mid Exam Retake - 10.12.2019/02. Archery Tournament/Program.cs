using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split("|").Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split("@").ToArray();
            int points = 0;
            while (command[0] != "Game over")
            {
                if(command[0] == "Reverse") { targets.Reverse(); }
                else
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);
                    if(index >= 0 && index < targets.Count)
                    {
                        if(command[0] == "Shoot Left")
                        {
                            index -= length;
                            while(index < 0) { index += targets.Count; }
                        }
                        else
                        {
                            index += length;
                            while(index > targets.Count) { index -= targets.Count; }
                        }
                        if (targets[index] >= 5) { points += 5; targets[index] -= 5; }
                        else { points += targets[index]; targets[index] = 0; }
                    }                   
                }
                command = Console.ReadLine().Split("@").ToArray();
            }
            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
