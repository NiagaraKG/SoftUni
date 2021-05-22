using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; set; }
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        { this.Breed = breed; }
    }
}
