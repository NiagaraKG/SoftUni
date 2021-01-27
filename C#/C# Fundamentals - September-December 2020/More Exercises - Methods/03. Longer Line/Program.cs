using System;

namespace _03._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());            
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double distance1 = GetDistance(x1, y1, x2, y2);
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            double distance2 = GetDistance(x3, y3, x4, y4);
            if (distance1 >= distance2)
            {
                if (IsCloser(x1, y1, x2, y2))
                { Console.WriteLine($"({x1}, {y1})({x2}, {y2})"); }
                else
                { Console.WriteLine($"({x2}, {y2})({x1}, {y1})"); }
            }
            else 
            {
                if (IsCloser(x3, y3, x4, y4))
                { Console.WriteLine($"({x3}, {y3})({x4}, {y4})"); }
                else
                { Console.WriteLine($"({x4}, {y4})({x3}, {y3})"); }
            }
        }

        static bool IsCloser(double x1, double y1, double x2, double y2)
        {
            double distance1 = GetDistance(x1, y1);            
            double distance2 = GetDistance(x2, y2);
            if (distance1 <= distance2) { return true; }
            return false;
        }
        static double GetDistance(double x1, double y1, double x2 = 0, double y2 = 0)
        {
            return Math.Sqrt(Math.Pow((x1-x2), 2) + Math.Pow((y1-y2), 2));
        }
    }
}
