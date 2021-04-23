using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize) { }
        public override void ProduceSound()
        { Console.WriteLine("Hoot Hoot"); }
        public override string ToString()
        { return $"Owl [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]"; }
    }
}
