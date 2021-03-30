using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;
        public string Type
        {
            get { return this.type; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                { throw new ArgumentException($"Cannot place {value} on top of your pizza."); }
                else { this.type = value; }
            }
        }
        public int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50) { throw new ArgumentException($"{this.type} weight should be in the range [1..50]."); }
                else { this.weight = value; }
            }
        }
        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public double Calories()
        {
            double calories = this.Weight * 2.0;
            if (this.Type.ToLower() == "meat") { calories *= 1.2; }
            else if (this.Type.ToLower() == "veggies") { calories *= 0.8; }
            else if (this.Type.ToLower() == "cheese") { calories *= 1.1; }
            else if (this.Type.ToLower() == "sauce") { calories *= 0.9; }
            return calories;
        }

    }
}
