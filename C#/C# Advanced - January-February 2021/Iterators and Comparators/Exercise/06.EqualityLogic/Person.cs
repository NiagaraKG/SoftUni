using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string[] input) { this.Name = input[0]; this.Age = int.Parse(input[1]); }
        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0) { result = this.Age.CompareTo(other.Age); }
            return result;
        }
        public override int GetHashCode() { return this.Name.GetHashCode() + this.Age.GetHashCode(); }
        public override bool Equals(object obj) { return this.GetHashCode() == obj.GetHashCode(); }
    }
}
