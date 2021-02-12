using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> : IComparable
        where T : IComparable
    {
        public T Value { get; set; }
        public Box(T value) { this.Value = value; }
        public override string ToString() { return $"{Value.GetType()}: {Value}"; }
        public int CompareTo(object obj)
        {
            Box<T> B = obj as Box<T>;
            return this.Value.CompareTo(B.Value);
        }
    }
}
