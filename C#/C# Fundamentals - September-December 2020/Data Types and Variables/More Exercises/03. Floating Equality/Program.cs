using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            if(Math.Abs(first - second) <= 0.000001)
            { Console.WriteLine("True"); }
            else { Console.WriteLine("False"); }
        }
    }
}
