using System;

namespace _01.Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Car c = new Car(double.Parse(input[1]), double.Parse(input[2]));
            input = Console.ReadLine().Split();
            Truck t = new Truck(double.Parse(input[1]), double.Parse(input[2]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                double value = double.Parse(input[2]);
                if (input[0] == "Drive")
                {
                    switch (input[1])
                    {
                        case "Car": c.Drive(value); break;
                        case "Truck": t.Drive(value); break;
                    }
                }
                else if(input[0] == "Refuel")
                {
                    switch (input[1])
                    {
                        case "Car": c.Refuel(value); break;
                        case "Truck": t.Refuel(value); break;
                    }
                }
            }
            Console.WriteLine($"Car: {c.fuelQuantity:f2}");
            Console.WriteLine($"Truck: {t.fuelQuantity:f2}");
        }
    }
}
