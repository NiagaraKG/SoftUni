using System;

namespace _01.ClassBoxData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box b = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {b.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {b.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {b.Volume():f2}");
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
    }
}
