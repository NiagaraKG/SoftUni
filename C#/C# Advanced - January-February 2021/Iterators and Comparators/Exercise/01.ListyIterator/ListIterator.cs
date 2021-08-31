using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListIterator<T>
    {
        private List<T> collection { get; set; }
        private int index;
        public ListIterator(params T[] elements) { this.collection = new List<T>(elements); this.index = 0; }
        public bool HasNext() { return this.index < this.collection.Count - 1; }
        public bool Move()
        {
            if (this.HasNext()) { this.index++; return true; }
            return false;
        }
        public void Print()
        {
            if (this.index > this.collection.Count || collection.Count == 0) 
            { throw new InvalidOperationException("Invalid Operation!"); }
            Console.WriteLine(this.collection[this.index]);
        }
    }
}
