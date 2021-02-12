using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {   
        public T1 item1 { get; set; }
        public T2 item2 { get; set; }
        public T3 item3 { get; set; }
        public Threeuple(T1 first, T2 second, T3 third) { this.item1 = first; this.item2 = second; this.item3 = third; }
        public override string ToString() { return $"{this.item1} -> {this.item2} -> {this.item3}"; }
    }
}
