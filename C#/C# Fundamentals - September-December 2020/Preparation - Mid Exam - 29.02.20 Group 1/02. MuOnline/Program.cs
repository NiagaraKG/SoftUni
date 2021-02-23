using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100, bitcoins = 0;
            List<string> rooms = Console.ReadLine().Split("|").ToList();
            for (int i = 0; i < rooms.Count; i++)
            {
                string[] command = rooms[i].Split();
                int power = int.Parse(command[1]);
                if (command[0] == "potion")
                {
                    if (health + power <= 100)
                    { health += power; }
                    else { power = 100 - health; health = 100; }
                    Console.WriteLine($"You healed for {power} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command[0] == "chest")
                {
                    bitcoins += power;
                    Console.WriteLine($"You found {power} bitcoins.");
                }
                else
                {
                    health -= power;
                    if (health > 0) { Console.WriteLine($"You slayed {command[0]}."); }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command[0]}.\nBest room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!\nBitcoins: {bitcoins}\nHealth: {health}");
        }
    }
}
