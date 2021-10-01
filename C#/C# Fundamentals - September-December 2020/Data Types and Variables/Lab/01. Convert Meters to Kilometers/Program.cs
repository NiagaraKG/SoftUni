using System;

namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            decimal km = m / 1000.00M;
            Console.WriteLine($"{km:F2}");
        }
    }
}
