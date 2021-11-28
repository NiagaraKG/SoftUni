using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family f = new Family();     
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person current = new Person(input);
                f.AddMember(current);
            }
            Console.WriteLine(f.GetOldestMember());
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string[] input)
        {
            this.Name = input[0];
            this.Age = int.Parse(input[1]);
        }
        public override string ToString()
        {
            return this.Name + " " + this.Age;
        }
    }

    class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            this.People = new List<Person>();
        }
        public void AddMember(Person member)
        {
            this.People.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestPerson = People.OrderByDescending(x => x.Age).ToList().FirstOrDefault();

            return oldestPerson;
        }
    }

}
