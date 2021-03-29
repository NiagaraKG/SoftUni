using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleLine = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsLine = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                foreach (var p in peopleLine)
                {
                    string[] current = p.Split("=");
                    people.Add(new Person(current[0], decimal.Parse(current[1])));
                }
                foreach (var p in productsLine)
                {
                    string[] current = p.Split("=");
                    products.Add(new Product(current[0], decimal.Parse(current[1])));
                }               
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); return; }
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "END")
            {
                people.FirstOrDefault(p => p.Name == input[0]).Buy(products.FirstOrDefault(p => p.Name == input[1]));
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var p in people)
            {
                if (p.bagOfProducts.Count == 0) { Console.WriteLine($"{p.Name} - Nothing bought"); }
                else { Console.WriteLine($"{p.Name} - {string.Join(", ", p.bagOfProducts)}"); }
            }
        }
    }
}
