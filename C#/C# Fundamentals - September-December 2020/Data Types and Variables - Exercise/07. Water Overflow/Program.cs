using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int liters = 0;
            for(int i = 0; i < n; i++)
            {
                int quantity = int.Parse(Console.ReadLine());
                liters += quantity;
                if (liters > 255)
                { 
                    Console.WriteLine("Insufficient capacity!");
                    liters -= quantity;
                }
            }
            Console.WriteLine(liters);
        }
    }
}
