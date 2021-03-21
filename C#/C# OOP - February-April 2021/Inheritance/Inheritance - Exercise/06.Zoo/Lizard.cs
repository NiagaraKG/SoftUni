using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Lizard : Reptile
    {
        public string Name { get; set; }
        public Lizard(string name) : base(name) { }
    }
}
