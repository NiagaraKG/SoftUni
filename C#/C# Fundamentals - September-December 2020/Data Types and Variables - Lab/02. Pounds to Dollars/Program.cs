using System;

namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal BP = decimal.Parse(Console.ReadLine());
            decimal D = BP * 1.31M;
            Console.WriteLine($"{D:F3}");
        }
    }
}
