using System;

namespace _05._Filter_By_Age
{
    class Person
    {
        public string name;
        public int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                people[i] = new Person(input[0], int.Parse(input[1]));
            }
            string filter = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Func<Person, bool> condition = GetAgeCondition(filter, age);
            Action<Person> formatter = GetFormatter(Console.ReadLine());
            PrintPeople(people, condition, formatter);
        }
        static Action<Person> GetFormatter(string format)
        {
            switch (format)
            {
                case "name": return p => { Console.WriteLine(p.name); };
                case "age": return p => { Console.WriteLine(p.age); };
                case "name age": return p => { Console.WriteLine($"{p.name} - {p.age}"); };
                default: return null;
            }
        }

        static Func<Person, bool> GetAgeCondition(string filter, int age)
        {
            switch (filter)
            {
                case "younger": return p => p.age < age;
                case "older": return p => p.age >= age;
                default: return null;
            }
        }

        static void PrintPeople(Person[] people, Func<Person, bool> condition, Action<Person> formatter)
        {
            foreach (var p in people) { if (condition(p)) { formatter(p); } }
        }

    }
}
