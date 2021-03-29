using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        public List<Product> bagOfProducts;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Name cannot be empty"); }
                else { this.name = value; }
            }
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0) { throw new ArgumentException("Money cannot be negative"); }
                else { this.money = value; }
            }
        }
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }
        public void Buy(Product p)
        {
            if (money >= p.Cost)
            {
                money -= p.Cost;
                bagOfProducts.Add(p);
                Console.WriteLine($"{this.Name} bought {p.Name}");
            }
            else { Console.WriteLine($"{this.Name} can't afford {p.Name}"); }
        }
    }
}
