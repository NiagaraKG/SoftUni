using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        { this.WingSize = wingSize; }
    }
}
