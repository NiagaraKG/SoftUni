using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;
        public Animal(string animalName, string food)
        {
            this.name = animalName;
            this.favouriteFood = food;
        }
        public virtual string ExplainSelf() { return $"I am {this.name} and my favourite food is {this.favouriteFood}"; }
    }
}
