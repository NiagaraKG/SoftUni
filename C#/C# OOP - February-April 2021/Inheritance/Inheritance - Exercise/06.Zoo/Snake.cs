using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Snake : Reptile
    {
        public string Name { get; set; }
        public Snake(string name) : base(name) { }
    }
}
