using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Citizen : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; }
        public Citizen(string name, int age, string ID, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.ID = ID;
            this.Birthday = birthday;
            this.Food = 0;
        }
        public void BuyFood() { this.Food += 10; }
    }
}
