using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._List_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while(command[0] != "Report")
            {
                if(command[0] == "Blacklist")
                {
                    if(!friends.Contains(command[1])) { Console.WriteLine($"{command[1]} was not found."); }
                    else
                    {
                        friends[friends.IndexOf(command[1])] = "Blacklisted";
                        Console.WriteLine($"{command[1]} was blacklisted.");
                    }
                }
                else if(command[0] == "Error")
                {
                    int index = int.Parse(command[1]);
                    if(friends[index] != "Blacklisted" && friends[index] != "Lost")
                    {
                        string name = friends[index];
                        friends[index] = "Lost";
                        Console.WriteLine($"{name} was lost due to an error.");
                    }
                }
                else if(command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    if(index >=0 && index < friends.Count)
                    {
                        string name = friends[index];
                        friends[index] = command[2];
                        Console.WriteLine($"{name} changed his username to {command[2]}.");
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            int blackListed = 0, lost = 0;
            for (int i = 0; i < friends.Count; i++)
            {
                if(friends[i] == "Blacklisted") { blackListed++; }
                else if(friends[i] == "Lost") { lost++; }
            }
            Console.WriteLine($"Blacklisted names: {blackListed}");
            Console.WriteLine($"Lost names: {lost}");
            Console.WriteLine(string.Join(" ", friends));
        }
    }
}
