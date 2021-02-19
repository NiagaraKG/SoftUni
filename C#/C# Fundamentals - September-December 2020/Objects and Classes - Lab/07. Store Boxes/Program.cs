using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> all = new List<Box>();
            while(input != "end")
            {
                string[] current = input.Split();
                int serial = int.Parse(current[0]);
                string name = current[1];
                int quantity = int.Parse(current[2]);
                double price = double.Parse(current[3]);
                double boxPrice = quantity * price;
                Box box = new Box();
                box.item = new Item();
                box.SerialNum = serial;
                box.Quantity = quantity;
                box.PriceForBox = boxPrice;
                box.item.Name = name;
                box.item.Price = price;
                all.Add(box);
                input = Console.ReadLine();
            }
            all = all.OrderByDescending(x => x.PriceForBox).ToList();
            foreach (var i in all)
            {
                Console.WriteLine(i.SerialNum);
                Console.WriteLine($"-- {i.item.Name} - ${i.item.Price:F2}: {i.Quantity}");
                Console.WriteLine($"-- ${i.PriceForBox:F2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public int SerialNum { get; set; }
        public Item item { get; set; }
        public int Quantity { get; set; }
        public double PriceForBox { get; set; }
    }

}
