using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListIterator<T> : IEnumerable<T>
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
        public void PrintAll()
        {
            if (collection.Count == 0)
            { throw new InvalidOperationException("Invalid Operation!"); }
            Console.WriteLine(string.Join(" ", collection));
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.collection)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
    }
}
