using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                people.Add(new Person(input[0], int.Parse(input[1])));
            }
            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            foreach (var p in people) { Console.WriteLine($"{p.Name} - {p.Age}"); }
        }
    }
}
