using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    public class Product
    {
        public string name;
        public double price;
        public Product(string name, string price)
        {
            this.name = name;
            this.price = double.Parse(price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Product>> shops = new Dictionary<string, List<Product>>();
            string[] command = Console.ReadLine().Split(", ");
            while (command[0] != "Revision")
            {
                if (shops.ContainsKey(command[0])) { shops[command[0]].Add(new Product(command[1], command[2])); }
                else { shops.Add(command[0], new List<Product> { new Product(command[1], command[2]) }); }
                command = Console.ReadLine().Split(", ");
            }
            shops = shops.OrderBy(x=>x.Key).ToDictionary(x=>x.Key, y=>y.Value);
            foreach (var shop in shops)
            {
                Console.WriteLine(shop.Key + "->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.name}, Price: {product.price}");
                }
            }
        }
    }
}
