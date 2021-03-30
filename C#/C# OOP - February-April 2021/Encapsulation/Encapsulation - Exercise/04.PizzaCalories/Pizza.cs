using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Dough Dough { private get { return this.dough; } set { this.dough = value; } }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                { throw new ArgumentException("Pizza name should be between 1 and 15 symbols."); }
                else { this.name = value; }
            }
        }
        public double Calories
        {
            get
            {
                double total = this.Dough.Calories();
                foreach (var t in this.toppings) { total += t.Calories(); }
                return total;
            }
        }
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public void Add(Topping t)
        {
            if (this.toppings.Count < 10) { this.toppings.Add(t); }
            else { throw new InvalidOperationException("Number of toppings should be in range [0..10]."); }
        }
        public override string ToString() { return $"{this.Name} - {this.Calories:f2} Calories."; }
    }
}
