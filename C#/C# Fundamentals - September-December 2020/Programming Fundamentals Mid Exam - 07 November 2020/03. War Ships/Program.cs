using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._War_Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> pirateship = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            List<double> warship = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            double maxHealth = double.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Retire")
            {
                if (command[0] == "Fire")
                {
                    int index = int.Parse(command[1]);
                    double damage = double.Parse(command[2]);
                    if (index >= 0 && index < warship.Count)
                    {
                        warship[index] -= damage;
                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has suken.");
                            return;
                        }
                    }
                }
                else if (command[0] == "Defend")
                {
                    int start = int.Parse(command[1]), end = int.Parse(command[2]);
                    double damage = double.Parse(command[3]);
                    for (int i = start; i <= end; i++)
                    {
                        pirateship[i] -= damage;
                        if (pirateship[i] <= 0) { Console.WriteLine("You lost! The pirate ship has sunken."); return; }
                    }
                }
                else if (command[0] == "Repair")
                {
                    int index = int.Parse(command[1]);
                    double health = double.Parse(command[2]);
                    if (index >= 0 && index < pirateship.Count)
                    {
                        pirateship[index] += health;
                        if (pirateship[index] > maxHealth) { pirateship[index] = maxHealth; }
                    }
                }
                else if (command[0] == "Status")
                {
                    int br = 0;
                    double min = maxHealth * 0.2;
                    for (int i = 0; i < pirateship.Count; i++)
                    {
                        if(pirateship[i] < min) { br++; }
                    }
                    Console.WriteLine($"{br} sections need repair.");
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Pirate ship status: {pirateship.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }
    }
}
