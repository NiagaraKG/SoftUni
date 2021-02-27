using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                if(command[0] == "register")
                {
                    if(users.ContainsKey(command[1]))
                    { Console.WriteLine($"ERROR: already registered with plate number {users[command[1]]}"); }
                    else
                    {
                        users.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                }
                else
                {
                    if (users.ContainsKey(command[1]))
                    {
                        users.Remove(command[1]);
                        Console.WriteLine($"{command[1]} unregistered successfully");
                    }
                    else { Console.WriteLine($"ERROR: user {command[1]} not found"); }
                }
            }
            foreach (var item in users)
            {
                Console.WriteLine(item.Key + " => " + item.Value);
            }
        }
    }
}
