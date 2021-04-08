using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4) { buyers.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3])); }
                else { buyers.Add(new Rebel(input[0], int.Parse(input[1]), input[2])); }
            }
            string name = Console.ReadLine();
            while (name != "End")
            {
                if (buyers.Any(b => b.Name == name))
                {
                    buyers.FirstOrDefault(b => b.Name == name).BuyFood();
                }
                name = Console.ReadLine();
            }
            int food = 0;
            foreach (var b in buyers) { food += b.Food; }
            Console.WriteLine(food);
        }
    }
}
