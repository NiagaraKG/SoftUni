using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T1, T2>
    {   
        public T1 item1 { get; set; }
        public T2 item2 { get; set; }
        public Tuple(T1 first, T2 second) { this.item1 = first; this.item2 = second; }
        public override string ToString() { return $"{this.item1} -> {this.item2}"; }
    }
}
