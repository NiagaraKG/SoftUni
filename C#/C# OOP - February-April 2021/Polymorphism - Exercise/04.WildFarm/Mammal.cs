using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        { this.LivingRegion = livingRegion; }
    }
}
