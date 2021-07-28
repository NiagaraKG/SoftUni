using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> box;
        public Box() { box = new Stack<T>(); }
        public int Count => this.box.Count;
        public void Add(T element) { this.box.Push(element); }
        public T Remove() { return box.Pop(); }
    }
}
