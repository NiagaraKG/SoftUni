using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> currentFilter;
            List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> command = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> filters = new List<string>();
            while (command[0] != "Print")
            {
                if (command[0] == "Add filter")
                {
                    command.RemoveAt(0);
                    filters.Add(command[0]+";"+command[1]);
                }
                else
                {
                    command.RemoveAt(0);
                    filters.Remove(command[0] + ";" + command[1]);
                }
                command = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            foreach (var filter in filters)
            {
                string[] f = filter.Split(';');
                switch (f[0])
                {
                    case "Starts with": currentFilter = x => x.IndexOf(f[1]) == 0; break;
                    case "Ends with": currentFilter = x => x.IndexOf(f[1]) == x.Length - f[1].Length; break;
                    case "Length": currentFilter = x => x.Length == int.Parse(f[1]); break;
                    case "Contains": currentFilter = x => x.Contains(f[1]); break;
                    default: currentFilter = x => false; break;
                }
                people = people.Where(x => !currentFilter(x)).ToList();
            }
            Console.WriteLine(string.Join(" ", people));
        }
    }
}
