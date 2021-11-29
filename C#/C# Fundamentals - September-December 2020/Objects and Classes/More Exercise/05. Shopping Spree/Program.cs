using System;
using System.Collections.Generic;

namespace _05._Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> People = new List<Person>();
            List<Product> Products = new List<Product>();
            for (int i = 0; i < inputPeople.Length; i++)
            {
                Person current = new Person(inputPeople[i]);
                People.Add(current);
            }
            for (int i = 0; i < inputProducts.Length; i++)
            {
                Product current = new Product(inputProducts[i]);
                Products.Add(current);
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while(command[0] != "END")
            {
                for (int i = 0; i < People.Count; i++)
                {
                    if(People[i].Name == command[0])
                    {
                        for (int j = 0; j < Products.Count; j++)
                        {
                            if(Products[j].Name == command[1])
                            {
                                if(People[i].Money >= Products[j].Cost)
                                {
                                    People[i].Money -= Products[j].Cost;
                                    People[i].Products.Add(Products[j]);
                                    Console.WriteLine($"{People[i].Name} bought {Products[j].Name}");
                                }
                                else { Console.WriteLine($"{People[i].Name} can't afford {Products[j].Name}"); }
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in People)
            {
                if(item.Products.Count == 0) { Console.WriteLine(item.Name + " - Nothing bought"); }
                else { Console.WriteLine(item); }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> Products { get; set; }
        public Person(string input)
        {
            string[] current = input.Split("=");
            this.Name = current[0];
            this.Money = double.Parse(current[1]);
            this.Products = new List<Product>();
        }
        public override string ToString()
        {
            string result = this.Name + " - ";
            result += String.Join(", ", Products);
            return result;
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public Product(string input)
        {
            string[] current = input.Split("=");
            this.Name = current[0];
            this.Cost = double.Parse(current[1]);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
