using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Bear : Mammal
    {
        public string Name { get; set; }
        public Bear(string name) : base(name) { }
    }
}
