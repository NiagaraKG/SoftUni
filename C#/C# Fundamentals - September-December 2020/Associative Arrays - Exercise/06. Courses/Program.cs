using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] command = Console.ReadLine().Split(" : ");
            while (command[0] != "end")
            {
                if (courses.ContainsKey(command[0])) { courses[command[0]].Add(command[1]); }
                else { courses.Add(command[0], new List<string>() { command[1] }); }
                command = Console.ReadLine().Split(" : ");
            }
            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in courses)
            {
                Console.WriteLine(item.Key + ": " + item.Value.Count);
                item.Value.Sort();
                foreach (var name in item.Value)
                {
                    Console.WriteLine("-- " + name);
                }
            }
        }
    }
}

