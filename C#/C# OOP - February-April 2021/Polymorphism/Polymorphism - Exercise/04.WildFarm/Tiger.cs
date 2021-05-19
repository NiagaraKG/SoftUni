using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }
        public override void ProduceSound()
        { Console.WriteLine("ROAR!!!"); }
        public override string ToString()
        { return $"Tiger [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]"; }
    }
}
