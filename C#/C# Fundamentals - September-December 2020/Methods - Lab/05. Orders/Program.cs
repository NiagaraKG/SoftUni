using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            CalculatePrice(product, quantity);
        }

        static void CalculatePrice (string product, int quantity)
        {
            double total;
            if(product == "coffee")
            {
                total = quantity * 1.50;
            }
            else if(product == "water")
            {
                total = quantity * 1.00;
            }
            else if(product == "coke")
            {
                total = quantity * 1.40;
            }
            else
            {
                total = quantity * 2.00;
            }
            Console.WriteLine(total.ToString("0.00"));
        }

    }
}
