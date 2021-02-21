using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> all = new List<Person>();
            while(command != "End")
            {
                string[] input = command.Split();
                Person current = new Person(input);
                all.Add(current);
                command = Console.ReadLine();
            }
            all = all.OrderBy(x => x.Age).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, all));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Person(string[] input)
        {
            this.Name = input[0];
            this.ID = input[1];
            this.Age = int.Parse(input[2]);
        }

        public override string ToString()
        {
            string result = this.Name + " with ID: " + this.ID + $" is {this.Age} years old.";
            return result;
        }

    }

}
