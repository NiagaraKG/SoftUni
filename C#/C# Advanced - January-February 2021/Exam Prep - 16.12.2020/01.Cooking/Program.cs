using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int bread = 0, cake = 0, pastry = 0, pie = 0;
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquids.Peek() + ingredients.Peek();
                if (sum == 100) { pie++; ingredients.Pop(); }
                else if (sum == 75) { pastry++; ingredients.Pop(); }
                else if (sum == 50) { cake++; ingredients.Pop(); }
                else if (sum == 25) { bread++; ingredients.Pop(); }
                else { ingredients.Push(ingredients.Pop() + 3); }
                liquids.Dequeue();
            }
            if (bread == 0 || cake == 0 || pastry == 0 || pie == 0)
            { Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything."); }
            else { Console.WriteLine("Wohoo! You succeeded in cooking all the food!"); }
            if (liquids.Count == 0) { Console.WriteLine("Liquids left: none"); }
            else { Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}"); }
            if (ingredients.Count == 0) { Console.WriteLine("Ingredients left: none"); }
            else { Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}"); }
            Console.WriteLine("Bread: " + bread);
            Console.WriteLine("Cake: " + cake);
            Console.WriteLine("Fruit Pie: " + pie);
            Console.WriteLine("Pastry: " + pastry);
        }
    }
}
