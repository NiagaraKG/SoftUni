using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }
        public override void ProduceSound()
        { Console.WriteLine("Squeak"); }
        public override string ToString()
        { return $"Mouse [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]"; }
    }
}
