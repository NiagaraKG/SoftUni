using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable
    {
        private T Left;
        private T Right;
        public EqualityScale(T left, T right) { this.Left = left; this.Right = right; }
        public bool AreEqual() { return this.Left.CompareTo(this.Right) == 0; }
    }
}
