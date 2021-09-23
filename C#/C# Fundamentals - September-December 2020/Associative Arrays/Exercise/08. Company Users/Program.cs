using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string[] command = Console.ReadLine().Split(" -> ");
            while (command[0] != "End")
            {
                if(companies.ContainsKey(command[0]))
                {
                    if(!companies[command[0]].Contains(command[1])) { companies[command[0]].Add(command[1]); }
                }
                else { companies.Add(command[0], new List<string> { command[1]}); }
                command = Console.ReadLine().Split(" -> ");
            }
            companies = companies.OrderBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in companies)
            {
                Console.WriteLine(item.Key);
                foreach (var id in item.Value)
                {
                    Console.WriteLine("-- " + id);
                }
            }
        }
    }
}
