using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public List<T> elements;
        public CustomStack() { this.elements = new List<T>(); }
        public void Push(params T[] data)
        {
            foreach (var item in data)
            {
                elements.Add(item);
            }
        }
        public void Pop() 
        {
            if (elements.Count == 0) { Console.WriteLine("No elements"); }
            else { this.elements.RemoveAt(elements.Count - 1); }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
