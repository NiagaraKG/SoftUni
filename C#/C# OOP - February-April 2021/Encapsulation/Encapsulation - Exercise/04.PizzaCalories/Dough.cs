using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;
        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain") { throw new ArgumentException("Invalid type of dough."); }
                else { this.flourType = value.ToLower(); }
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade") 
                { throw new ArgumentException("Invalid type of dough."); }
                else { this.bakingTechnique = value.ToLower(); }
            }
        }
        public int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200) { throw new ArgumentException("Dough weight should be in the range [1..200]."); }
                else { this.weight = value; }
            }
        }
        public Dough(string type, string technique, int grams)
        {
            this.FlourType = type;
            this.BakingTechnique = technique;
            this.Weight = grams;
        }
        public double Calories()
        {
            double calories = this.Weight * 2.0;
            if (this.FlourType == "white") { calories *= 1.5; }
            if (this.BakingTechnique == "crispy") { calories *= 0.9; }
            else if (this.BakingTechnique == "chewy") { calories *= 1.1; }
            return calories;
        }
    }
}
