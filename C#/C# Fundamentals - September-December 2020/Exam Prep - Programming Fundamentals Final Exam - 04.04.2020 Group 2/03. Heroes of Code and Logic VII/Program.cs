using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> heroes = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                double hp = double.Parse(input[1]), mp = double.Parse(input[2]);
                if (hp > 100) { hp = 100; }
                if (mp > 200) { mp = 200; }
                heroes.Add(input[0], new List<double> { hp, mp });
            }
            string[] command = Console.ReadLine().Split(" - ");
            while (command[0] != "End")
            {
                if (command[0] == "CastSpell")
                {
                    double MP = double.Parse(command[2]);
                    if (heroes[command[1]][1] - MP >= 0)
                    {
                        heroes[command[1]][1] -= MP;
                        Console.WriteLine($"{command[1]} has successfully cast {command[3]} and now has { heroes[command[1]][1]} MP!");
                    }
                    else { Console.WriteLine($"{command[1]} does not have enough MP to cast {command[3]}!"); }
                }
                else if (command[0] == "TakeDamage")
                {
                    double damage = double.Parse(command[2]);
                    heroes[command[1]][0] -= damage;
                    if (heroes[command[1]][0] > 0)
                    {
                        Console.WriteLine($"{command[1]} was hit for {damage} HP by {command[3]} and now has {heroes[command[1]][0]} HP left!");
                    }
                    else
                    {
                        heroes.Remove(command[1]);
                        Console.WriteLine($"{command[1]} has been killed by {command[3]}!");
                    }
                }
                else if (command[0] == "Recharge")
                {
                    double MP = double.Parse(command[2]);
                    if(heroes[command[1]][1] + MP > 200) { MP = 200 - heroes[command[1]][1];}
                    heroes[command[1]][1] += MP;
                    Console.WriteLine($"{command[1]} recharged for {MP} MP!");
                }
                else if(command[0] == "Heal")
                {
                    double HP = double.Parse(command[2]);
                    if(heroes[command[1]][0] + HP > 100) { HP = 100 - heroes[command[1]][0]; }
                    heroes[command[1]][0] += HP;
                    Console.WriteLine($"{command[1]} healed for {HP} HP!");
                }
                command = Console.ReadLine().Split(" - ");
            }
            heroes = heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var h in heroes)
            {
                Console.WriteLine(h.Key);
                Console.WriteLine("  HP: " + h.Value[0]);
                Console.WriteLine("  MP: " + h.Value[1]);
            }
        }
    }
}
