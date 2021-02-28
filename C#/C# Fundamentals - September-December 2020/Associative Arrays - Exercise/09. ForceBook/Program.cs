using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] command = input.Split(" | ");
                    bool isFound = false;
                    foreach (var item in sides)
                    {
                        if (item.Value.Contains(command[1])) { isFound = true; break; }
                    }
                    if (!isFound)
                    {
                        if (sides.ContainsKey(command[0])) { sides[command[0]].Add(command[1]); }
                        else { sides.Add(command[0], new List<string> { command[1] }); }
                    }
                }
                else
                {
                    string[] command = input.Split(" -> ");
                    foreach (var item in sides)
                    {
                        if (item.Value.Contains(command[0])) { item.Value.Remove(command[0]); break; }
                    }
                    if (sides.ContainsKey(command[1])) { sides[command[1]].Add(command[0]); }
                    else { sides.Add(command[1], new List<string> { command[0] }); }
                    Console.WriteLine($"{command[0]} joins the {command[1]} side!");
                }
                input = Console.ReadLine();
            }
            sides = sides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in sides)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    item.Value.Sort();
                    foreach (var name in item.Value)
                    {
                        Console.WriteLine("! " + name);
                    }
                }
            }
        }
    }
}
