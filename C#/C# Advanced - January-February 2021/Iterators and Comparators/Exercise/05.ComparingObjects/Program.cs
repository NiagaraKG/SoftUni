using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                people.Add(new Person(command));
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            int matches = 0, diff = 0;
            foreach (var p in people)
            {
                if (p.CompareTo(people[index]) == 0) { matches++; }
                else { diff++; }
            }
            if (matches == 1) { Console.WriteLine("No matches"); }
            else { Console.WriteLine($"{matches} {diff} {matches + diff}"); }
        }
    }
}
