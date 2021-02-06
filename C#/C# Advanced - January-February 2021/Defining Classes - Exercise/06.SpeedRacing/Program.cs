using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            string[] input;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                cars.Add(new Car(input[0], double.Parse(input[1]),double.Parse(input[2])));
            }
            input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                foreach (var c in cars)
                {
                    if(c.Model == input[1]) { c.Drive(double.Parse(input[2])); break; }
                }
                input = Console.ReadLine().Split();
            }
            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTraveled}");
            }
        }
    }
}
