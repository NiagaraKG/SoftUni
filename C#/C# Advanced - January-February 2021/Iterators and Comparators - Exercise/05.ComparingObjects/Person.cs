using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string[] input)
        {
            this.Name = input[0];
            this.Age = int.Parse(input[1]);
            this.Town = input[2];
        }
        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0) { result = this.Age.CompareTo(other.Age); }
            if (result == 0) { result = this.Town.CompareTo(other.Town); }
            return result;
        }
    }
}
