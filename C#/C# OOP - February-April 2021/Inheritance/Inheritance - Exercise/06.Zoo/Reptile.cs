using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Reptile : Animal
    {
        public string Name { get; set; }
        public Reptile(string name) : base(name) { }
    }
}
