using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double  pow = double .Parse(Console.ReadLine());
            Console.WriteLine(Power(num, pow));
        }

        static double Power(double num, double pow)
        {
            return Math.Pow(num, pow);
        }

    }
}
