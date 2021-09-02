using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<Person> sorted = new SortedSet<Person>();
            HashSet<Person> hash = new HashSet<Person>();
            for (int i = 0; i < n; i++)
            {
                Person current = new Person(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
                sorted.Add(current);
                hash.Add(current);
            }
            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }
    }
}
