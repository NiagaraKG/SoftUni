using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            while(input != "special" && input != "regular")
            {
                double price = double.Parse(input);
                if (price > 0) { sum += price; }  
                else { Console.WriteLine("Invalid price!"); }
                input = Console.ReadLine();
            }
            if(sum == 0) { Console.WriteLine("Invalid order!"); return; }
            double taxes = sum * 20 / 100;
            double total = sum + taxes;
            if(input == "special") { total *= 0.9; }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sum:F2}$");
            Console.WriteLine($"Taxes: {taxes:F2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:F2}$");
        }
    }
}
