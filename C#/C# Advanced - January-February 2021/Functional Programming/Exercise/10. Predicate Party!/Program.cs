using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> filter;
            List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Party!")
            {
                switch (command[1])
                {
                    case "StartsWith": filter = x => x.IndexOf(command[2]) == 0; break;
                    case "EndsWith": filter = x => x.IndexOf(command[2]) == x.Length - command[2].Length; break;
                    case "Length": filter = x => x.Length == int.Parse(command[2]); break;
                    default: filter = x => false; break;
                }
                if (command[0] == "Remove") { people = people.Where(x => !filter(x)).ToList(); }
                else
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if(filter(people[i]))
                        {
                            people.Insert(i + 1, people[i]);
                            i++;
                        }
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (people.Count == 0) { Console.WriteLine("Nobody is going to the party!"); }
            else { Console.WriteLine(string.Join(", ", people) + " are going to the party!"); }
        }
    }
}
