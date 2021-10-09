using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Characteristics
    {
        public double rarity;
        public List<double> ratings;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Characteristics> plants = new Dictionary<string, Characteristics>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] plant = Console.ReadLine().Split("<->");
                Characteristics c = new Characteristics();
                c.rarity = double.Parse(plant[1]); c.ratings = new List<double>();
                if (plants.ContainsKey(plant[0])) { plants[plant[0]].rarity = c.rarity; }
                else { plants.Add(plant[0], c); }
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "Exhibition")
            {
                if (command[0] == "Rate:")
                {
                    if (plants.ContainsKey(command[1])) { plants[command[1]].ratings.Add(double.Parse(command[3])); }
                    else { Console.WriteLine("error"); }
                }
                else if (command[0] == "Update:")
                {
                    if (plants.ContainsKey(command[1])) { plants[command[1]].rarity = double.Parse(command[3]); }
                    else { Console.WriteLine("error"); }
                }
                else if (command[0] == "Reset:")
                {
                    if (plants.ContainsKey(command[1]))
                    { plants[command[1]].ratings.Clear(); plants[command[1]].ratings = new List<double>(); }
                    else { Console.WriteLine("error"); }
                }
                else { Console.WriteLine("error"); }
                command = Console.ReadLine().Split();
            }
            foreach (var p in plants) { if (p.Value.ratings.Count == 0) { p.Value.ratings.Add(0); } }
            plants = plants.OrderByDescending(x => x.Value.rarity).ThenByDescending(x => x.Value.ratings.Average())
                                                                  .ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine("Plants for the exhibition:");
            foreach (var p in plants)
            {
                Console.WriteLine($"- {p.Key}; Rarity: {p.Value.rarity}; Rating: {p.Value.ratings.Average():f2}");
            }
        }
    }
}
