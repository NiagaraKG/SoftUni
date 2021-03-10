using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            string[] command = Console.ReadLine().Split("->");
            while (command[0] != "Statistics")
            {
                if (command[0] == "Add")
                {
                    if (users.ContainsKey(command[1])) { Console.WriteLine(command[1] + " is already registered"); }
                    else { users.Add(command[1], new List<string>()); }
                }
                else if (command[0] == "Send") { users[command[1]].Add(command[2]); }
                else if(command[0] == "Delete")
                {
                    if(users.ContainsKey(command[1])) { users.Remove(command[1]); }
                    else { Console.WriteLine(command[1] + " not found!"); }
                }
                command = Console.ReadLine().Split("->");
            }
            Console.WriteLine("Users count: " + users.Count);
            users = users.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var user in users)
            {
                Console.WriteLine(user.Key);
                foreach (var email in user.Value)
                {
                    Console.WriteLine(" - " + email);
                }
            }
        }
    }
}
