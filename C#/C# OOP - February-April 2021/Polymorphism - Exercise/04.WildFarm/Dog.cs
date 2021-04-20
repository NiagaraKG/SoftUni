using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }
        public override void ProduceSound()
        { Console.WriteLine("Woof!"); }
        public override string ToString()
        { return $"Dog [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]"; }
    }
}
