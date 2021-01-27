using System;

namespace _02._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double distance1 = GetDistance(x1, y1);
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double distance2 = GetDistance(x2, y2);
            if(distance1 <= distance2)
            { Console.WriteLine($"({x1}, {y1})"); }
            else { Console.WriteLine($"({x2}, {y2})"); }
        }

        static double GetDistance(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2)+ Math.Pow(y, 2));
        }

    }
}
